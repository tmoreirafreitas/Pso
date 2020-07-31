namespace Pso.Domain.Interfaces.Repositories.NoSqlMongoDb
{
    public interface IPsoDbMongoDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
