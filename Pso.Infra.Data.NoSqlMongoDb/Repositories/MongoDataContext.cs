using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Pso.Infra.Data.NoSqlMongoDb.Repositories
{
    public class MongoDataContext
    {
        public IMongoDatabase MongoDatabase { get; }
        public MongoDataContext(IOptions<PsoDbMongoDatabaseSettings> settings)            
        {
            try
            {
                var mongoClientSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));
                if (settings.Value.IsSSL)
                    mongoClientSettings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                var client = new MongoClient(mongoClientSettings);
                MongoDatabase = client.GetDatabase(settings.Value.DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }
    }
}
