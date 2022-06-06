using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class FilterSave : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            PictureProvider p = new PictureProvider();
            p.SavePicture(image, @"autosave.jpg");

            return image;
        }
    }
            
}