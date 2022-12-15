using Kamikaze.Models;
using Kamikaze.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Kamikaze.Repositories;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Hosting;
using System;




 namespace Kamikaze.Repositories
{
    public class TripPlanRepository : BaseRepository, ITripPlanRepository
    {
        public TripPlanRepository(IConfiguration configuration) : base(configuration) { }
       
        public List<TripPlan> GetAllTripPlans()

        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT t.Id, t.UserId, t.DestinationId, t.Notes, t.TripDate, d.DestinationName, d.CategoryId, d.Description, d.ImageLocation, u.UserName, u.Email, u.YearEstablished            
                                        FROM TripPlan t
                                        LEFT JOIN Destination d on t.DestinationId = d.Id
                                        LEFT JOIN [User] u on t.UserId = u.Id";


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<TripPlan> tripPlans = new List<TripPlan>();
                    while (reader.Read())
                    {
                        TripPlan tripPlan = new TripPlan()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            DestinationId = reader.GetInt32(reader.GetOrdinal("DestinationId")),
                            Notes = reader.GetString(reader.GetOrdinal("Notes")),
                            TripDate = reader.GetString(reader.GetOrdinal("TripDate")),
                            User = new User()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                YearEstablished = reader.GetString(reader.GetOrdinal("YearEstablished")),
                            },
                            Destination = new Destination()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("DestinationId")),
                                DestinationName = reader.GetString(reader.GetOrdinal("DestinationName")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                ImageLocation = reader.GetString(reader.GetOrdinal("ImageLocation")),
                            },
                        };

                        tripPlans.Add(tripPlan);
                    }

                    reader.Close();

                    return tripPlans;
                }
            }
        }



        public TripPlan GetTripPlanById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT t.Id, t.UserId, t.DestinationId, t.Notes, t.TripDate, d.DestinationName, d.CategoryId, d.Description, d.ImageLocation, u.UserName, u.Email, u.YearEstablished            
                                        FROM TripPlan t
                                        LEFT JOIN Destination d on t.DestinationId = d.Id
                                        LEFT JOIN [User] u on t.UserId = u.Id";

                    DbUtils.AddParameter(cmd, "@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    TripPlan tripPlan = null;
                    while (reader.Read())
                    {
                        tripPlan = new TripPlan()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            DestinationId = reader.GetInt32(reader.GetOrdinal("DestinationId")),
                            Notes = reader.GetString(reader.GetOrdinal("Notes")),
                            TripDate = reader.GetString(reader.GetOrdinal("TripDate")),
                            User = new User()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                YearEstablished = reader.GetString(reader.GetOrdinal("YearEstablished")),
                            },
                            Destination = new Destination()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("DestinationId")),
                                DestinationName = reader.GetString(reader.GetOrdinal("DestinationName")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                ImageLocation = reader.GetString(reader.GetOrdinal("ImageLocation")),
                            },
                        };
                    }

                    reader.Close();

                    return tripPlan;
                }
            }
        }


        public void Insert(TripPlan tripPlan)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO TripPlan (UserId, DestinationId, Notes, TripDate)
                        OUTPUT INSERTED.ID
                        VALUES (@UserId, @DestinationId, @Notes, @TripDate)";
                    cmd.Parameters.AddWithValue("@UserId", tripPlan.UserId);
                    cmd.Parameters.AddWithValue("@DestinationId", tripPlan.DestinationId);
                    cmd.Parameters.AddWithValue("@Notes", tripPlan.Notes);
                    cmd.Parameters.AddWithValue("@TripDate", tripPlan.TripDate);

                    tripPlan.Id = (int)cmd.ExecuteScalar();
                }
            }
        }


        public void Update(TripPlan tripPlan)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            UPDATE TripPlan 
                                    SET
                                          UserId = @UserId,
                                          DestinationId = @DestinationId,                                        
                                          Notes = @Notes,
                                          TripDate = @TripDate
                                    WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@UserId", tripPlan.UserId);
                    cmd.Parameters.AddWithValue("@DestinationId", tripPlan.DestinationId);                    
                    cmd.Parameters.AddWithValue("@Notes", tripPlan.Notes);
                    cmd.Parameters.AddWithValue("@TripDate", tripPlan.TripDate);
                    cmd.Parameters.AddWithValue("@id", tripPlan.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM TripPlan WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

}
