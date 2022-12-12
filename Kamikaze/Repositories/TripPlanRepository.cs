using Kamikaze.Models;
using Kamikaze.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Kamikaze.Repositories;
using System.Data.SqlClient;
using System.Configuration;




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
                    cmd.CommandText = @"SELECT t.Id, t.UserId, t.DestinationId, t.Notes, t.TripDate            
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
                           //User = new User()
                           // {
                           //     Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                           //     UserName = reader.GetString(reader.GetOrdinal("UserName")),
                           //     Email = reader.GetString(reader.GetOrdinal("UserEmail")),
                           //     YearEstablished = reader.GetString(reader.GetOrdinal("UserYearEstablished")),
                           // },
                           // Destination = new Destination()
                           // {
                           //     Id = reader.GetInt32(reader.GetOrdinal("DestinationId")),
                           //     DestinationName = reader.GetString(reader.GetOrdinal("DestinationName")),
                           //     CategoryId = reader.GetInt32(reader.GetOrdinal("DestinationId")),
                           //     Description = reader.GetString(reader.GetOrdinal("DestinationDescription")),
                           // },
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
                SELECT t.Id, t.UserId, t.DestinationId, t.Notes, t.TripDate            
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
                            //User = new User()
                            //{
                            //    Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                            //    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                            //    Email = reader.GetString(reader.GetOrdinal("UserEmail")),
                            //    YearEstablished = reader.GetString(reader.GetOrdinal("UserYearEstablished")),
                            //},
                            //Destination = new Destination()
                            //{
                            //    Id = reader.GetInt32(reader.GetOrdinal("DestinationId")),
                            //    DestinationName = reader.GetString(reader.GetOrdinal("DestinationName")),
                            //    CategoryId = reader.GetInt32(reader.GetOrdinal("DestinationId")),
                            //    Description = reader.GetString(reader.GetOrdinal("DestinationDescription")),
                            //},
                        };
                    }

                    reader.Close();

                    return tripPlan;
                }
            }
        }

    }

}
