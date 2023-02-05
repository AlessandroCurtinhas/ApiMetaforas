using Metaforas.Application.Interfaces;
using Metaforas.Application.Services;
using Metaforas.Domain.Interfaces.Repositories;
using Metaforas.Domain.Interfaces.Services;
using Metaforas.Domain.Services;
using Metaforas.Infra.Contexts;
using Metaforas.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion

#region DbContext
var connectionString = builder.Configuration.GetConnectionString("ApiMetaforas");

builder.Services.AddDbContext<ServerContext>(options => options.UseNpgsql(connectionString));

#endregion

#region Swagger

builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "MetaforasUserID.API", Version = "v1" });
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
    }

);

#endregion

#region Injeções de Depedencia DomainServices

builder.Services.AddScoped<IPensadorService, PensadorService>();
builder.Services.AddScoped<IPensadorTimeService, PensadorTimeService>();
builder.Services.AddScoped<IFraseService, FraseService>();
builder.Services.AddScoped<ITimeService, TimeService>();


#endregion

#region Injeções de Depedencia Applications


builder.Services.AddScoped<IPensadorApplicationService, PensadorApplicationService>();
builder.Services.AddScoped<IFraseApplicationService, FraseApplicationService>();
builder.Services.AddScoped<ITimeApplicationService, TimeApplicationService>();
builder.Services.AddScoped<IPensadorTimeApplicationService, PensadorTimeApplicationService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

#endregion

#region Injeções de Depedencia Repositorios

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPensadorRepository, PensadorRepository>();
builder.Services.AddScoped<IFraseRepository, FraseRepository>();
builder.Services.AddScoped<ITimeRepository, TimeRepository>();
builder.Services.AddScoped<IPensadorTimeRepository, PensadorTimeRepository>();


#endregion

#region JWT
var secretKey = builder.Configuration.GetSection("JWTService").GetSection("secretKey").Value;

builder.Services.AddAuthentication(
    auth =>
    {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    ).AddJwtBearer(bearer =>
    {
        bearer.RequireHttpsMetadata = false;
        bearer.SaveToken = true;
        bearer.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


#endregion




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
