using Common.Logging;
using System;

namespace PingDogSvc
{
    class IocModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {

            Bind<ILog>().ToMethod(ctx =>
            {
                Type type = ctx.Request.ParentContext.Request.Service;
                return LogManager.GetLogger(type);
            });

            Bind<Service.WinService>().ToSelf();

        }
    }
}

