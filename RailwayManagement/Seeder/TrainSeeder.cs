using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RailwayManagement.Entities;

namespace RailwayManagement.Seeder
{
    internal class TrainSeeder
    {
        public static void InitializeTrains()
        {
            List<Train> trains = JsonConvert.DeserializeObject<List<Train>>(File.ReadAllText("E:\\C#\\RailwayManagement\\RailwayManagement\\Seeder\\Trains.json"));

            if(trains.Count > 0)
                using (var context = new RailwayContext())
                {
                    context.Trains.AddRange(trains);
                    context.SaveChanges();
                }
        }
    }
}
