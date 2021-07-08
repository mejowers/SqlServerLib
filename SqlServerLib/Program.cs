using System;


using SqlServerLibrary;

namespace SqlServerConsole {
    class Program {
        static void Main(string[] args) {
            SqlServerLib ssl = new SqlServerLib();
            ssl.Connect("localhost\\sqlexpress", "Prs_db");

            // var users = ssl.UserGetAll();
            // var user = ssl.UserGetById(8);
            var vendor = ssl.UserGetById(3);
            //var vendors = ssl.VendorGetAll();
            /*  var newUser = new User() {
                  Id = 0, Username = "XX", Password = "XX",
                  FirstName = "XX", LastName = "XX",
                  Phone = "XX", Email = "XX",
                  Reviewer = false, Admin = false
              };
            ssl.UserCreate(newUser);*/

            //user.Phone = "999";
            //user.Email = "quit@life.com";
            //var rc = ssl.UserChange(user);
            //Console.WriteLine($"The change {(rc ? "worked!" : "failed")}");

            //vendor.Phone = "999";
            //vendor.Email = "live@life.com";
            //var rc = ssl.UserChange(vendor);
            //Console.WriteLine($"The change {(rc ? "worked!" : "failed")}");

            var newVendor = new Vendor() {
                Id = 0, Code = "XX", Name= "XX",
                Address = "XX", City = "XX",
                State = "XX", Zip = "XX",
                Phone = "XXX", Email = "XXX.XXXX"
            };
            ssl.VendorCreate(newVendor);




            ssl.Disconnect();

        }
    }
}
