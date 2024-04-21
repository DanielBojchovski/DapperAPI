namespace DapperAPI.Responses
{
    public class CreateStudentResponse
    {
        public OperationStatusResponse OperationStatusResponse { get; set; } = new();
        public GetAllStudentsResponse List { get; set; } = new();
    }
}
