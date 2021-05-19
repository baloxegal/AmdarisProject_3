using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmdarisProject_3.Domain.Models
{
    class SentimentReaction : AbstractReaction
    {
        public string LikeImageUrl { get; set; }
        public string LoveImageUrl { get; set; }
        public string CareImageUrl { get; set; }
    }
}
