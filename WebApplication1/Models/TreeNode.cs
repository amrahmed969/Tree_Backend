using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    public class NGTreeNode
    {
        [BsonId]
        public int Id { get; set; }
        [Required]
        public string text { get; set; }
        
        public int? parent { get; set; }
    }

}