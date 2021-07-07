using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace SqlServerLibrary
{
    public class SqlServerLib
    {
        SqlConnection sqlConn = null;

        public List<Vendor> VendorGetAll()
        {
            {
                if (sqlConn == null)
                {
                    throw new Exception("No Connection!");
                }
                var sql = "SELECT * From Vendor;";
                var sqlcmd = new SqlCommand(sql, sqlConn);
                var reader = sqlcmd.ExecuteReader();
                var vendors = new List<Vendor>();
                while (reader.Read())
                {
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

        public User UserGetByPK(int Id)
        {
            if (sqlConn == null)
            {
                throw new Exception("No Connection!");
            }
            var sql = "SELECT * From [User] Where Id = @Id";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.Parameters.AddWithValue("@Id", Id);
            var reader = sqlcmd.ExecuteReader();
            if(!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            reader.Read();
            var user = new User();
            user.Id = Convert.ToInt32(reader["Id"]);
            user.Username = Convert.ToString(reader["Username"]);
            user.FirstName = Convert.ToString(reader["FirstName"]);
            user.LastName = Convert.ToString(reader["LastName"]);
            user.Phone = Convert.ToString(reader["Phone"]);
            user.Email = Convert.ToString(reader["Email"]);
            user.Reviewer = Convert.ToBoolean(reader["Reviewer"]);
            user.Admin = Convert.ToBoolean(reader["Admin"]);
            return user;

        }

        public List<User> UserGetAll()
        {
            if (sqlConn == null)
            {
                throw new Exception("No Connection!");
            }
            var sql = "SELECT * From [User];";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            var reader = sqlcmd.ExecuteReader();
            var users = new List<User>();
            while (reader.Read())
            {
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
        public void Connect(string server, string database)
        { 
            var connStr = $"server={server};" 
                        + $"database={database};"
                        + $"trusted_connection=true;";
            sqlConn = new SqlConnection(connStr);
            sqlConn.Open();
            if(sqlConn.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("Connection did not open!");
            }

        }
        public void Disconnect()
        {
            if(sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
    sqlConn = null;
        }
    }
}
