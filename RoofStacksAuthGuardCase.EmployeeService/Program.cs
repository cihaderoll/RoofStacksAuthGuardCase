using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RoofStacksAuthGuardCase.EmployeeService.Context;
using RoofStacksAuthGuardCase.EmployeeService.Services.Abstract;
using RoofStacksAuthGuardCase.EmployeeService.Services.Concrete;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region authorizing by own created identity server 

//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

//builder.Services.AddAuthentication(config =>
//{
//    config.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    config.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
//     .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
//     {
//         // this is my Authorization Server Port
//         options.Authority = "https://localhost:7178"; //TODO port düzenle
//         options.ClientId = "EmployeeWebAPI";
//         options.ClientSecret = "3df7f9e3-e426-4674-8954-eff2ba000a6b";
//         options.ResponseType = "code";
//         options.CallbackPath = "/signin-oidc";
//         options.SaveTokens = true;
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = false,
//             SignatureValidator = delegate (string token, TokenValidationParameters validationParameters)
//             {
//                 var jwt = new JwtSecurityToken(token);
//                 return jwt;
//             },
//         };
//     });

#endregion authorizing by own created identity server 

builder.Services
               .AddAuthentication("Bearer")
               .AddJwtBearer("Bearer", config =>
               {
                   config.Authority = "https://localhost:7178/";

                   config.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateAudience = false
                   };
               });

// Add services to the container.
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddDbContext<AppDbContext>(
                    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .UseSnakeCaseNamingConvention());

builder.Services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

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
