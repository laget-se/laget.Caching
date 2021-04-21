using System;
using Autofac;

namespace laget.Caching.Extensions
{
    public static class RegistrationExtensions
    {
        public static void RegisterCacheProvider(this ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.RegisterType<ApplicationCache>()
                .As<IApplicationCache>()
                .SingleInstance();
#if NETFRAMEWORK
            builder.RegisterType<RequestCache>()
                .As<IRequestCache>()
                .InstancePerRequest();
#else
            builder.RegisterType<RequestCache>()
                .As<IRequestCache>()
                .InstancePerLifetimeScope();
#endif

            builder.RegisterType<SessionCache>()
                .As<ISessionCache>()
                .SingleInstance();
        }
    }
}
