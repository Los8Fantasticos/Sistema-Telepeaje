using Microsoft.OpenApi.Models;

using System.Globalization;

namespace MinimalAPI_Reconocimiento.Configurations
{
    public static class SwaggerConfig
    {
        public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
        {
            //#region Logging

            //_ = builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
            //{
            //    var assembly = Assembly.GetEntryAssembly();

            //    _ = loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration)
            //            .Enrich.WithProperty("Assembly Version", assembly?.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version)
            //            .Enrich.WithProperty("Assembly Informational Version", assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion);
            //});

            //#endregion Logging

            //#region Serialisation

            //_ = builder.Services.Configure<JsonOptions>(opt =>
            //{
            //    opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //    opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            //    opt.SerializerOptions.PropertyNameCaseInsensitive = true;
            //    opt.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //    opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            //});

            //#endregion Serialisation

            #region Swagger

            var ti = CultureInfo.CurrentCulture.TextInfo;

            _ = builder.Services.AddEndpointsApiExplorer();
            _ = builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = $"MinimalAPI_Reconocimiento - {ti.ToTitleCase(builder.Environment.EnvironmentName)} ",
                        Description = "API reconocimiento para sistema de peaje",
                        Contact = new OpenApiContact
                        {
                            Name = "MinimalAPI_Reconocimiento",
                            Email = "asd@asd.com",
                            Url = new Uri("https://github.com/stphnwlsh/cleanminimalapi")
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "CleanMinimalApi API - License - MIT",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        },
                        TermsOfService = new Uri("https://github.com/stphnwlsh/cleanminimalapi")
                    });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                options.EnableAnnotations();
                options.DocInclusionPredicate((name, api) => true);
            });

            #endregion Swagger

            #region Project Dependencies

            _ = builder.Services.AddInfrastructure();
            _ = builder.Services.AddApplication();

            #endregion Project Dependencies

            return builder;
        }
    }
}
