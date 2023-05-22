using Microsoft.EntityFrameworkCore;
using THR.auth.Service.Mapper;
using THR.AUTH.DBContext;
using THR.AUTH.Interface;
using THR.AUTH.Service.Claims;
using THR.AUTH.Service.Usuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//context

var connectionString = builder.Configuration.GetConnectionString("auth");
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Context>(op =>
    {
        op.UseNpgsql(connectionString);
    });

//services
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IClaimsService, ClaimsService>();

//mappgin 

builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(typeof(UsuarioCadastroMapping));
    x.AddProfile(typeof(ClaimsCadastroMapping));
});

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
