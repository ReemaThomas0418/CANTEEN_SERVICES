using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Canteen.Models
{
    public class DishesInfo
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Menu { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        [BsonElement("PreparationTime")]
        public string PreparationTime { get; set; }

        public bool IsActive { get; set; }

        public AvailabilityInfo Availability { get; set; }
    }
}