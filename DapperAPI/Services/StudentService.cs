using Dapper;
using DapperAPI.Context;
using DapperAPI.Entities;
using DapperAPI.Interfaces;
using DapperAPI.Models;
using DapperAPI.Requests;
using DapperAPI.Responses;
using System.Data;

namespace DapperAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateStudentResponse> CreateStudent(CreateStudentRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", request.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("GPA", request.GPA, DbType.Double, ParameterDirection.Input);

            using(var connection = _context.CreateConnection())
            {
                using (var multi = await connection.QueryMultipleAsync("CreateStudent", parameters, commandType: CommandType.StoredProcedure))
                {
                    var operationStatus = await multi.ReadSingleAsync<OperationStatusResponse>();
                    var students = await multi.ReadAsync<StudentModel>();

                    return new CreateStudentResponse
                    {
                        OperationStatusResponse = operationStatus,
                        List = new GetAllStudentsResponse { List = students.ToList() }
                    };
                }
            }
        }

        public async Task<OperationStatusResponse> DeleteStudent(IdRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", request.Id, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var response = await connection.QueryFirstOrDefaultAsync<OperationStatusResponse>(
                    "DeleteStudent",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return response ?? new OperationStatusResponse
                {
                    IsSuccessful = false,
                    Message = "Error: No response from database."
                };
            }
        }

        public async Task<GetAllStudentsResponse> GetAllStudents()
        {
            using (var connection = _context.CreateConnection()) 
            {
                var students = await connection.QueryAsync<StudentModel>("GetAllStudents", commandType: CommandType.StoredProcedure);
                return new GetAllStudentsResponse { List = students.ToList() };
            }
        }

        public async Task<Student?> GetStudentById(IdRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", request.Id, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var student = await connection.QueryFirstOrDefaultAsync<Student?>(
                    "GetStudentById",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return student!;
            }
        }

        public async Task<UpdateStudentResponse> UpdateStudent(UpdateStudentRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", request.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Name", request.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("GPA", request.GPA, DbType.Double, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                using (var multi = await connection.QueryMultipleAsync("UpdateStudent", parameters, commandType: CommandType.StoredProcedure))
                {
                    var operationStatus = await multi.ReadSingleAsync<OperationStatusResponse>();
                    var students = await multi.ReadAsync<StudentModel>();

                    return new UpdateStudentResponse
                    {
                        OperationStatusResponse = operationStatus,
                        List = new GetAllStudentsResponse { List = students.ToList() }
                    };
                }
            }
        }
    }
}
