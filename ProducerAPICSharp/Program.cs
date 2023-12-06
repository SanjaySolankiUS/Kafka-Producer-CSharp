namespace ProducerAPICSharp;
using Confluent.Kafka;
using System;
//using Microsoft.Extensions.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
            Console.WriteLine("Hello, World!");
        ////
            var config = new ProducerConfig {
                        BootstrapServers = "localhost:9092"                        
                        };


            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {

                for(int i=0; i < 10; i++)
                {
                    Console.WriteLine("Hey, How are you " + i);
                    producer.ProduceAsync("ClassAtt", new Message<string, string>(){                        
                        Value = $"Hey, How are you " + i
                    }).Wait();
                }

                producer.Flush(TimeSpan.FromSeconds(10)); 
            }



            Console.Read();
    }
}
