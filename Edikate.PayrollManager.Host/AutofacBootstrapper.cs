using Autofac;
using Edikate.PayrollManager.App;
using Edikate.PayrollManager.App.PayrollHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edikate.PayrollManager.Host
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
            builder.RegisterType<PayrollHomeViewModel>().AsSelf().SingleInstance();
            return builder;
        }
    }
}
