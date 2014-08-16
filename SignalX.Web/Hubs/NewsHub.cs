using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalX.Web.Hubs
{
    [HubName("newshub")]
    public class NewsHub : Hub
    {
        public void addNews(string title, string body)
        {
            Clients.All.newsAdded(new NewsItem() { Title = title, Body = body, Created = DateTime.Now });
        }
    }
}