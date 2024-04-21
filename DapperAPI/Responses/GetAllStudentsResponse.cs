using DapperAPI.Models;

namespace DapperAPI.Responses
{
    public class GetAllStudentsResponse
    {
        public List<StudentModel> List { get; set; } = new();
    }
}
