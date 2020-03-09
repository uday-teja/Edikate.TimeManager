using Caliburn.Micro;
using Edikate.TimeManager.App;
using Edikate.TimeManager.App.Home;
using System.Linq;

namespace Edikate.TimeManager.Host
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
    {

        public LeftNavigatorViewModel LeftNavigatorViewModel { get; set; }

        public IEventAggregator EventAggregator { get; set; }

        public ShellViewModel(LeftNavigatorViewModel leftNavigatorViewModel, IEventAggregator eventAggregator)
        {
            this.LeftNavigatorViewModel = leftNavigatorViewModel;
            this.EventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            var vm = IoC.Get<HomeViewModel>();
            base.ActivateItem(vm);
        }

        public void Handle(PayrollMenu menu)
        {
            switch (menu)
            {
                case PayrollMenu.DashboardView:
                    if (this.ActiveItem.GetType() == typeof(HomeViewModel))
                    {

                    }
                    else
                        base.ActivateItem(this.Items.FirstOrDefault());
                    break;
            }
        }
    }
}