namespace DapperAPI.Requests
{
    public class UpdateStudentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double GPA { get; set; }
    }
}
