﻿using Microsoft.Extensions.Logging;
using sSandovalS5.Utils;

namespace sSandovalS5
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
            string dbPath = FileAccessHelper.GetLocalFilePanth("personas.db3");
            builder.Services.AddSingleton<PersonRepository>(s =>
            ActivatorUtilities.CreateInstance<PersonRepository>(s,dbPath));
            return builder.Build();
        }
    }
}
