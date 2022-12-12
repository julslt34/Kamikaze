using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Kamikaze.Models;
using Kamikaze.Utils;
using Microsoft.Data.SqlClient;

namespace Kamikaze.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }


        public List<User> GetAllUsers()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            SELECT Id, UserName, Email, YearEstablished                           
                            FROM [User]";
                               
                    var reader = cmd.ExecuteReader();

                    var users = new List<User>();
                    while (reader.Read())
                    {
                        users.Add(new User()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserName = DbUtils.GetString(reader, "UserName"),                  
                            Email = DbUtils.GetString(reader, "Email"),
                            YearEstablished = DbUtils.GetString(reader, "YearEstablished")
                        });
                    }

            reader.Close();

            return users;
                }
            }
         }
        

        public User GetUserByEmail(string email)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT Id, UserName, Email, YearEstablished  
                          FROM [User] 
                          WHERE Email = @email";
                    cmd.Parameters.AddWithValue("@email", email);



                    var reader = cmd.ExecuteReader();

                    User user = null;
                    if (reader.Read())
                    {
                        user = new User()
                        {
                             Id = DbUtils.GetInt(reader, "Id"),
                             UserName = DbUtils.GetString(reader, "UserName"),
                             Email = DbUtils.GetString(reader, "Email"),
                             YearEstablished = DbUtils.GetString(reader, "YearEstablished")
                        };
                     }

                     reader.Close();

                     return user;
                }
            }
        }

        public User GetUserById(int id)
{
        using (var conn = Connection)
      {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = @"
                          SELECT Id, UserName, Email, YearEstablished  
                            FROM [User]
                           WHERE Id = @Id";

            DbUtils.AddParameter(cmd, "@Id", id);

            var reader = cmd.ExecuteReader();

            User singleUser = null;
            if (reader.Read())
            {
                singleUser = new User()
                {
                    Id = id,
                    UserName = DbUtils.GetString(reader, "UserName"),
                    Email = DbUtils.GetString(reader, "Email"),
                    YearEstablished = DbUtils.GetString(reader, "YearEstablished")
                };
            }

            reader.Close();

            return singleUser;
        }
    } 
        
        }
   }
}
    

