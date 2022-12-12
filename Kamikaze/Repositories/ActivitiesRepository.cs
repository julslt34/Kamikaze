using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Kamikaze.Models;
using Kamikaze.Utils;
using Microsoft.Data.SqlClient;
using Kamikaze.Repositories;


namespace Kamikaze.Repositories
{
    public class ActivitiesRepository : BaseRepository, IActivitiesRepository
    {
        public ActivitiesRepository(IConfiguration config) : base(config) { }

        public List<Activities> GetAllActivities()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, DestinationId as ActivitiesDestinationId, Content, ImageLocation, ActivityLink
                                        FROM Activities";


                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Activities> allActivities = new List<Activities>();

                    while (reader.Read())
                    {
                        allActivities.Add(new Activities()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            DestinationId = reader.GetInt32(reader.GetOrdinal("ActivitiesDestinationId")),                            
                            Content = reader.GetString(reader.GetOrdinal("Content")),  
                            ImageLocation = reader.GetString(reader.GetOrdinal("ImageLocation")), 
                            ActivityLink = reader.GetString(reader.GetOrdinal("ActivityLink")), 
                           
                        });

                    }
                    reader.Close();
                    return allActivities;
                }
            }
        }

        public Activities GetActivitiesById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, DestinationId as ActivitiesDestinationId, Content, ImageLocation, ActivityLink
                                        FROM Activities 
                                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Activities activities = new Activities
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            DestinationId = reader.GetInt32(reader.GetOrdinal("ActivitiesDestinationId")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            ImageLocation = reader.GetString(reader.GetOrdinal("ImageLocation")),
                            ActivityLink = reader.GetString(reader.GetOrdinal("ActivityLink")),

                        };
                        reader.Close();
                        return activities;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

    }
}


