﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAPI.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalPhone { get; set; }
        public string WorkPhone { get; set; }
        public string PersonalEmail { get; set; }
        public string WorkEmail { get; set; }  
        public bool IsFullTime { get; set; }
        public double HoursPerWeek { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Employee()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        // Additional properties and methods can be added as needed
    }
}
