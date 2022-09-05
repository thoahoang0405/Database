namespace MISA.WEB07.CNTT2.Common.Entities
{
    public class PagingData<T>
    {
        /// <summary>
        /// Dữ liệu trả về khi phân trang
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của đối tượng trong mảng trả về</typeparam>
       
            /// <summary>
            /// Mảng đối tượng thỏa mãn điều kiện lọc và phân trang 
            /// </summary>
            public List<T> Data { get; set; } = new List<T>();


            /// <summary>
            /// Tổng số bản ghi thỏa mãn điều kiện
            /// </summary>
          
            public long TotalRecords { get; set; }
        /// <summary>
        /// Tổng số trang
        /// </summary>
            public int TotalPages { get; set; }
    }
}
