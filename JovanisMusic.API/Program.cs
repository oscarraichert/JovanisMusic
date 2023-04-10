using Jovani_sMusic.Application;
using YoutubeExplode;

namespace JovanisMusic.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<SearchServices>();
            builder.Services.AddTransient<YoutubeClient>();
            builder.Services.AddTransient<DownloadServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapPost("/downloadsongs", async (SearchServices searchServices, List<string> songs) =>
            {
                await searchServices.GetSongs(songs);
            })
            .WithName("DownloadSongs");

            app.Run();
        }
    }
}