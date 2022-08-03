using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeEventos_Reciver
{
    public class EventProcess : IEventProcessor
    {
        

        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Console.WriteLine("Processamento finalizado.");
            return Task.FromResult<object>(null);
        }
        
        public Task OpenAsync(PartitionContext context)
        {
            Console.WriteLine("Processamento iniciado.");
            return Task.FromResult<object>(null);
        }

        async Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (EventData ev in messages)
            {
                string data = Encoding.UTF8.GetString(ev.GetBytes());
                Console.WriteLine($"***ATENÇÃO*** Tanque com PH Ácido: {data}");
            }
        }

        
    }
}
