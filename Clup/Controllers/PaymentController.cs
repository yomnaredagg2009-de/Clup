using Clup.Dtos;
using Clup.Models;
using Clup.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Clup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            if (createPaymentDto == null)
            {
                return BadRequest();
            }
            var payment = new Payment
            {
                MembershipId = createPaymentDto.MembershipId,
                Amount = createPaymentDto.Amount,
                PaymentDate = createPaymentDto.PaymentDate
            };
            await _unitOfWork.Payment.AddAsync(payment);
            await _unitOfWork.Save();
            var result = new
            {
                Id = payment.Id,
                membership = payment.MembershipId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate
            };
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentStatistics()
        {
           return Ok(await _unitOfWork.Payment.GetPaymentStatisticsAsync());
        }



    }
}
