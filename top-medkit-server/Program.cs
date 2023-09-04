using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(c =>
{
    c.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
#if DEBUG
    c.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
#endif
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.DescribeAllParametersInCamelCase();
    c.IncludeXmlComments(Assembly.GetExecutingAssembly().Location[..^3] + "xml");
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(r => r.AllowAnyHeader()
                  .AllowAnyMethod()
#if DEBUG
                  .AllowAnyOrigin()
#else     
                  .SetIsOriginAllowed(x => "domain-names")
                  .AllowCredentials()
#endif
                  );

app.UseAuthorization();

app.MapControllers();

app.Run();
