﻿using System.Text;

namespace Builder;

public class Program
{
    static void Main(string[] args)
    {
        QueryBuilder builder = new QueryBuilder();
        //FormBodyBuilder builder = new FormBodyBuilder();
        //HttpHeaderBuilder builder = new HttpHeaderBuilder();
        //DictBuilder builder = new DictBuilder();
        ConstrcutionProcess(builder);
        Console.WriteLine(builder.Build());
    }

    public static void ConstrcutionProcess(IKeyValueCollectionBuilder builder)
    {
        builder
            .Add("make", "lada")
            .Add("colour", "red")
            .Add("year", 1980.ToString());
    }
}

public interface IKeyValueCollectionBuilder
{
    IKeyValueCollectionBuilder Add(string key, string value);
}

public class QueryBuilder : IKeyValueCollectionBuilder
{
    private StringBuilder _queryStringBuilder = new StringBuilder();

    public IKeyValueCollectionBuilder Add(string key, string value)
    {
        _queryStringBuilder.Append(_queryStringBuilder.Length == 0 ? "?" : "&");
        _queryStringBuilder.Append(key);
        _queryStringBuilder.Append("=");
        _queryStringBuilder.Append(Uri.EscapeDataString(value));
        return this;
    }

    public string Build()
    {
        return _queryStringBuilder.ToString();
    }
}

public class FormBodyBuilder : IKeyValueCollectionBuilder
{
    private StringBuilder _queryStringBuilder = new StringBuilder();

    public IKeyValueCollectionBuilder Add(string key, string value)
    {
        _queryStringBuilder.Append(key);
        _queryStringBuilder.Append("=");
        _queryStringBuilder.Append(value);
        _queryStringBuilder.AppendLine();
        return this;
    }

    public string Build()
    {
        return _queryStringBuilder.ToString();
    }
}

public class HttpHeaderBuilder : IKeyValueCollectionBuilder
{
    private StringBuilder _queryStringBuilder = new StringBuilder();

    public IKeyValueCollectionBuilder Add(string key, string value)
    {
        _queryStringBuilder.Append(key);
        _queryStringBuilder.Append(": ");
        _queryStringBuilder.Append(value);
        _queryStringBuilder.AppendLine();
        return this;
    }

    public string Build()
    {
        return _queryStringBuilder.ToString();
    }
}

public class DictBuilder : IKeyValueCollectionBuilder
{
    private Dictionary<string, string> Dictionary = new Dictionary<string, string>();

    public IKeyValueCollectionBuilder Add(string key, string value)
    {
        Dictionary[key] = value;
        return this;
    }

    public Dictionary<string, string> Build()
    {
        return Dictionary;
    }
}