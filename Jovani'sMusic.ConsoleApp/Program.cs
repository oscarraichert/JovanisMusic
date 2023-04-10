using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Jovani_sMusic.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new();
            List<string> list = new();

            httpClient.Timeout = TimeSpan.FromDays(1);

            Console.WriteLine("procurar vídeo para download (e pressionar [ENTER] para confirmar): " +
                "\nescreva \"baixar\" para fazer o download das musicas na lista.");

            var query = "";

            do
            {
                query = Console.ReadLine();
                list.Add(query);                

            } while (query != "baixar");

            var content = JsonConvert.SerializeObject(list);
            var bytes = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(bytes);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await httpClient.PostAsync($"http://localhost:5019/downloadsongs", byteContent);
        }
    }
}