using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Canteen.Models
{
    public class Status
    {
        public string Result { get; set; }
        
        public string Message { get; set; }

    }
}