using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MISA.WEB07.THOA.API.Enums;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;
using MISA.WEB07.THOA.API.Entities;
using MISA.WEB07.THOA.API.entities;
using MISA.WEB07.CNTT2.THOA.API.Enums;


//using Newtonsoft.Json;


namespace MISA.WEB07.THOA.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
       

        /// <summary>
        /// API  thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        [HttpPost]
        public IActionResult InsertEmployee([FromBody] entities.Employees employee)
        {
            try
            {
                var error = new ErrorService();
                var errorData = new Dictionary<string, string>();

                if (String.IsNullOrEmpty(employee.EmployeeCode))
                {

                    errorData.Add("EmployeeCode", "Mã nhân viên không được phép trống");

                }
                if (String.IsNullOrEmpty(employee.EmployeeName))
                {

                    errorData.Add("EmployeeName", "Tên nhân viên không được phép trống");

                }
                if (!IsValidEmail(email: employee.Email))
                {
                    errorData.Add("Email", "Email không đúng định dạng");
                }
                if (employee.DateOfBirth > DateTime.Now)
                {

                    errorData.Add("DateOfBirth", "Ngày sinh không được lớn hơn ngày hiện tại");
                }
                if (errorData.Count > 0)
                {
                    error.UserMsg = "Dữ liệu đầu vào không hợp lệ";
                    error.Data = errorData;
                    return StatusCode(StatusCodes.Status400BadRequest, error);
                }

                string connectionDB = "Host= localhost; Port=3307; Database=misa.web07.cntt2.thoa; User Id = root;Password=123456 ";
                var sqlConnection = new MySqlConnection(connectionDB);
                employee.CreatedDate = DateTime.Now;
                string sqlCommand = "INSERT INTO employee (EmployeeID,EmployeeCode,EmployeeName,DateOfBirth,Gender,DepartmentID,DepartmentName,IdentityNumber,IdentityDate,IdentityPlace,LandlinePhone,PhoneNumber,Email,Address,BankBranch,BankAccount,BankName,PositionName,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy) " +
                    "VALUE (@EmployeeID,@EmployeeCode,@EmployeeName,@DateOfBirth,@Gender,@DepartmentID,@DepartmentName,@IdentityNumber, @IdentityDate,@IdentityPlace,@LandlinePhone,@PhoneNumber,@Email ,@Address,@BankBranch,@BankAccount,@BankName,@PositionName,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
                   
                  
                   
                //chuẩn bị tham số đầu vào
                var employeeID = Guid.NewGuid();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", employeeID);
                parameters.Add("@EmployeeCode", employee.EmployeeCode);
                parameters.Add("@EmployeeName", employee.EmployeeName);
                parameters.Add("@DateOfBirth", employee.DateOfBirth);
                parameters.Add("@Gender", employee.Gender);
                parameters.Add("@IdentityNumber", employee.IdentityNumber);
                parameters.Add("@IdentityPlace", employee.IdentityPlace);
                parameters.Add("@IdentityDate", employee.IdentityDate);
                parameters.Add("@Email", employee.Email);
                parameters.Add("@Address", employee.Address);
                parameters.Add("@PhoneNumber", employee.PhoneNumber);
                parameters.Add("@LandlinePhone", employee.LandlinePhone);
                parameters.Add("@BankBranch", employee.BankBranch);
                parameters.Add("@BankAccount", employee.BankAccount);
                parameters.Add("@BankName", employee.BankName);
                parameters.Add("@PositionName", employee.PositionName);
                parameters.Add("@DepartmentID", employee.DepartmentID);
                parameters.Add("@DepartmentName", employee.DepartmentName);
                parameters.Add("@ModifiedDate", employee.ModifiedDate);
                parameters.Add("@ModifiedBy", employee.ModifiedBy);
                parameters.Add("@CreatedDate", employee.CreatedDate);
                parameters.Add("@CreatedBy", employee.CreatedBy);

                //thực hiện gọi vào db để chạy câu lệnh chạy update
                int numberOfAffectedRows = sqlConnection.Execute(sqlCommand, parameters);
                if (numberOfAffectedRows > 0)
                {
                    return StatusCode(StatusCodes.Status201Created, employeeID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, error);
                }
            }
            
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }

 bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        }
       

        /// <summary>
        /// API  sửa nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        [HttpPut("{employeeID}")]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEmployee([FromBody] entities.Employees employee, [FromRoute] Guid employeeID)
        {
            try
            {
              
                string connectionDB = "Host= localhost; Port=3307; Database=misa.web07.cntt2.thoa; User Id = root;Password=123456 ";
                var sqlConnection = new MySqlConnection(connectionDB);
                employee.CreatedDate = DateTime.Now;
                string storeProcedureName = "Proc_Employee_Update";
                var sqlCommand = "UPDATE employee SET " +
                
                    "EmployeeCode = @EmployeeCode," +
                    "EmployeeName = @EmployeeName," +
                    "DateOfBirth = @DateOfBirth," +
                    "Gender = @Gender," +
                    "DepartmentID = @DepartmentID," +
                    "DepartmentName=@DepartmentName,"+
                    "IdentityNumber = @IdentityNumber," +
                    "IdentityDate = @IdentityDate," +
                    "IdentityPlace = @IdentityPlace," +
                    "LandlinePhone = @LandlinePhone," +
                    "PhoneNumber = @PhoneNumber," +
                    "Email = @Email ," +
                    "Address = @Address," +
                    "BankBranch = @BankBranch," +
                    "BankAccount = @BankAccount," +
                    "BankName = @BankName," +
                    "PositionName = @PositionName," +
                    "ModifiedDate = @ModifiedDate," +
                    "CreatedDate=@CreatedDate,"+
                    "CreatedBy = @CreatedBy,"+
                    "ModifiedBy = @ModifiedBy " +
                    "WHERE EmployeeID=@EmployeeID";

                //chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", employeeID);
                parameters.Add("@EmployeeCode", employee.EmployeeCode);
                parameters.Add("@EmployeeName", employee.EmployeeName);
                parameters.Add("@DateOfBirth", employee.DateOfBirth);
                parameters.Add("@Gender", employee.Gender);
                parameters.Add("@IdentityNumber", employee.IdentityNumber);
                parameters.Add("@IdentityPlace", employee.IdentityPlace);
                parameters.Add("@IdentityDate", employee.IdentityDate);
                parameters.Add("@Email", employee.Email);
                parameters.Add("@Address", employee.Address);
                parameters.Add("@PhoneNumber", employee.PhoneNumber);
                parameters.Add("@LandlinePhone", employee.LandlinePhone);
                parameters.Add("@BankBranch", employee.BankBranch);
                parameters.Add("@BankAccount", employee.BankAccount);
                parameters.Add("@BankName", employee.BankName);
                parameters.Add("@PositionName", employee.PositionName);
                parameters.Add("@DepartmentID", employee.DepartmentID);
                parameters.Add("@DepartmentName", employee.DepartmentName);
                parameters.Add("@ModifiedDate", employee.ModifiedDate);
                parameters.Add("@ModifiedBy", employee.ModifiedBy);
                parameters.Add("@CreatedDate", employee.CreatedDate);
                parameters.Add("@CreatedBy", employee.CreatedBy);

                //thực hiện gọi vào db để chạy câu lệnh chạy updatee
                int numberOfAffectedRows = sqlConnection.Execute(sqlCommand, parameters);
                if (numberOfAffectedRows > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, employeeID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (MySqlException mySqlException)
            {
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e003");
                }
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
        /// <summary>
        /// API xóa nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)

        [HttpDelete("{employeeID}")]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteEmployeeByID([FromRoute] Guid employeeID)
        {
            try
            {
                var connectionDB = "Host= localhost; Port=3307; Database=misa.web07.cntt2.thoa; User Id = root;Password=123456 ";
                var sqlConnection = new MySqlConnection(connectionDB);
                var sqlCommand = $"DELETE FROM employee Where EmployeeID=@EmployeeID";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", employeeID);

                // Thực hiện gọi vào DB để chạy câu lệnh DELETE với tham số đầu vào ở trên
                int numberOfAffectedRows = sqlConnection.Execute(sqlCommand, parameters);

                // Xử lý kết quả trả về từ DB
                if (numberOfAffectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, employeeID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }


        /// <summary>
        /// API lấy dữ liệu phân trang
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        [HttpGet("Filter")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Entities.PagingData<entities.Employees>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterEmployees(
            [FromQuery] string keyword,

            [FromQuery] int pageSize ,
            [FromQuery] int pageNumber 
        )
        {
            try
            {
                string connectionDB = "Host= localhost; Port=3307; Database=misa.web07.cntt2.thoa; User Id = root;Password=123456 ";
                var sqlConnection = new MySqlConnection(connectionDB);
                string storedProcedureName = "Proc_employee_GetPaging";
                var parameters = new DynamicParameters();
                parameters.Add("@v_Offset", (pageNumber - 1) * pageSize);
                parameters.Add("@v_Limit", pageSize);
                parameters.Add("@v_Sort", "ModifiedDate DESC");
                var orConditions = new List<string>();
               
                string whereClause = "";

                if (keyword != null)
                {
                    orConditions.Add($"EmployeeCode LIKE '%{keyword}%'");
                    orConditions.Add($"EmployeeName LIKE '%{keyword}%'");
                    orConditions.Add($"PhoneNumber LIKE '%{keyword}%'");
                }
                if (orConditions.Count > 0)
                {
                    whereClause = $"({string.Join(" OR ", orConditions)})";
                }
                parameters.Add("@v_Where", whereClause);

                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var multipleResults = sqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            
                // Xử lý kết quả trả về từ DB
                if (multipleResults != null)
                {
                    var employees = multipleResults.Read<Employees>().ToList();
                    var TotalRecord = multipleResults.Read<long>().Single();
                    return StatusCode(StatusCodes.Status200OK, new CNTT2.Common.Entities.PagingData<Employees>()
                    {
                        Data = employees,
                        TotalRecord = TotalRecord,
                       

                });
                    
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }




        }

        /// <summary>
        /// Lấy nhân viên theo ID
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        [HttpGet("{employeeID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Employees))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEmployeeByID([FromRoute] Guid employeeID)
        {
            try
            {
                string connectionDB = "Host= localhost; Port=3307; Database=misa.web07.cntt2.thoa; User Id = root;Password=123456 ";
                var sqlConnection = new MySqlConnection(connectionDB);
                string storedProcedureName = "Proc_Employee_GetByEmployeeID";
                var parameters = new DynamicParameters();
                parameters.Add("@v_Id", employeeID);
                var result = sqlConnection.QueryFirstOrDefault<Employees>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }





        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        [HttpGet("NewEmployeeCode")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                var connectionDB = "Host= localhost; Port=3307; Database=misa.web07.cntt2.thoa; User Id = root;Password=123456 ";
                var sqlConnection = new MySqlConnection(connectionDB);
                var storedProcedureName = "Proc_Employee_GetMaxCode";
                string maxCode = sqlConnection.QueryFirstOrDefault<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý sinh mã nhân viên mới tự động tăng
                // Cắt chuỗi mã nhân viên lớn nhất trong hệ thống để lấy phần số

                string newEmployeeCode = "NV" + (Int64.Parse(maxCode.Substring(2)) + 1).ToString();

                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK, newEmployeeCode);

            }
            catch (Exception ex)
            {


                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
        /// <summary>
        /// Lấy taat ca nv
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<Employees>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllEmployees()
        {
            try
            {
                string connectionDB = "Host= localhost; Port=3307; Database=misa.web07.cntt2.thoa; User Id = root;Password=123456 ";
                var sqlConnection = new MySqlConnection(connectionDB);
                string sqlCommand = "SELECT * FROM employee";
                var Employees = sqlConnection.Query<Employees>(sqlCommand);             
                if (Employees != null)
                {
                    return StatusCode(StatusCodes.Status200OK, Employees);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }

            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status400BadRequest, "e003");
            }
        }
    }


}