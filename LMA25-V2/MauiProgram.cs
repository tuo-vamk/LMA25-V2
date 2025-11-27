using LMA25_V2.Interfaces;
using LMA25_V2.Pages;
using LMA25_V2.Persistence;
using LMA25_V2.Services;
using LMA25_V2.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace LMA25_V2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Register HttpClient
            builder.Services.AddHttpClient();


            // Register DbContext with SQLite
            // Run in app-project folder:
            // dotnet ef migrations add InitialCreate --project ..\Persistence --startup-project .
            // dotnet ef database update --project ..\Persistence --startup-project .
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Filename={Path.Combine(FileSystem.AppDataDirectory, "app.db")}"));

            // Register ViewModels
            //MainPage and MainViewModel → Singleton because they are the app’s root.
            //NotesPage and NotesViewModel → Transient because they are created on navigation.
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<NotesViewModel>();

            // Register Pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<NotesPage>();

            //Services:
            builder.Services.AddSingleton<INoteService, NoteService>();
            builder.Services.AddSingleton<IJokeService, JokeServiceJokeDevApi>();

            return builder.Build();
        }
    }
}
