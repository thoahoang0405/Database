using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.CNTT2.API.NTier;
using MISA.WEB07.CNTT2.BL;
using MISA.WEB07.CNTT2.BL.DepartmentsBL;
using MISA.WEB07.CNTT2.Common.entities;
using MISA.WEB07.CNTT2.Common.Enums;

using MySqlConnector;


namespace MISA.WEB07.CNTT2.API.NTier
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {

        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Constructor

        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }


        #endregion
        ///  <summary>
        /// thêm mới bản ghi
        /// </summary>
        /// <param name = "record" ></ param >
        /// < returns > trả về validate nếu lỗi validate, trả về HttpContext nếu bị trùng mã và exception, trả về data nếu thành công</returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        [HttpPost]

        public virtual IActionResult InsertRecord([FromBody] T record)
        {
            
            try{
                var validate = HandleError.ValidateEntity(ModelState, HttpContext);
                if (validate != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validate);
                }

                var numberOfAffectedRows = _baseBL.InsertRecord(record);


                if (numberOfAffectedRows != Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status201Created, record);

                }
                else
                {

                    return StatusCode(StatusCodes.Status400BadRequest, "e004");
                }
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult(mySqlException, HttpContext));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(ex, HttpContext));
            }
        }
        /// <summary>
        /// sửa theo id
        /// </summary>
        /// <param name="employeeID"></param>
        ///<returns> status400 nếu lỗi ; return về status200 nếu thành công </returns>
        /// CreatedBy: HTTHOA(16/08/2022)

        [HttpPut("{id}")]

        public IActionResult UpdateRecord([FromBody] T entity, [FromRoute] Guid id)
        {
            try

            {
                var validate = HandleError.ValidateEntity(ModelState, HttpContext);
                if (validate != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validate);
                }
                int numberOfAffectedRows = _baseBL.UpdateRecord(entity, id);

                if (numberOfAffectedRows > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, id);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e004");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(ex, HttpContext));
            }

        }


        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <param name=""></param>
        /// <returns>về status500 hoặc status400 nếu lỗi ; return về status200 nếu thành công</returns>
        /// CreatedBy: HTTHOA(30/08/2022)

        [HttpGet]
        
        public IActionResult GetAllRecords()
        {
            try

            {
                var records = _baseBL.GetAllRecords();

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(ex, HttpContext));
            }
        }

        

        /// <summary>
        /// Lấy nhân viên theo ID
        /// </summary>
        /// <param name="employeeID"></param>
        ///<returns>về status500 hoặc status400 nếu lỗi ; return về status200 nếu thành công </returns>
        /// CreatedBy: HTTHOA(16/08/2022)

        [HttpGet("{id}")]
       
        public IActionResult GetRecordID([FromRoute] Guid id)
        {
           try

            {
                var result = _baseBL.GetRecordByID(id);

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

                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(ex, HttpContext));
            }



        }
        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <param name=""></param>
        /// ><returns>về status500 hoặc status400 nếu lỗi ; return về status200 nếu thành công </returns>
        /// CreatedBy: HTTHOA(16/08/2022)

        [HttpGet("NewCode")]
       
        public IActionResult GetNewCode()
        {
            try

            {
                string newCode = _baseBL.GetNewCode();
                return StatusCode(StatusCodes.Status200OK, newCode);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(ex, HttpContext));
            }
        }
        /// <summary>
        /// API xóa nhân viên
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns>về status500 hoặc status400 nếu lỗi ; return về status200 nếu thành công</returns>
        /// CreatedBy: HTTHOA(16/08/2022)

        [HttpDelete("{id}")]
       
        public IActionResult DeleteEmployeeByID([FromRoute] Guid id)
        {
            try

            {
                int numberOfAffectedRows = _baseBL.DeleteRecordID(id);

                // Xử lý kết quả trả về từ DB
                if (numberOfAffectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, id);
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
