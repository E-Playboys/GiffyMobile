using Giffy.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giffy.ViewModels
{
    public class SyntheticGIFPageViewModel : BaseViewModel
    {
        public SyntheticGIFPageViewModel(IAppService appService) : base(appService)
        {
            Message = "This is Synthetic Gif Page";
        }


        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
    }
}
