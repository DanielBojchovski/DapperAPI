namespace DapperAPI.Responses
{
    public class UpdateStudentResponse
    {
        public OperationStatusResponse OperationStatusResponse { get; set; } = new();
        public GetAllStudentsResponse List { get; set; } = new();
    }
}
