namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class MongoDbPersistence
    {
        public static void Configure()
        {
            EntityBaseMap.Configure();
            ClienteMap.Configure();
            ContatoMap.Configure();
            EnderecoMap.Configure();
            FaturaMap.Configure();
            PedidoMap.Configure();
        }
    }
}
