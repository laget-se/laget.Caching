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
Stores application-specific data, e.g application configuration that only change between deployments/releases.

#### RequestCache (`IRequestCache`)
Stores request-specific data, e.g. data used for a specific page that is fetched multiple times.

#### SessionCache (`ISessionCache`)
Stores session-specific data, e.g. user data that does not change during a session.
> If you store user-specific data that might change when a user changes their email address, or something alike, remember to flush the session cache or replace the old object with the new.