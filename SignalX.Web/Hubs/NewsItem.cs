using System;

namespace SignalX.Web.Hubs
{
    public class NewsItem
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
    }
}