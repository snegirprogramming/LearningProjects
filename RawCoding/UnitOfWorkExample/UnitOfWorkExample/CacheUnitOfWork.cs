using Microsoft.Extensions.Caching.Distributed;

public class CacheUnitOfWork : IDistributedCache
{
    private readonly IDistributedCache _cache;
    private readonly Dictionary<string, Entry> _buffer = new();

    public record Entry(byte[] Payload, bool Dirty);

    public CacheUnitOfWork(IDistributedCache cache)
    {
        _cache = cache;
    }

    public byte[]? Get(string key)
    {
        if (_buffer.TryGetValue(key, out var val))
        {
            return val.Payload;
        }

        var payload = _cache.Get(key);
        _buffer[key] = new(payload, false);
        return payload;
    }

    public async Task<byte[]?> GetAsync(string key, CancellationToken token = default)
    {
        if (_buffer.TryGetValue(key, out var val))
        {
            return val.Payload;
        }

        var payload = await _cache.GetAsync(key, token);
        _buffer[key] = new(payload, false);
        return payload;
    }

    public void Refresh(string key) => _cache.Refresh(key);

    public Task RefreshAsync(string key, CancellationToken token = default) =>
        _cache.RefreshAsync(key, token);

    public void Remove(string key)
    {
        _buffer[key] = new(null, false);
    }

    public Task RemoveAsync(string key, CancellationToken token = default)
    {
        _buffer[key] = new(null, false);
        return Task.CompletedTask;
    }

    public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    {
        _buffer[key] = new(value, true);
    }

    public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
    {
        _buffer[key] = new(value, true);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        foreach (var (key, value) in _buffer)
        {
            if (value.Dirty)
            {
                Console.WriteLine($"updating {key}");
                await _cache.SetAsync(key, value.Payload);
            }
        }
    }
}