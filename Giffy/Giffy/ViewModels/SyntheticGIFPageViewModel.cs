using Giffy.Utilities;
using System.Collections.ObjectModel;
using Giffy.Models;

namespace Giffy.ViewModels
{
    public class SyntheticGIFPageViewModel : BaseViewModel
    {
        public SyntheticGIFPageViewModel(IAppService appService) : base(appService)
        {
            Gifs = new ObservableCollection<GifModel>()
            {
                new GifModel()
                {
                    Url = "http://res.cloudinary.com/bongvl/image/upload/v1471705758/ccrrzjhmrgnlfxez65wy.mp4",
                    Thumbnail = "http://res.cloudinary.com/bongvl/image/upload/v1471705758/ccrrzjhmrgnlfxez65wy.png",
                    Width = 639,
                    Height = 387
                },
                new GifModel()
                {
                    Url = "http://res.cloudinary.com/bongvl/image/upload/v1469802320/joo4zhusnhe9ygthpqsn.mp4",
                    Thumbnail = "http://res.cloudinary.com/bongvl/image/upload/v1469802320/joo4zhusnhe9ygthpqsn.png",
                    Width = 639,
                    Height = 431
                },
                new GifModel()
                {
                    Url = "http://res.cloudinary.com/bongvl/image/upload/v1467095733/mfnyjj3mh2u3hapalyeh.mp4",
                    Thumbnail = "http://res.cloudinary.com/bongvl/image/upload/v1467095733/mfnyjj3mh2u3hapalyeh.png",
                    Width = 639,
                    Height = 357
                },
                new GifModel()
                {
                    Url = "https://media.giphy.com/media/PjYfyarIEsNGM/giphy.mp4",
                    Thumbnail = "https://media.giphy.com/media/PjYfyarIEsNGM/giphy.gif",
                    Width = 480,
                    Height = 364
                },
            };
        }


        private ObservableCollection<GifModel> _gifs;
        public ObservableCollection<GifModel> Gifs
        {
            get { return _gifs; }
            set { SetProperty(ref _gifs, value); }
        }
    }
}
