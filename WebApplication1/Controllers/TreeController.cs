using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;
using WebApplication1.App_Start;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

    public class TreeController : ApiController
    {

        private MongoDBContext dbContext;
        private IMongoCollection<NGTreeNode> collection;

        public TreeController()
        {
            dbContext = new MongoDBContext();
            collection = dbContext.database.GetCollection<NGTreeNode>("Nodes");

        }


        // GET: api/tree
        public async Task<IEnumerable<NGTreeNode>> Get()
        {
            List<NGTreeNode> result = await collection.Find(_ => true).ToListAsync();
          
            return (result);
        }

             
        
        // GET: api/tree/5
        public async Task<NGTreeNode>  Get(int id)
        {           
            return await collection.Find(x => x.Id == id).FirstOrDefaultAsync(); 
        }
        
        // POST: api/tree
        public async Task<object> Post([FromBody] NGTreeNode ngTree)
        {
            if (ngTree.text == "" || ngTree.text== null )  return BadRequest("invalid vlaue"); 
            
            await collection.InsertOneAsync(ngTree);
            return Ok();                                
        }

        // PUT: api/tree/5
        public async Task<object> Put([FromBody]  NGTreeNode node)
        {
            if (node == null ) return BadRequest("invalid value");
            await collection.ReplaceOneAsync(x => x.Id == node.Id, node);
            return Ok();
        }

        // DELETE: api/tree/5
        public async Task Delete(int id)
        {           
            await collection.DeleteOneAsync(x => x.Id == id);
        }
    }

}
