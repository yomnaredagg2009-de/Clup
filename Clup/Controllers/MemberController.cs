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
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> CreateMember(CreateMemberDto createMemberDto)
        {

            if (createMemberDto == null)
            {
                return BadRequest();
            }
            var member = new Member
            {
                FullName = createMemberDto.Name,
                Email = createMemberDto.Email,
                Phone = createMemberDto.PhoneNumber
            };
            await _unitOfWork.Members.AddAsync(member);
            await _unitOfWork.Save();
            var result = new
            {
                Id = member.Id,
                Name = member.FullName,
                Email = member.Email,
                PhoneNumber = member.Phone
            };
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            var member= await _unitOfWork.Members.SearchByNameAsync(name);
            var result = new GetMemberByIdDto
            {
                Id = member.Id,
                Name = member.FullName,
                Email = member.Email,
                PhoneNumber = member.Phone
            };
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMember(int id, UpdateMemberDto updateMemberDto)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            member.FullName = updateMemberDto.Name;
            member.Email = updateMemberDto.Email;
            member.Phone = updateMemberDto.PhoneNumber;
            _unitOfWork.Members.UpdateAsync(member);
            await _unitOfWork.Save();
            return NoContent();
        }

        [HttpGet("members")]
        public async Task<IActionResult> GetMembers(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
                return BadRequest("Page number and page size must be greater than zero.");

            var members = await _unitOfWork.Members.GetPageAsync(pageNumber, pageSize);
            var result = members.Select(m => new GetMemberByIdDto
            {
                Id = m.Id,
                Name = m.FullName,
                Email = m.Email,
                PhoneNumber = m.Phone
            }).ToList();
            return Ok(result);
        }





    }
}
