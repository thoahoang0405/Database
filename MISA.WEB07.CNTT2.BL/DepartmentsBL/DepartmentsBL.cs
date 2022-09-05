using MISA.WEB07.CNTT2.DL.DepartmentsDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WEB07.CNTT2.Common.entities;

namespace MISA.WEB07.CNTT2.BL.DepartmentsBL
{
    public class DepartmentsBL :BaseBL<Departments>, IDepartmentsBL
    {
        private IDepartmentsDL _departmentDL;
        public DepartmentsBL(IDepartmentsDL departmentsDL)  :  base(departmentsDL)
        {
            _departmentDL = departmentsDL;
        }
        //public IEnumerable<Departments> GetAllDepartments()
        //{
        //    return _departmentDL.GetAllDepartments();
        //}

    }
}
