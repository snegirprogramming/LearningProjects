using System.Text;
using Microsoft.Extensions.Caching.Distributed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(o => o.Configuration = "127.0.0.1:6379");

var redisCache = builder.Services.BuildServiceProvider().GetRequiredService<IDistributedCache>();
var redisCacheService = builder.Services.Single(x => x.ServiceType == typeof(IDistributedCache));
builder.Services.Remove(redisCacheService);

builder.Services.AddScoped<IDistributedCache, CacheUnitOfWork>(_ => new CacheUnitOfWork(redisCache));
builder.Services.AddScoped<A>();
builder.Services.AddScoped<B>();

var app = builder.Build();

app.Use(async (ctx, next) =>
{
    await next();
    var cuofw = (CacheUnitOfWork)ctx.RequestServices.GetRequiredService<IDistributedCache>();
    await cuofw.SaveChangesAsync();
});

app.MapGet("/", async (IDistributedCache cache) =>
{
    var result = await cache.GetAsync("test");
    return Encoding.UTF8.GetString(result);
});

app.MapGet("/store", async (IDistributedCache cache, A a, B b) =>
{
    await cache.SetAsync("test", "Unit Of Work"u8.ToArray());
    a.Do();
    b.Do();
});

app.Run();

public class A
{
    private readonly IDistributedCache _cache;
    private readonly B _b;

    public A(IDistributedCache cache, B b)
    {
        _cache = cache;
        _b = b;
    }

    public void Do()
    {
        _cache.Set("a", "test"u8.ToArray());
        _b.Do();
    }
}

public class B
{
    private readonly IDistributedCache _cache;

    public B(IDistributedCache cache)
    {
        _cache = cache;
    }

    public void Do() 
    {
        _cache.Set(Guid.NewGuid().ToString(), "test"u8.ToArray());
    }
}