using Giffy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Giffy.Views
{
    public partial class SyntheticGIFPage : ContentPage
    {
        public SyntheticGIFPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var context = BindingContext as SyntheticGIFPageViewModel;
            if (context != null && !context.Gifs.Any()) await context.LoadGifSMs(0);
            base.OnAppearing();
        }
    }
}
