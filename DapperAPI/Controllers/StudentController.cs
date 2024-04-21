using DapperAPI.Entities;
using DapperAPI.Interfaces;
using DapperAPI.Requests;
using DapperAPI.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<CreateStudentResponse>> CreateStudent(CreateStudentRequest request)
        {
            return await _service.CreateStudent(request);
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult<OperationStatusResponse>> DeleteStudent(IdRequest request)
        {
            return await _service.DeleteStudent(request);
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<UpdateStudentResponse>> UpdateStudent(UpdateStudentRequest request)
        {
            return await _service.UpdateStudent(request);
        }

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<GetAllStudentsResponse>> GetAllStudents()
        {
            return await _service.GetAllStudents();
        }

        [HttpGet("GetStudentById")]
        public async Task<ActionResult<Student?>> GetStudentById([FromQuery] IdRequest request)
        {
            return await _service.GetStudentById(request);
        }
    }
}
