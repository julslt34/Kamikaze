using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Kamikaze.Models;
using Kamikaze.Utils;
using Kamikaze.Repositories;
using Microsoft.Data.SqlClient;



namespace Kamikaze.Repositories
{
    public class DestinationRepository : BaseRepository, IDestinationRepository
    {

        public DestinationRepository(IConfiguration configuration) : base(configuration) { }

        public List<Destination> GetAllDestinations()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT d.Id, d.DestinationName, d.CategoryId, d.ImageLocation, d.Description, c.[Name] as CategoryName                
                                        FROM Destination d
                                        LEFT JOIN Category c on d.CategoryId = c.Id";

                   
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Destination> destinations = new List<Destination>();
                    while (reader.Read())
                    {
                        Destination destination = new Destination()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            DestinationName = reader.GetString(reader.GetOrdinal("DestinationName")),
                            CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                            ImageLocation = reader.GetString(reader.GetOrdinal("ImageLocation")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Category = new Category()                            
                             {
                                Id = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                Name = reader.GetString(reader.GetOrdinal("CategoryName"))
                            },
                        };
                        //destination.Category.Name = reader.GetString(reader.GetOrdinal("CategoryName"));

                        destinations.Add(destination);
                    }

                    reader.Close();

                    return destinations;
                }
            }
        }


        public Destination GetDestinationById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT d.Id, d.DestinationName, d.CategoryId, d.ImageLocation, d.Description, c.[Name] as CategoryName                
                                        FROM Destination d
                left join Category c on d.CategoryId = c.id                
                where d.id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Destination destination = null;

                    while (reader.Read())
                    {
                        if (destination == null)
                        {

                            destination = new Destination()
                            {
                               Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            DestinationName = reader.GetString(reader.GetOrdinal("DestinationName")),
                            CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                            ImageLocation = reader.GetString(reader.GetOrdinal("ImageLocation")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Category = new Category()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                Name = reader.GetString(reader.GetOrdinal("CategoryName"))
                            },
                            };
                        //destination.Category.Name = reader.GetString(reader.GetOrdinal("CategoryName"));
                           
                        }
                                              
                    }

                    reader.Close();

                    return destination;
                }
            }
        }


        public List<Destination> GetDestinationByCategory(int CategoryId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT d.Id, d.DestinationName, d.CategoryId, d.ImageLocation, d.Description, c.Id, c.[Name] as CategoryName  

                    FROM Destination d
                   JOIN Category c on d.CategoryId = c.Id";


                    cmd.Parameters.AddWithValue("id", CategoryId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Destination> destinations = new List<Destination>();
                    while (reader.Read())
                    {
                        Destination destination = new Destination()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            DestinationName = reader.GetString(reader.GetOrdinal("DestinationName")),
                            CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                            ImageLocation = reader.GetString(reader.GetOrdinal("ImageLocation")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Category = new Category()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                Name = reader.GetString(reader.GetOrdinal("CategoryName"))
                            },
                        };

                        destination.Category.Name = reader.GetString(reader.GetOrdinal("CategoryName"));

                        destinations.Add(destination);
                    }

                    reader.Close();

                    return destinations;
                }
            }
        }



    }
}
