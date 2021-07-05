using NTLayerArch.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NTLayerArch.Entity;

namespace NTLayerArch
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public string GetUserAdd(UserToAddDto dto)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                string insertQuery = $"Insert into [User](Username,Name,Surname,CreatedAt) values ('{dto.Username}','{dto.Name}','{dto.Surname}','1')";
                using (var command = new SqlCommand(insertQuery, con))
                {
                    command.ExecuteNonQuery();
                }
            }
            return "User added...";
        }

        public string UpdateUser(UserToUpdateDto dto)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                string updateQuery = $"Update [User] set Username = '{dto.Username}', Name = '{dto.Name}', Surname = '{dto.Surname}', UpdatedAt = '1' where Id = {dto.UserId}";
                using (var command = new SqlCommand(updateQuery, con))
                {
                    command.ExecuteNonQuery();
                }
            }
            return "User updated...";
        }

        public string DeleteUser(UserToDeleteDto dto)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                string deleteQuery = $"Update [User] set DeletedAt = '1' where Id = {dto.UserId}";
                using (var command = new SqlCommand(deleteQuery, con))
                {
                    command.ExecuteNonQuery();
                }
            }
            return "User deleted...";
        }

        public List<User> GetUsersList()
        {
            using (var con = new SqlConnection(connectionString))
            {
                string selectListQuery = "Select u.Id,u.Username,u.Name,u.Surname From [User] u where u.DeletedAt = 0";
                DataTable dt = new DataTable();
                List<User> users = new List<User>();
                using (var command = new SqlCommand(selectListQuery, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(selectListQuery,con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        User user = new User();
                        user.UserId = int.Parse(row["Id"].ToString());
                        user.Username = row["Username"].ToString();
                        user.Name = row["Name"].ToString();
                        user.Surname = row["Surname"].ToString();
                        users.Add(user);
                    }
                }
                return users;
            }
        }
    }
}
