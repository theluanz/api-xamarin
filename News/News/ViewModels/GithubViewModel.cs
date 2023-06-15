using News.Models;
using News.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace News.ViewModels
{
    public class GithubViewModel : ViewModel
    {
        private readonly GithubService githubService;

        public GithubResponse CurrentRepositories { get; set; }

        public GithubViewModel(GithubService githubService)
        {
            this.githubService = githubService;
        }

        public async Task Initialize()
        {
            CurrentRepositories = await githubService.GetRepositories();
        }

        public ICommand ItemSelected =>
            new Command(async (selectedItem) =>
            {
                var selectedRepository = selectedItem as Root;
                var url = HttpUtility.UrlEncode(selectedRepository.html_url);
                await Navigation.NavigateTo($"articleview?url={url}");
            });
    }
}
