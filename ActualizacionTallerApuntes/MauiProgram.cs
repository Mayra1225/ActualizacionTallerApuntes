using ActualizacionTallerApuntes.Services;
using ActualizacionTallerApuntes.ViewModels;
using Microsoft.Extensions.Logging;

namespace ActualizacionTallerApuntes
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddSingleton<NotesViewModel>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<NotesViewModel>();
            builder.Services.AddSingleton<RecordatorioViewModel>();
            builder.Services.AddSingleton<ClimaViewModel>();
            builder.Services.AddSingleton<AboutViewModel>();

            builder.Services.AddSingleton<NoteService>();
            builder.Services.AddSingleton<RecordatorioService>();
            builder.Services.AddSingleton<ClimaService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
