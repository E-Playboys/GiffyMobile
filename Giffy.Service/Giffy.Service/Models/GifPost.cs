using System;
using System.Collections.Generic;
using System.Linq;

namespace Giffy.Service.Models
{
    public class GifPost
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedUserDisplayName { get; set; }
        public string CreatedUserAvatar { get; set; }
        public string CreatedUserName { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Id { get; set; }
        public string Url
        {
            get
            {
                return Images.Any() ? Images.FirstOrDefault().Url : string.Empty;
            }
        }

        public List<Image> Images { get; set; } = new List<Image>();
    }
}
