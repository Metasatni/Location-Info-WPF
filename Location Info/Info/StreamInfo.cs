using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Location_Info.Objects.EsportMatchesObject;

namespace Location_Info.Info
{
    public class StreamInfo
    {
        public string StreamUrl { get; set; }
        public StreamInfo(StreamsList streamsList)
        {
            this.StreamUrl = streamsList.RawUrl;
        }
    }
}
