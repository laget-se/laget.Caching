# laget.Caching
A generic implementation for caching that supports application-, request- and session-caching...

![Nuget](https://img.shields.io/nuget/v/laget.Caching)
![Nuget](https://img.shields.io/nuget/dt/laget.Caching)

## Configuration
> This example is shown using Autofac since this is the go-to IoC for us.
```c#
public class DatabaseModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(c => new DapperDefaultProvider(c.Resolve<IConfiguration>().GetConnectionString("SqlConnectionString"))).As<IDapperDefaultProvider>().SingleInstance();
    }
}
```

## Usage