

using CQRSApp.Context;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);
var app = builder.Build();
Configure(app, builder.Environment);

static void ConfigureServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddControllers();
    services.AddMediatR(typeof(Program));
    services.AddSingleton<PostgreDbContext>();
    //var mapperConfig = new MapperConfiguration(mc =>
    //{
    //    mc.AddProfile(new QuizProfile());
    //});

    //IMapper mapper = mapperConfig.CreateMapper();
    //services.AddSingleton(mapper);
}

static void Configure(WebApplication app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRSApp.Service v1");
            c.RoutePrefix = string.Empty;
        });
    }

    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

    app.Run();
}


//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run();


