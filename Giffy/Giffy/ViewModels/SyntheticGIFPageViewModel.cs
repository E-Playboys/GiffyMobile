using Giffy.Utilities;
using System.Collections.ObjectModel;
using Prism.Commands;
using System.Threading.Tasks;
using System.Linq;
using Giffy.Service;
using Giffy.Service.Models;

namespace Giffy.ViewModels
{
    public class SyntheticGIFPageViewModel : BaseViewModel
    {
        private readonly IGifService _gifService;

        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand<GifPost> LoadMoreCommand { get; set; }

        private ObservableCollection<GifPost> _gifs = new ObservableCollection<GifPost>();
        public ObservableCollection<GifPost> Gifs
        {
            get { return _gifs; }
            set { SetProperty(ref _gifs, value); }
        }

        private int _totalGifs;

        public SyntheticGIFPageViewModel(IAppService appService, IGifService gifService) : base(appService)
        {
            //Gifs = new ObservableCollection<GifSM>()
            //{
            //    new GifSM()
            //    {
            //        Url = "http://res.cloudinary.com/bongvl/image/upload/v1471705758/ccrrzjhmrgnlfxez65wy.mp4",
            //        Thumbnail = "http://res.cloudinary.com/bongvl/image/upload/v1471705758/ccrrzjhmrgnlfxez65wy.png",
            //        Width = 639,
            //        Height = 387
            //    },
            //    new GifSM()
            //    {
            //        Url = "http://res.cloudinary.com/bongvl/image/upload/v1469802320/joo4zhusnhe9ygthpqsn.mp4",
            //        Thumbnail = "http://res.cloudinary.com/bongvl/image/upload/v1469802320/joo4zhusnhe9ygthpqsn.png",
            //        Width = 639,
            //        Height = 431
            //    },
            //    new GifSM()
            //    {
            //        Url = "http://res.cloudinary.com/bongvl/image/upload/v1467095733/mfnyjj3mh2u3hapalyeh.mp4",
            //        Thumbnail = "http://res.cloudinary.com/bongvl/image/upload/v1467095733/mfnyjj3mh2u3hapalyeh.png",
            //        Width = 639,
            //        Height = 357
            //    },
            //    new GifSM()
            //    {
            //        Url = "https://media.giphy.com/media/PjYfyarIEsNGM/giphy.mp4",
            //        Thumbnail = "https://media.giphy.com/media/PjYfyarIEsNGM/giphy.gif",
            //        Width = 480,
            //        Height = 364
            //    },
            //};

            _gifService = gifService;

            // Register commands
            RefreshCommand = DelegateCommand.FromAsyncHandler(ExecuteRefreshCommand, CanExecuteRefreshCommand);
            LoadMoreCommand = DelegateCommand<GifPost>.FromAsyncHandler(ExecuteLoadMoreCommand, CanExecuteLoadMoreCommand);
        }

        public bool CanExecuteRefreshCommand()
        {
            return IsNotBusy;
        }

        public async Task ExecuteRefreshCommand()
        {
            IsBusy = true;

            Gifs = new ObservableCollection<GifPost>();
            await LoadGifSMs(0);

            IsBusy = false;
        }

        public bool CanExecuteLoadMoreCommand(GifPost item)
        {
            return IsNotBusy /*&& Gifs.Count < _totalGifs*/ && Gifs.LastOrDefault().Id == item.Id;
        }

        public async Task ExecuteLoadMoreCommand(GifPost item)
        {
            IsBusy = true;

            var skip = Gifs.Count;
            await LoadGifSMs(skip);

            IsBusy = false;
        }

        public async Task LoadGifSMs(int skip)
        {
            var rq = new GetGifRq()
            {
                Skip = skip,
                Take = 5
            };
            var newGifs = await _gifService.GetGifs(rq);
            //_totalGifs = await _gifService.GetGifCount();

            foreach (var gif in newGifs)
            {
                if (Gifs.All(p => p.Id != gif.Id))
                {
                    Gifs.Add(gif);
                }
            }
        }
    }
}
