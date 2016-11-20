using Giffy.Service;
using Giffy.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giffy.ViewModels
{
    public class AdultsGIFPageViewModel : BaseViewModel
    {
        private readonly IGifService _gifService;
        public AdultsGIFPageViewModel(IAppService appService, IGifService gifService) : base(appService)
        {
            _gifService = gifService;
            Message = "This is Adults Gif page.";
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
    }
}
