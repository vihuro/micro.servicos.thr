using Microsoft.EntityFrameworkCore;
using THR.OBRA.NOTAS.ContextBase;
using THR.OBRA.NOTAS.Interface;
using THR.OBRA.NOTAS.Service.Mapping;
using THR.OBRA.NOTAS.Service.Mapping.NotaTHR;
using THR.OBRA.NOTAS.Service.Mapping.Usuario;
using THR.OBRA.NOTAS.Service.NotasRadar;
using THR.OBRA.NOTAS.Service.NotasTHR;
using THR.OBRA.NOTAS.Service.Time;
using THR.OBRA.NOTAS.Service.Usuario;
using THR.OBRA.NOTAS.Utils;
using THR.ObraNotas.Interface;
using THR.ObraNotas.Service.Usuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(typeof(NotaTHRMapping));
    x.AddProfile(typeof(UsuarioMappging));
    x.AddProfile(typeof(TimeMapping));
});

//context
var connectionString = builder.Configuration.GetConnectionString("obra.notas");
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Context>(op =>
    {
        op.UseNpgsql(connectionString);
    });

//services

builder.Services.AddScoped<IUsuarioAUTHService, UsuarioAUTHService>();
builder.Services.AddScoped<INotaRADARService, NotasRadarService>();
builder.Services.AddScoped<INotaTHRService, NotasTHRService>();
builder.Services.AddScoped<IUsuarioOBRAService, UsuarioOBRAService>();
builder.Services.AddScoped<ITimeService, TimeService>();
builder.Services.AddScoped<ReaderFile>();
builder.Services.AddScoped<VerifyPlatform>();

var environment = builder.Environment.EnvironmentName;

var filePath = builder.Configuration.Get<FilePath>();
filePath.Caminho = builder.Configuration.GetSection("variables:FileNOTA")[environment];
builder.Services.AddSingleton(filePath);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
