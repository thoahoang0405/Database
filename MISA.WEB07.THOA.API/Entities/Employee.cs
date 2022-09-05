using MISA.WEB07.THOA.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MISA.WEB07.THOA.API.entities
{
    public class Employees
    {   
       // Ctrl k s
        #region field
        //trường, biến, : camelCase
        //hàm, class, ...: PasCalCase
        //private readonly string _id;
       // private const int MaxPrice = 1000;


       /// <summary>
       /// Id nhân viên
       /// </summary>
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
       
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
       
        public string EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender Gender { get; set; }

        public Guid DepartmentID { get; set; }
        /// <summary>
        /// tên đơn vị
        /// </summary>
       
        public string DepartmentName { get; set; }

        /// <summary>
        /// số cmnd
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime IdentityDate { get; set; }

        /// <summary>
        /// nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// sđt
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// số đt cố định
        /// </summary>
        public string LandlinePhone { get; set; }


        /// <summary>
        /// email
        /// </summary>
     
        public string Email { get; set; }

        /// <summary>
        /// tên vị trí
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// số tài khoản
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// chi nhánh
        /// </summary>
        public string BankBranch { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
       
       


        #endregion



    }
}
