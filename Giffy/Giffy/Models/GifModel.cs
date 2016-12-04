using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giffy.Models
{
    public class GifModel
    {
        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Id { get; internal set; }
    }
}
