
using Microsoft.EntityFrameworkCore;

using net8;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddDbContext<UserDb>(opt => {
    //string connstr = builder.Configuration.GetSection("ConnStr").Value;
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});*/
builder.Services.AddDataProtection();
builder.Services.AddScoped<HttpClientManager>();
builder.Services.AddScoped<RandomRead>();
builder.Services.AddScoped<FilterData>();
var app = builder.Build();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



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
