
namespace NSB_NHIBERNATE_ORACLE_PROBLEM
{
    using NServiceBus;
    using NServiceBus.Persistence;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<NHibernatePersistence, StorageType.Sagas>();
            configuration.UsePersistence<NHibernatePersistence, StorageType.Subscriptions>();
            configuration.UsePersistence<NHibernatePersistence, StorageType.Timeouts>();
            configuration.UsePersistence<NHibernatePersistence, StorageType.Outbox>();
            configuration.UsePersistence<NHibernatePersistence, StorageType.GatewayDeduplication>();
        }
    }

    public class MyClass : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Bus.Send("NSB_NHIBERNATE_ORACLE_PROBLEM",new NewUser() { Name="Paco"});
        }

     
        
        public void Stop()
        {

        }
    }
}
