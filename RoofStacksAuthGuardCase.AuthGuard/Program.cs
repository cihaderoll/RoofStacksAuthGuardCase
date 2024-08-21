using Microsoft.Extensions.Configuration;
using RoofStacksAuthGuardCase.AuthGuard.Common;
using RoofStacksAuthGuardCase.AuthGuard.Services.Abstract;
using RoofStacksAuthGuardCase.AuthGuard.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services
.AddIdentityServer()
                .AddInMemoryApiScopes(Configuration.GetApiScopes())
                .AddInMemoryClients(Configuration.GetClients())
                .AddDeveloperSigningCredential();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddScoped<IAuthorizationInformationService, AuthorizationInformationService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.Run();
