
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.CNTT2.BL.DepartmentsBL;
using MISA.WEB07.CNTT2.Common.entities;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.WEB07.CNTT2.API.NTier.Controllers
{
    
    public class DepartmentsController : BasesController<Departments>
    {
        private IDepartmentsBL _departmentsBL;
        public DepartmentsController(IDepartmentsBL departmentsBL): base(departmentsBL)
        {
            _departmentsBL = departmentsBL;
        }

        
    }
}
