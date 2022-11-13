using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sql = @"INSERT INTO Users(Name,Account,Password,DateOfBirthd,Height)VALUES(@Name,@Account,@Password,@DateOfBirthd,@Height)";
            var dbHelper = new SqlDbHelper("default");

            try
            {
                var parameters = new SqlParameterBuilder()
                    .AddNVarchar("Name", 50, "AAA")
                    .AddNVarchar("Account", 50, "account1")
                    .AddNVarchar("Password", 50, "passwoed1")
                    .AddNDateTime("DateOfBirthd", DateTime.Parse("1990-1-1"))
                    .AddNInt("Height",170)
                    .Builder(); ;

                dbHelper.ExecuteNonQuery(sql, parameters);

                Console.WriteLine("紀錄已新增");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"操作失敗,原因{ex.Message}");
            }
        }
    }
}
