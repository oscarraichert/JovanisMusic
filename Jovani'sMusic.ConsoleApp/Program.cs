namespace Jovani_sMusic.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("insira o link do video: ");
            var link = Console.ReadLine();

            DownloadServices.DownloadFromLink(link);
        }
    }
}