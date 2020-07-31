namespace Pso.Infra.Data.NoSqlMongoDb.Repositories
{
    public class PsoDbMongoDatabaseSettings
    {
        public string ConnectionString { get ; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; }
    }
}
