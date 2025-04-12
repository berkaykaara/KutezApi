using KutezApi.Model;
using KutezApi.Services;

var builder = WebApplication.CreateBuilder(args);

// GoldApi yapılandırmasını bağla
builder.Services.Configure<GoldApiSettings>(builder.Configuration.GetSection("GoldApi"));

builder.Services.AddControllers();

// Servisleri DI container'a ekle
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<GoldPriceService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var port = Environment.GetEnvironmentVariable("PORT");
if (port != null)
{
    builder.WebHost.UseUrls("http://0.0.0.0:" + port);
}

var app = builder.Build();

// ✅ Swagger'ı her ortamda etkinleştir
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();
app.Run();
