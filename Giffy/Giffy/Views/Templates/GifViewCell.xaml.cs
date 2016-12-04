using System;
using System.Windows.Input;
using Xam.Plugins.VideoPlayer;
using Xamarin.Forms;

namespace Giffy.Views.Templates
{
    public partial class GifViewCell : ViewCell
    {
        public static BindableProperty VideoPlayCommandProperty = BindableProperty.Create(nameof(VideoPlayCommand),
            typeof(ICommand), typeof(GifViewCell));

        public ICommand VideoPlayCommand
        {
            get { return (ICommand)GetValue(VideoPlayCommandProperty); }
            set { SetValue(VideoPlayCommandProperty, value); }
        }

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

                //if (args.State == MediaState.Finished)
                //{
                //    Video.Play();
                //}

                if (args.State != MediaState.Playing)
                {
                    PlayButton.Text = "fa-play-circle";
                    PlayButton.FadeTo(1, easing: Easing.Linear);
                }
                else
                {
                    PlayButton.Text = "fa-pause-circle";
                    PlayButton.FadeTo(0, easing: Easing.Linear);
                }
            };

            Thumbnail.Success += (sender, args) =>
            {
                GifPanel.HeightRequest = GifPanel.Width * args.ImageInformation.CurrentHeight / args.ImageInformation.CurrentWidth;
            };

            PlayButton.Clicked -= OnPlayButtonClicked;
            PlayButton.Clicked += OnPlayButtonClicked;
        }

        private void OnPlayButtonClicked(object sender, EventArgs e)
        {
            if (Video.MediaState != MediaState.Playing)
            {
                Video.Play();
            }
            else
            {
                Video.Pause();
            }

            if (VideoPlayCommand != null)
            {
                VideoPlayCommand.Execute(e);
            }
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
