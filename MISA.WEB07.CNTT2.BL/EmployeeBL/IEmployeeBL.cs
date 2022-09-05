using MISA.WEB07.CNTT2.BL;
using MISA.WEB07.CNTT2.Common;
using MISA.WEB07.CNTT2.Common.entities;
using MISA.WEB07.CNTT2.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.CNTT2.BL.EmployeeBL
{
    public interface IEmployeeBL : IBaseBL<Employee>
    {



        /// <summary>
        /// API  sửa nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)






        /// <summary>
        /// API lấy dữ liệu phân trang
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)

        public PagingData<Employee> FilterEmployees(string? keyword, int? pageSize, int? pageNumber);




        public int DeleteMulti(List<Guid> ListId);



        //public IEnumerable<Employees> GetAllEmployees();
    }

    }
