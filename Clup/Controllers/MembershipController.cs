using Clup.Dtos;
using Clup.Repo.Interface;
using Clup.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Clup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MembershipController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMembership(CreateMembershipDto createMembershipDto)
        {
            if (createMembershipDto == null)
            {
                return BadRequest();
            }
            var membership = new Membership
            {
                MemberId = createMembershipDto.MemberId,
                StartDate = createMembershipDto.StartDate,
                EndDate = createMembershipDto.EndDate
            };

            await _unitOfWork.Memberships.AddAsync(membership);
            await _unitOfWork.Save();
            var result = new
            {
                Id = membership.Id,
                MemberId = membership.MemberId,
                StartDate = membership.StartDate,
                EndDate = membership.EndDate
            };
            return Ok(result);
        }
        [HttpGet]

        public async Task<IActionResult> GetMemberships()
        {
            var memberships = await _unitOfWork.Memberships.GetAllAsync();
            var result = memberships.Select(m => new
            {
                Id = m.Id,
                MemberId = m.MemberId,
                StartDate = m.StartDate,
                EndDate = m.EndDate
            });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveMemberships()
        {
            return Ok(await _unitOfWork.Membership.GetActiveMembershipsAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembership(int id)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(id);
            if (membership == null)
            {
                return NotFound();
            }
            _unitOfWork.Memberships.DeleteAsync(id);
            await _unitOfWork.Save();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMembership(int id)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(id);
            if (membership == null)
            {
                return NotFound();
            }

            await _unitOfWork.Membership.RenewMembershipAsync(id);
            await _unitOfWork.Save();
            var result = new
            {
                Id = membership.Id,
                MemberId = membership.MemberId,
                StartDate = membership.StartDate,
                EndDate = membership.EndDate
            };
            return Ok(result);
        }

    }
}
