# laget.Caching
A generic implementation for caching that supports application-, request- and session-caching...

![Nuget](https://img.shields.io/nuget/v/laget.Caching)
![Nuget](https://img.shields.io/nuget/dt/laget.Caching)

## Configuration
> This implementation requires `Autofac` since this is the Inversion of Control container of our choosing.
### .NET Core
```c#
builder.RegisterCacheProviders();
```

### .NET Framework
```c#
var builder = new ContainerBuilder();
builder.RegisterCacheProviders();
var container = builder.Build();
```

## Usage
#### ApplicationCache (`IApplicationCache`)
> `Store`: Memory (MemoryCache)
Stores application-specific data, e.g application configuration that only change between deployments/releases.

#### RequestCache (`IRequestCache`)
> `Store`: Dictionary (ConcurrentDictionary)
Stores request-specific data, e.g. data used for a specific page that is fetched multiple times.