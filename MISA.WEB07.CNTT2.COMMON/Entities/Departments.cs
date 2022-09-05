namespace MISA.WEB07.CNTT2.Common.entities
{
    public class Departments {
        public Guid DepartmentID { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

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


    }
}
