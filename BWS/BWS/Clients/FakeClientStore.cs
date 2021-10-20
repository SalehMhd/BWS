using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BWS.Clients
{
    public class FakeClientStore
    {
        public static List<Client> Clients => new List<Client>()
            {
                new Client
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Saleh Mohammad",                   
                    Email = "salehMohammad@email.com",
                    BWSWeeks = new List<BWSDay>()
                    {
                        new BWSDay2
                        {
                            Name = "Mon",
                            
                            Exercise1 = new Exercise { Name="SN", Reps="30 40 50 60x2x3", CoachComment="Pas Chance :D"},
                            Exercise2 = new Exercise { Name="CJ", Reps="30 50 70 100x2x3", CoachComment="Jambs"},
                        },
                        new BWSDay3
                        {
                            Name = "Tues",
                            Exercise1 = new Exercise { Name="PSN", Reps="20 30 60 70x2x3", CoachComment="Do it well"},
                            Exercise2 = new Exercise { Name="CPJ", Reps="40 60 80 110x2x3", CoachComment="Do it great"},
                            Exercise3 = new Exercise { Name="FSQ", Reps="60 90 120 150x2x3", CoachComment="Perfect it!!"}
                        },
                        new BWSDay3
                        {
                            Name = "Thur",
                            Exercise1 = new Exercise { Name="PSN+SN", Reps="10 20 50 60x2x3", CoachComment="Get it"},
                            Exercise2 = new Exercise { Name="CPJ+J", Reps="50 70 90 120x2x3", CoachComment="Come on"},
                            Exercise3 = new Exercise { Name="FSQ+P", Reps="70 100 130 160x2x3", CoachComment="Let us go!!"}
                        }
                    }
                },
                new Client
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "LastName Dirk",                  
                    Email = "LastNameDirk@email.com",
                },
                new Client
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Maddy Bassett",                    
                    Email = "maddyb@email.com",
                },
                new Client
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lily-May Espinoza",
                    Email = "espinoza@email.com"
                },
                new Client
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Brendon Flynn",
                    Email = "flyn123@email.com",
                },
                new Client
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Nela Velazquez",
                    Email = "vela@email.com",
                }
            };
    }
}
