namespace DapperAPI.Requests
{
    public class CreateStudentRequest
    {
        public string Name { get; set; } = string.Empty;
        public double GPA { get; set; }
    }
}
