using System.Threading.Channels;

namespace Channels
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Create a bounded channel with a capacity of 10
            var channel = Channel.CreateBounded<string>(10);

            var producer = ProduceDataAsync(channel.Writer);
            var consumer = ConsumeDataAsync(channel.Reader);

            // Run both tasks concurrently
            await Task.WhenAll(producer, consumer);

            Console.WriteLine("All tasks completed.");
        }

        // --- Paste Producer and Consumer methods here ---
        public static async Task ProduceDataAsync(ChannelWriter<string> writer)
        {
            for (int i = 0; i < 20; i++)
            {
                string data = $"Work item #{i}";
                Console.WriteLine($"[Producer] Writing: {data}");

                // Asynchronously write to the channel.
                // If the channel is bounded and full, this will wait.
                await writer.WriteAsync(data);

                await Task.Delay(100); // Simulate some work
            }

            // Signal that we are done writing.
            writer.Complete();
            Console.WriteLine("[Producer] Finished writing.");
        }

        public static async Task ConsumeDataAsync(ChannelReader<string> reader)
        {
            Console.WriteLine("[Consumer] Starting to read...");

            // This loop will continue as long as the channel is open and has data.
            // It will complete automatically when the producer calls writer.Complete().
            await foreach (var data in reader.ReadAllAsync())
            {
                Console.WriteLine($"[Consumer] Processing: {data}");
                await Task.Delay(200); // Simulate processing work
            }

            Console.WriteLine("[Consumer] Channel is empty and closed.");
        }
    }
}
