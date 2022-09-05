using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.THOA.API.entities;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;


namespace MISA.WEB07.THOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
        public class DepartmentsController : ControllerBase
    {
        /// <summary>
        /// Lấy tất cả đơn vị
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<Departments>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllDepartments()

        {
            try
            {
                var connectionDB = "Host= localhost; Port=3307; Database=misa.web07.cntt2.thoa; User Id = root;Password=123456 ";
                var sqlConnection = new MySqlConnection(connectionDB);
                var sqlCommand = "SELECT * FROM departments";
                var Departments = sqlConnection.Query<Departments>(sql: sqlCommand);

                return Ok(Departments);
                if (Departments != null)
                {
                    return StatusCode(StatusCodes.Status200OK, Departments);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }

            }
            catch (Exception exception)
            {

                //Console.WriteLine(Exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e003");
            }
            

        }



    }
}
