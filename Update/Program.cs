using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sql = @"UPDATE Users SET Name=@Name, 
                                        Account=@Account, 
                                        Password=@Password, 
                                        DateOfBirthd=@DateOfBirthd, 
                                        Height=@Height 
                                        WHERE Id=@Id";
            var dbHelper = new SqlDbHelper("default");

            try
            {
                var parameters = new SqlParameterBuilder()
                    .AddNVarchar("Name", 50, "CCC")
                    .AddNVarchar("Account", 50, "account1-update")
                    .AddNVarchar("Password", 50, "passwoed1-update")
                    .AddNDateTime("DateOfBirthd", DateTime.Parse("1999-1-1"))
                    .AddNInt("Height", 170)
                    .AddNInt("Id", 1)
                    .Builder(); ;

                dbHelper.ExecuteNonQuery(sql, parameters);

                Console.WriteLine("紀錄已更新");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"操作失敗,原因{ex.Message}");
            }
        }
    }
}
