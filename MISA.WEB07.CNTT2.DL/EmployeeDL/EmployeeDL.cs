using System;
using Dapper;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISA.WEB07.CNTT2.Common.entities;
using MISA.WEB07.CNTT2.Common.Entities;
using MISA.WEB07.CNTT2.Common;
using MISA.WEB07.CNTT2.Common.Enums;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace MISA.WEB07.CNTT2.DL.EmployeeDL
{
    public class EmployeeDL : BaseDL<Employee>, IEmployeeDL
    {
        readonly string connectionDB = "Server= localhost; Port=3307; Database=misa.web07.cntt2.thoa; User Id = root;Password=123456 ";


        public PagingData<Employee> FilterEmployees(string? keyword, int? pageSize, int? pageNumber)
        {
            using (var sqlConnection = new MySqlConnection(connectionDB))
            {
                string storedProcedureName = "Proc_Employee_GetPaging";
                var parameters = new DynamicParameters();
                parameters.Add("@$Offset", (pageNumber - 1) * pageSize);
                parameters.Add("@$Limit",pageSize);
                parameters.Add("@$Sort", "ModifiedDate DESC");
                var orConditions = new List<string>();

                string whereClause = "";
                if (keyword != null)
                {
                orConditions.Add($"EmployeeCode LIKE '%{keyword}%'");
                orConditions.Add($"EmployeeName LIKE '%{keyword}%'");
                orConditions.Add($"PhoneNumber LIKE '%{keyword}%'");
                }
                

                if (orConditions.Count > 0)
                {
                    whereClause = $"({string.Join(" OR ", orConditions)})";
                }
                parameters.Add("@$Where", whereClause);

                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var multipleResults = sqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (multipleResults != null)
                {
                    var employees = multipleResults.Read<Employee>().ToList();
                    var TotalRecords = multipleResults.Read<long>().Single();
                    
                    int TotalPagesAll = 1;
                 
                    if (TotalRecords >= 0 && pageSize > 0)
                    {
                        TotalPagesAll = (int)(decimal)(TotalRecords / pageSize);
                        if(TotalPagesAll % pageSize != 0)
                        {
                            TotalPagesAll = TotalPagesAll + 1;
                        }
                    }



                    return new PagingData<Employee>()
                    {
                        Data = employees,
                        TotalRecords = TotalRecords,

                        TotalPages = TotalPagesAll
                    };
                }

                return null;

            }
        
        }
       
        protected override void GetBeforeSave(Employee entity)
        {
            entity.EmployeeID = Guid.NewGuid();
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            base.GetBeforeSave(entity);
          
        }

        protected override void GetAfterSave(Employee entity)
        {
            base.GetAfterSave(entity);
        }
        public int DeleteMulti(List<Guid> ListId)
        {
            using(var sqlConnection = new MySqlConnection(connectionDB))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ListId", ListId);
                string deleteMulti = "DELETE FROM employee WHERE EmployeeID IN @ListId";
                int result = sqlConnection.Execute(deleteMulti, parameters);
                return (result);
            }
        }

    }
}

