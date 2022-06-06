using System;
using System.Drawing;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Image base", @"Beer.jpg"));  
            return image;
        }
    }
            
}