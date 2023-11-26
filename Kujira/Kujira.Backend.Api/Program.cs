using Kujira.Backend.Company.Domain;
using Kujira.Backend.Company.Persistence;
using Ory.Client.Api;
using Ory.Client.Client;
using Kujira.Backend.Shared.Persistence;
using Kujira.Backend.User.Domain;
using Kujira.Backend.User.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//// configure http port explicitly to override generated settings from launchSettings.json
//builder.WebHost.ConfigureKestrel(opt => {
//    var port = builder.Configuration.GetValue<int>("APP_PORT", 5001);
//    opt.ListenAnyIP(port);
//});

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
builder.Services.AddScoped<ICompanyTypeRepository, CompanyTypeRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IZipRepository, ZipRepository>();

builder.Services.AddDbContext<KujiraContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options => { options.AddDefaultPolicy(builder => { builder.WithOrigins("https://localhost:7262").AllowAnyHeader().AllowAnyMethod(); }); });


var app = builder.Build();

//// create a new Ory Client with the BasePath set to the Ory Tunnel enpoint
//var oryBasePath = builder.Configuration.GetValue<string>("ORY_BASEPATH") ?? "http://localhost:4000";
//var ory = new FrontendApi(new Configuration
//{
//    BasePath = oryBasePath
//});

// add session middleware
//app.Use(async (ctx, next) =>
//{
//    async Task Login()
//    {
//        // this will redirect the user to the managed Ory Login UI
//        var flow = await ory.CreateBrowserLoginFlowAsync() ?? throw new InvalidOperationException("Could not create browser login flow");
//        ctx.Response.Redirect(flow.RequestUrl);
//    }

//    try
//    {
//        // check if we have a session
//        var session = await ory.ToSessionAsync(cookie: ctx.Request.Headers.Cookie, cancellationToken: ctx.RequestAborted);
//        if (session?.Active is not true)
//        {
//            await Login();
//            return;
//        }

//        // add session to HttpContext
//        ctx.Items["req.session"] = session;
//    }
//    catch (ApiException)
//    {
//        await Login();
//        return;
//    }

//    await next(ctx);
//});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();