using Xam.Plugins.VideoPlayer;
using Xamarin.Forms;

namespace Giffy.Views.Templates
{
    public partial class GifViewCell : ViewCell
    {
        public GifViewCell()
        {
            InitializeComponent();
            Video.MediaStateChanged += (sender, args) =>
            {
                if (args.State == MediaState.Loaded)
                {
                    Thumbnail.IsVisible = false;
                    ActivityIndicator.IsVisible = false;
                }

                if (args.State == MediaState.Finished)
                {
                    Video.Play();
                }
            };

            Thumbnail.Success += (sender, args) =>
            {
                GifPanel.HeightRequest = GifPanel.Width * args.ImageInformation.CurrentHeight / args.ImageInformation.CurrentWidth;
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Video.Play();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //Video.Stop();
        }
    }
}
