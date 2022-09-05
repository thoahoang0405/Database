using MISA.WEB07.CNTT2.Common.Entities;
using MISA.WEB07.CNTT2.Common.Enums;

using MISA.WEB07.CNTT2.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.WEB07.CNTT2.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field
            private IBaseDL<T> _baseDL;
        #endregion

        #region contructor
         public BaseBL(IBaseDL<T> baseDL)
                {
                    _baseDL = baseDL;
                }
        #endregion
        protected List<string> listErrorMsgs = new List<string>();
        protected int devCode;
        /// <summary>
        /// API thêm mới bản ghi
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        public Guid InsertRecord(T record)
        {
            
            return _baseDL.InsertRecord(record);
            
        }
        protected virtual bool ValidateCustom(T entity)
        {
            return true;
        }
        /// sửa 1  bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(20/08/2022)
        public int UpdateRecord(T entity, Guid id)
        {
            return (_baseDL.UpdateRecord(entity, id));
        }
        /// <summary>
        /// lấy tất cả bản  ghi
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(25/08/2022)
        public IEnumerable<dynamic> GetAllRecords()
        {
            return _baseDL.GetAllRecords();
        }
        /// <summary>
        /// xóa bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        public int DeleteRecordID(Guid id)
        {
            return _baseDL.DeleteRecordID(id);
        }
        /// <summary>
        /// lấy bản ghi theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        public T GetRecordByID(Guid id)
        {
            return (T)(_baseDL.GetRecordByID(id));
        }

       
        /// <summary>
        ///  lấy mã nhân viên mới
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// CreatedBy: HTTHOA(16/08/2022)
        public string GetNewCode()
        {
           return _baseDL.GetNewCode();
        }
    }
}
