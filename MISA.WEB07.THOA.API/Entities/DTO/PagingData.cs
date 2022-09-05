namespace MISA.WEB07.THOA.API.Entities
{
    public class PagingData<T>
    {
        /// <summary>
        /// Dữ liệu trả về khi lọc và phân trang
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của đối tượng trong mảng trả về</typeparam>
       
            /// <summary>
            /// Mảng đối tượng thỏa mãn điều kiện lọc và phân trang 
            /// </summary>
            public List<T> Data { get; set; } = new List<T>();

            /// <summary>
            /// Tổng số bản ghi thỏa mãn điều kiện
            /// </summary>
            public long TotalRecord { get; set; }
            public long TotalPages { get; set; }
           
    }
}
