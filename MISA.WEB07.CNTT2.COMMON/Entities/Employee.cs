
using MISA.WEB07.CNTT2.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MISA.WEB07.CNTT2.Common.entities
{
    [Table("employee")]
    public class Employee
    {
        // Ctrl k s
        #region field
        //trường, biến, : camelCase
        //hàm, class, ...: PasCalCase


        /// <summary>
        /// Id nhân viên
        /// </summary>
         [Key]
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
       
        [Required(ErrorMessage = "Mã nhân viên không được trống")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required(ErrorMessage = "Tên nhân viên không được trống")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender? Gender { get; set; }

        public Guid DepartmentID { get; set; }
        /// <summary>
        /// tên đơn vị
        /// </summary>
        [Required(ErrorMessage = "Đơn vị không được trống")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// số cmnd
        /// </summary>
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// nơi cấp
        /// </summary>
        public string? IdentityPlace { get; set; }



        /// <summary>
        /// số đt cố định
        /// </summary>
        public string? LandlinePhone { get; set; }
        /// <summary>
        /// sđt
        /// </summary>
        public string? PhoneNumber { get; set; }


        /// <summary>
        /// email
        /// </summary>
        
        [EmailAddress(ErrorMessage = "email không đúng định dạng")]
        public string? Email { get; set; }
        /// <summary>
        /// địa chỉ
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// chi nhánh
        /// </summary>
        public string? BankBranch { get; set; }
        /// <summary>
        /// số tài khoản
        /// </summary>
        public string? BankAccount { get; set; }

        /// <summary>
        /// tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }



        /// <summary>
        /// tên vị trí
        /// </summary>
        public string? PositionName { get; set; }


        /// <summary>
        /// ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// người chỉnh sửa
        /// </summary>
        public string? ModifiedBy { get; set; }
       
       


        #endregion



    }
}
