using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.EventHubs.Processor;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace HubDeEventos_Reciver 
{ 

    class Program
    {
        static void Main(string[] args)
        {
            string eventHubConnectionString = "";
            string eventHubName = "";
            string storageAccountname = "";
            string storageAccountKey = "";
            string storageConnectionString = "";
            string eventProcessHostName = Guid.NewGuid().ToString();
            EventProcessorHost eventProcessorHost = new EventProcessorHost(@"https://learn-event.servicebus.windows.net:443/", eventProcessHostName, eventHubName, EventHubConsumerGroup.DefaultGroupName, eventHubConnectionString);
            eventProcessorHost.RegisterEventProcessorAsync<EventHubEventProcessor>()
                              .Wait();
            Console.WriteLine("Reciving. Press enter key to stop worker");
            Console.ReadLine();
            eventProcessorHost.UnregisterEventProcessorAsync().Wait();
        }
    }
}