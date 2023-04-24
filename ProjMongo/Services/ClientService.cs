using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjMongo.Config;
using ProjMongo.Models;

namespace ProjMongo.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Cliente> _client;

        public ClientService(IProjMDSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _client = database.GetCollection<Cliente>(settings.ClientCollectionName);

        }
        public List<Cliente> Get()
        {
            // setando o true para pegar todos os registros
            return _client.Find(c => true).ToList();
        }
        public Cliente Get(string id)
        {
            return _client.Find(c => c.Id == id).FirstOrDefault();
        }
        public Cliente Create(Cliente client)
        {
            _client.InsertOne(client);
            return client;
        }
        public void Update(string id, Cliente client)
        {
            _client.ReplaceOne(c => client.Id == c.Id, client);
        }
        public void Delete(Cliente client)
        {
            _client.DeleteOne(c => c.Id == client.Id);
        }
        public void Delete(string id) => _client.DeleteOne(c => c.Id == id);
        // public void Delete (Cliente id) => _client.DeleteOne(c => c.Id == id)
   }
}
