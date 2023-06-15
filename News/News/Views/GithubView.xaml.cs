using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News.Views
{
    public partial class GithubView : ContentPage
    {
        public GithubView()
        {
            InitializeComponent();
            Task.Run(async () => await Initialize());
        }


        private async Task Initialize()
        {
            var viewModel = Resolver.Resolve<GithubViewModel>();
            BindingContext = viewModel;
            await viewModel.Initialize();
        }
    }
}