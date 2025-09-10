using Microsoft.Extensions.Logging;
using SQLite;
using HomeCareAI.Models;
using System.IO;

namespace HomeCareAI
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
            // test: create db and table
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "test.db3");
            using var db = new SQLiteConnection(dbPath);
            db.CreateTable<TodoItem>();
            db.Insert(new TodoItem { Name = "First Task", IsDone = false });

            return builder.Build();
        }
    }
}
