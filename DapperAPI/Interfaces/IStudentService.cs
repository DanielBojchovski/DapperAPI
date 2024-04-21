using DapperAPI.Entities;
using DapperAPI.Models;
using DapperAPI.Requests;
using DapperAPI.Responses;

namespace DapperAPI.Interfaces
{
    public interface IStudentService
    {
        Task<GetAllStudentsResponse> GetAllStudents();
        Task<Student?> GetStudentById(IdRequest request);
        Task<CreateStudentResponse> CreateStudent(CreateStudentRequest request);
        Task<UpdateStudentResponse> UpdateStudent(UpdateStudentRequest request);
        Task<OperationStatusResponse> DeleteStudent(IdRequest request);
    }
}
