using Dapper;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MISA.WEB07.CNTT2.API.NTier;
using MISA.WEB07.CNTT2.BL.EmployeeBL;
using MISA.WEB07.CNTT2.Common;
using MISA.WEB07.CNTT2.Common.entities;
using MISA.WEB07.CNTT2.Common.Entities;
using MISA.WEB07.CNTT2.Common.Entities.DTO;
using MISA.WEB07.CNTT2.Common.Enums;

using MySqlConnector;
using OfficeOpenXml;
using Swashbuckle.AspNetCore.Annotations;
using Syncfusion.XlsIO;
using static System.Net.Mime.MediaTypeNames;

namespace MISA.WEB07.CNTT2.API.NTier.Controllers
{

    public class EmployeesController : BasesController<Employee>
    {

        private IEmployeeBL _employeeBL;


        public EmployeesController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }

      

        /// <summary>
        ///  lấy dữ liệu phân trang
        /// </summary>
        /// <param name="keyword, pageSize, pageNumber"></param>
        /// <returns>về status500 hoặc status400 nếu lỗi ; return về status200 nếu thành công </returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        [HttpGet("Filter")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Common.Entities.PagingData<Employee>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterEmployees([FromQuery] string? keyword, [FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            try
            {
                var multipleResults = _employeeBL.FilterEmployees(keyword, pageSize, pageNumber);
                if (multipleResults != null)
                {
                    return StatusCode(StatusCodes.Status200OK, multipleResults);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }


        [HttpGet("exportExcel")]
        public async Task<IActionResult> ExportExcel(CancellationToken cancellationToken)
        {
            // query data from database  
            await Task.Yield();
            string connectionDB = "Host= localhost; Port=3307; Database=misa.web07.cntt2.thoa; User Id = root;Password=123456 ";
            var sqlConnection = new MySqlConnection(connectionDB);
            string sqlCommand = "Select * from employee";
            var Employees = sqlConnection.QueryMultiple(sqlCommand);
            var employees = Employees.Read<Employee>().ToList();


            var list = new List<Employee>(employees);
           

            var stream = new MemoryStream();          
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"EmployeesList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);

        }

        [HttpPut("Multiple")]
        public IActionResult DeleteMulti([FromBody] List<Guid> ListId)
        {
            try { 

            int result = _employeeBL.DeleteMulti(ListId);
            if (result > 0)
            {
                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK, ListId);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
        }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(ex, HttpContext));
    }
}


    }
}
