using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WEB07.CNTT2.Common;
using MISA.WEB07.CNTT2.Common.entities;
using MISA.WEB07.CNTT2.Common.Entities;
using MISA.WEB07.CNTT2.DL;

namespace MISA.WEB07.CNTT2.DL.EmployeeDL
{
    public interface IEmployeeDL:IBaseDL<Employee>
    {



        //public IEnumerable<Employees> GetAllEmployees();



        public PagingData<Employee> FilterEmployees(string? keyword, int? pageSize, int? pageNumber);
        public int DeleteMulti(List<Guid> ListId);

    }
}
