using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using PorpoiseMobileApp.ViewModels;
namespace PorpoiseMobileApp.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainView : MvxViewController
    {
        public MainView() : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //  var set = this.CreateBindingSet<MainView, MainViewModel>();
            //set.Bind(TextField).To(vm => vm.Text);
            //set.Bind(Button).To(vm => vm.ResetTextCommand);
            //set.Apply();
        }
    }
}
