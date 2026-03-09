using System;
using TaskTracker.Api.Data;
using TrackerTask.Enums;
using TrackerTask.Model;

namespace TaskTracker.Api.Seed
{
    public static class SeedingData
    {
        public static void Seed(DatabaseContext db)
        {
            if (!db.Tasks.Any())
            {
                db.Tasks.AddRange(
                new Item
                {
                    Title = "Start Offeren Project",
                    Description = "Buidling Task seed data. In Progreess",
                    Proirity = Proirity.High,
                    Status = Status.InProgreess,
                    CreatedAt = DateTime.UtcNow
                },
                new Item
                {
                    Title = "Continue Offeren Project",
                    Description = "Buidling Task seed data continued creadted 1 day ago.New",
                    Proirity = Proirity.Medium,
                    Status = Status.New,
                    CreatedAt = DateTime.UtcNow.AddDays(-1)
                },
                new Item
                {
                    Title = "Continue Offeren Project 2",
                    Description = "Buidling Task seed data continued creadted 2 day ago. Done",
                    Proirity = Proirity.Low,
                    Status = Status.Done,
                    CreatedAt = DateTime.UtcNow.AddDays(-2)
                }
            );

                db.SaveChanges();
            }
            
        }
    }
}