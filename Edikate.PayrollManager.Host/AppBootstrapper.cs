namespace Edikate.TimeManager.Host
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Threading;
    using Autofac;
    using Caliburn.Micro;

    public class AppBootstrapper : BootstrapperBase
    {
        private IContainer container;

        static AppBootstrapper()
        {
        }

        public AppBootstrapper()
        {
            Initialize();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            System.Windows.Application.Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;
            System.Windows.Application.Current.Dispatcher.UnhandledException += DispatcherOnUnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        private void DispatcherOnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
        }

        private void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
        }

        protected override void Configure()
        {
            var builder = AutofacBootstrapper.InitializeContainer();
            container = builder.Build();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.Resolve(service);
            if (instance != null)
                return instance;
            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new Assembly[] {
                Assembly.GetAssembly(typeof(IShell)),
               Assembly.GetAssembly(typeof(Edikate.TimeManager.App.LeftNavigatorViewModel)),
            };
        }
    }
}