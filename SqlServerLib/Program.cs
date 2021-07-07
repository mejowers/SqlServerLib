using System;


using SqlServerLibrary;

namespace SqlServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServerLib ssl = new SqlServerLib();
            ssl.Connect("localhost\\sqlexpress", "Prs_db");

            // var users = ssl.UserGetAll();
            var user = ssl.UserGetByPK(9);
            var vendors = ssl.VendorGetAll();

                ssl.Disconnect();
            
        }
    }
}
