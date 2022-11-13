using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Select
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbHelper = new SqlDbHelper("default");
            string sql = @"SELECT Id, Name, Account, Password, DateOfBirthd, Height FROM Users WHERE Id>@Id ORDER BY Id ASC";
            try
            {
                var parameters = new SqlParameterBuilder()
                    .AddNInt("Id", 0)
                    .Builder(); 
                DataTable Users = dbHelper.Select(sql, parameters);
                foreach (DataRow row in Users.Rows)
                {
                    int id = row.Field<int>("id");
                    string name = row.Field<string>("Name");
                    string account = row.Field<string>("Account");
                    string password = row.Field<string>("Password");
                    DateTime dateOfBirthd = row.Field<DateTime>("DateOfBirthd");
                    int height = row.Field<int>("Height");
                    Console.WriteLine($"Id={id}, Name={name}, Account={account}, Password={password}, DateOfBirthd={dateOfBirthd:yyyy/MM/dd}, Height={height}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"操作失敗,原因{ex.Message}");
            }
        }
    }
}
