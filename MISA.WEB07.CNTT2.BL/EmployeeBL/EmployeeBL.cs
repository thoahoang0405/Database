using System;
using System.Collections.Generic;
using MISA.WEB07.CNTT2.DL.EmployeeDL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WEB07.CNTT2.Common.entities;
using MISA.WEB07.CNTT2.Common.Entities;
using MISA.WEB07.CNTT2.Common.Enums;
using MISA.WEB07.CNTT2.BL;
using MISA.WEB07.CNTT2.Common;

namespace MISA.WEB07.CNTT2.BL.EmployeeBL
{
    public class EmployeeBL: BaseBL<Employee>, IEmployeeBL
    {
       private IEmployeeDL _employeeDL;
        public EmployeeBL(IEmployeeDL employeeDL): base(employeeDL)
        {
            _employeeDL = employeeDL;
        }



        public PagingData<Employee> FilterEmployees(string? keyword, int? pageSize, int? pageNumber)
        {
            return _employeeDL.FilterEmployees(keyword, pageSize,pageNumber);
        }
        public int DeleteMulti(List<Guid> ListId)
        {
            return _employeeDL.DeleteMulti(ListId);
        }
    }

   
}
