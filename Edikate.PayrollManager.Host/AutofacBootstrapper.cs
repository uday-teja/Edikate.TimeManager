using Autofac;
using Edikate.TimeManager.App;
using Edikate.TimeManager.App.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edikate.TimeManager.Host
{
    static class AutofacBootstrapper
    {
        public static ContainerBuilder InitializeContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Caliburn.Micro.WindowManager>().As<Caliburn.Micro.IWindowManager>().SingleInstance();
            builder.RegisterType<Caliburn.Micro.EventAggregator>().As<Caliburn.Micro.IEventAggregator>().SingleInstance();
            builder.RegisterType<ShellViewModel>().As<IShell>();
            builder.RegisterType<LeftNavigatorViewModel>().AsSelf().SingleInstance();
            builder.RegisterType<HomeViewModel>().AsSelf().SingleInstance();
            return builder;
        }
    }
}
