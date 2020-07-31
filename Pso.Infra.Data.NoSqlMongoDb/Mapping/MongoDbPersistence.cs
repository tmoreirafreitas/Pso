namespace Pso.Infra.Data.NoSqlMongoDb.Mapping
{
    public class MongoDbPersistence
    {
        public static void Configure()
        {
            EntityMap.Configure();
            new ClienteMap().Configure();
            new ContatoMap().Configure();
            new EnderecoMap().Configure();
            new FaturaMap().Configure();
            new LenteMap().Configure();
            new OculosMap().Configure();
            new ParcelaMap().Configure();
            new PedidoMap().Configure();
            new PedidoOculosMap().Configure();
        }
    }
}
