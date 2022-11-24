using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Configuration;

namespace WebApplication1.App_Start
{
    public class MongoDBContext
    {
        MongoClient client;
        public IMongoDatabase database;
        public MongoDBContext()
        {
            var mongoClint = new MongoClient(ConfigurationManager.AppSettings["MongoDBHost"]);
            database = mongoClint.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);
        }
    }
}