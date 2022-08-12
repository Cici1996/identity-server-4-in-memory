using AutoWrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sample.API;
using Sample.BusinnesLayer;
using Sample.BusinnesLayer.Contracts;
using Sample.DataAccessLayer;
using Sample.Repository;
using Sample.Repository.Contracts;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

// Add services to the container.

builder.Services.AddControllers();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = builder.Configuration["IdentityServerConfig:URL"];
                    options.Audience = builder.Configuration["IdentityServerConfig:Audience"];
                    options.TokenValidationParameters.NameClaimType = "name";
                    options.TokenValidationParameters.RoleClaimType = "role";
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Sample.API.Oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri($"{builder.Configuration["IdentityServerConfig:URL"]}/connect/authorize"),
                TokenUrl = new Uri($"{builder.Configuration["IdentityServerConfig:URL"]}/connect/token"),
                Scopes = new Dictionary<string, string>
                {
                    { builder.Configuration["IdentityServerConfig:Scope"],"Full Access Api" }
                }
            }
        }
    });
    c.OperationFilter<AuthorizeCheckOperationFilter>();
});
builder.Services.AddDbContext<CoreDBContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IMeetingEventBLL, MeetingEventBLL>();
builder.Services.AddScoped<IMeetingEventRepository, MeetingEventRepository>();
var app = builder.Build();
app.UseApiResponseAndExceptionWrapper();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.OAuthClientId(builder.Configuration["IdentityServerConfig:ClientId"]);
        c.OAuthClientSecret(builder.Configuration["IdentityServerConfig:ClientSecret"]);
        c.OAuthAppName("Sample.API v1");
        c.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();