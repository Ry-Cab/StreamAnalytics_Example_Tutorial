using System;
using Microsoft.ServiceBus.Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HubDeEventos_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var client = Microsoft.ServiceBus.Messaging.EventHubClient.CreateFromConnectionString("", "");

                while (true)
                {
                    var horario = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                    for (int i = 0; i < 10; i++)
                    {
                        var rand = new Random();
                        var data = new
                        {
                            id = i,
                            ph = rand.Next(1, 14),
                            temperatura = rand.Next(18, 30),
                            dataHora = horario,
                        };
                        var jsonData = JsonConvert.SerializeObject(data);
                        client.Send(new Microsoft.ServiceBus.Messaging.EventData(Enconding.UTF8.GetBytes(jsonData)));
                        Console.WriteLine($"Dados enviados: {jsonData}");
                    }
                    System.Threading.Thread.Sleep(1000);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
