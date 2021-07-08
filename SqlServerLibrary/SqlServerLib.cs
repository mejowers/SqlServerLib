using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace SqlServerLibrary {
    public class SqlServerLib {
        SqlConnection sqlConn = null;

        public bool UserChange(User user) {
            if (sqlConn == null) { throw new Exception("No Connection!"); }
            var sql = " UPDATE [User] Set "
                   + " Username = @Username, "
                   //                   + " Password = @Password, "
                   + " FirstName = @FirstName, "
                   + " LastName = @LastName, "
                   + " Phone = @Phone, "
                   + " Email = @Email, "
                   + " Reviewer = @Reviewer, "
                   + " Admin = @Admin "
                   + " Where Id = @Id;";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.Parameters.AddWithValue("@Username", user.Username);
            //sqlcmd.Parameters.AddWithValue("@Password", user.Password);
            sqlcmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            sqlcmd.Parameters.AddWithValue("@LastName", user.LastName);
            sqlcmd.Parameters.AddWithValue("@Phone", user.Phone);
            sqlcmd.Parameters.AddWithValue("@Email", user.Email);
            sqlcmd.Parameters.AddWithValue("@Reviewer", user.Reviewer);
            sqlcmd.Parameters.AddWithValue("@Admin", user.Admin);
            sqlcmd.Parameters.AddWithValue("@Id", user.Id);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }

        public bool UserCreate(User user) {
            if (sqlConn == null) { throw new Exception("No connection"); }
            var sql = "INSERT into [User] "
                        + " (Username, Password, FirstName, LastName, Phone, Email, Reviewer, Admin) "
                        + " VALUES "
                        + " (@Username, @Password, @FirstName, @LastName, @Phone, @Email, "
                        + " @Reviewer, @Admin) ";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.Parameters.AddWithValue("@Username", user.Username);
            sqlcmd.Parameters.AddWithValue("@Password", user.Password);
            sqlcmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            sqlcmd.Parameters.AddWithValue("@LastName", user.LastName);
            sqlcmd.Parameters.AddWithValue("@Phone", user.Phone);
            sqlcmd.Parameters.AddWithValue("@Email", user.Email);
            sqlcmd.Parameters.AddWithValue("@Reviewer", user.Reviewer);
            sqlcmd.Parameters.AddWithValue("@Admin", user.Admin);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return rowsAffected == 1;
        }

        public List<Vendor> VendorGetAll() {
            {
                if (sqlConn == null) {
                    throw new Exception("No Connection!");
                }
                var sql = "SELECT * From Vendor;";
                var sqlcmd = new SqlCommand(sql, sqlConn);
                var reader = sqlcmd.ExecuteReader();
                var vendors = new List<Vendor>();
                while (reader.Read()) {
                    var vendor = new Vendor();
                    vendor.Id = Convert.ToInt32(reader["Id"]);
                    vendor.Code = Convert.ToString(reader["Code"]);
                    vendor.Name = Convert.ToString(reader["Name"]);
                    vendor.Address = Convert.ToString(reader["Address"]);
                    vendor.City = Convert.ToString(reader["City"]);
                    vendor.State = Convert.ToString(reader["State"]);
                    vendor.Zip = Convert.ToString(reader["Zip"]);
                    vendor.Phone = Convert.ToString(reader["Phone"]);
                    vendor.Email = Convert.ToString(reader["Email"]);
                    vendors.Add(vendor);
                }
                reader.Close();
                return vendors;
            }
        }

        public Vendor VendorGetbyId(int Id) { 
            if (sqlConn == null) {
                throw new Exception("No Connection!");
            }
            var sql = "SELECT * From [Vendor] Where Id = @Id";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.Parameters.AddWithValue("@Id", Id);
            var reader = sqlcmd.ExecuteReader();
            if (!reader.HasRows) {
                reader.Close();
                return null;
            }
            reader.Read();
            var vendor = new Vendor();
            vendor.Id = Convert.ToInt32(reader["Id"]);
            vendor.Code = Convert.ToString(reader["Code"]);
            vendor.Name = Convert.ToString(reader["Name"]);
            vendor.Address = Convert.ToString(reader["Address"]);
            vendor.City = Convert.ToString(reader["City"]);
            vendor.State = Convert.ToString(reader["State"]);
            vendor.Zip = Convert.ToString(reader["Zip"]);
            vendor.Phone = Convert.ToString(reader["Phone"]);
            vendor.Email = Convert.ToString(reader["Email"]);
            reader.Close();
            return vendor;
        }
        public bool VendorChange(Vendor vendor) {
            if (sqlConn == null) { throw new Exception("No Connection!"); }
            var sql = " UPDATE [Vendor] Set "
                   + " Code = @Code, "
                   + " Name = @Name, "
                   + " Address = @Address, "
                   + " City = @City, "
                   + " State = @State, "
                   + " Zip = @Zip, "
                   + " Phone = @Phone, "
                   + " Email = @Email "
                   + " Where Id = @Id;";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.Parameters.AddWithValue("@Code", vendor.Code);
            sqlcmd.Parameters.AddWithValue("@Name", vendor.Name);
            sqlcmd.Parameters.AddWithValue("@Address", vendor.Address);
            sqlcmd.Parameters.AddWithValue("@City", vendor.City);
            sqlcmd.Parameters.AddWithValue("@State", vendor.State);
            sqlcmd.Parameters.AddWithValue("@Zip", vendor.Zip);
            sqlcmd.Parameters.AddWithValue("@Phone", vendor.Phone);
            sqlcmd.Parameters.AddWithValue("@Email", vendor.Email);
            sqlcmd.Parameters.AddWithValue("@Id", vendor.Id);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }
        public bool VendorCreate(Vendor vendor) {
            if (sqlConn == null) { throw new Exception("No connection"); }
            var sql = "INSERT into [Vendor] "
                        + " (Code, Name, Address, City, State, Zip, Phone, Email) "
                        + " VALUES "
                        + " (@Code, @Name, @Address, @City, @State, @Zip, "
                        + " @Phone, @Email) ";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.Parameters.AddWithValue("@Code", vendor.Code);
            sqlcmd.Parameters.AddWithValue("@Name", vendor.Name);
            sqlcmd.Parameters.AddWithValue("@Address", vendor.Address);
            sqlcmd.Parameters.AddWithValue("@City", vendor.City);
            sqlcmd.Parameters.AddWithValue("@State", vendor.State);
            sqlcmd.Parameters.AddWithValue("@Zip", vendor.Zip);
            sqlcmd.Parameters.AddWithValue("@Phone", vendor.Phone);
            sqlcmd.Parameters.AddWithValue("@Email", vendor.Email);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return rowsAffected == 1;
        }


        public User UserGetById(int Id) {
            if (sqlConn == null) {
                throw new Exception("No Connection!");
            }
            var sql = "SELECT * From [User] Where Id = @Id";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.Parameters.AddWithValue("@Id", Id);
            var reader = sqlcmd.ExecuteReader();
            if (!reader.HasRows) {
                reader.Close();
                return null;
            }
            reader.Read();
            var user = new User();
            user.Id = Convert.ToInt32(reader["Id"]);
            user.Username = Convert.ToString(reader["Username"]);
            //user.Password = Convert.ToString(reader["Password"]);
            user.FirstName = Convert.ToString(reader["FirstName"]);
            user.LastName = Convert.ToString(reader["LastName"]);
            user.Phone = Convert.ToString(reader["Phone"]);
            user.Email = Convert.ToString(reader["Email"]);
            user.Reviewer = Convert.ToBoolean(reader["Reviewer"]);
            user.Admin = Convert.ToBoolean(reader["Admin"]);
            reader.Close();
            return user;

        }

        public List<User> UserGetAll() {
            if (sqlConn == null) {
                throw new Exception("No Connection!");
            }
            var sql = "SELECT * From [User];";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            var reader = sqlcmd.ExecuteReader();
            var users = new List<User>();
            while (reader.Read()) {
                var user = new User();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Username = Convert.ToString(reader["Username"]);
                user.FirstName = Convert.ToString(reader["FirstName"]);
                user.LastName = Convert.ToString(reader["LastName"]);
                user.Phone = Convert.ToString(reader["Phone"]);
                user.Email = Convert.ToString(reader["Email"]);
                user.Reviewer = Convert.ToBoolean(reader["Reviewer"]);
                user.Admin = Convert.ToBoolean(reader["Admin"]);
                users.Add(user);
            }
            reader.Close();
            return users;
        }
        public void Connect(string server, string database) {
            var connStr = $"server={server};"
                        + $"database={database};"
                        + $"trusted_connection=true;";
            sqlConn = new SqlConnection(connStr);
            sqlConn.Open();
            if (sqlConn.State != System.Data.ConnectionState.Open) {
                throw new Exception("Connection did not open!");
            }

        }
        public void Disconnect() {
            if (sqlConn.State == System.Data.ConnectionState.Open) {
                sqlConn.Close();
            }
            sqlConn = null;
        }
    }
}
