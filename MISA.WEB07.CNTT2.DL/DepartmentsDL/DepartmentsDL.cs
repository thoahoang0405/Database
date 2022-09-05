using Dapper;
using MISA.WEB07.CNTT2.Common.entities;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.CNTT2.DL.DepartmentsDL
{
    public class DepartmentsDL: BaseDL<Departments>, IDepartmentsDL
    {
        //public IEnumerable<Departments> GetAllDepartments()
        //{
        //    var connectionDB = "Host= localhost; Port=3307; Database=misa.web07.cntt2.thoa; User Id = root;Password=123456 ";
        //    var sqlConnection = new MySqlConnection(connectionDB);
        //    var sqlCommand = "SELECT * FROM departments";
        //    var Departments = sqlConnection.Query<Departments>(sql: sqlCommand);

        //    return Departments;
        //}
    }
}
