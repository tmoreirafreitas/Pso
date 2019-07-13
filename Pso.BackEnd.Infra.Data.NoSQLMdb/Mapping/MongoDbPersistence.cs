namespace Pso.BackEnd.Infra.Data.NoSQLMdb.Mapping
{
    public class MongoDbPersistence
    {
        public static void Configure()
        {            
            ClienteMap.Configure();
            ContatoMap.Configure();
            EnderecoMap.Configure();
            EntityBaseMap.Configure();
            FaturaMap.Configure();
            LenteMap.Configure();
            OculosMap.Configure();
            ParcelaMap.Configure();
            PedidoMap.Configure();
            PedidoOculosMap.Configure();
        }
    }
}
