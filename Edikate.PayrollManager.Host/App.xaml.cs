using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Edikate.PayrollManager.Host
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ThemeManager.AddAccent("EdikateAccent", new Uri("pack://application:,,,/Edikate.PayrollManager.Host;component/Styles/EdikateAccent.xaml"));
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("EdikateAccent"), appStyle.Item1);
            base.OnStartup(e);
        }
    }
}
