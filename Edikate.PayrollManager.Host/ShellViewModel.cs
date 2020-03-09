using Caliburn.Micro;
using Edikate.PayrollManager.App;
using Edikate.PayrollManager.App.PayrollHome;
using System.Linq;

namespace Edikate.PayrollManager.Host
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
            var vm = IoC.Get<PayrollHomeViewModel>();
            base.ActivateItem(vm);
        }

        public void Handle(PayrollMenu menu)
        {
            switch (menu)
            {
                case PayrollMenu.DashboardView:
                    if (this.ActiveItem.GetType() == typeof(PayrollHomeViewModel))
                    {

                    }
                    else
                        base.ActivateItem(this.Items.FirstOrDefault());
                    break;
            }
        }
    }
}