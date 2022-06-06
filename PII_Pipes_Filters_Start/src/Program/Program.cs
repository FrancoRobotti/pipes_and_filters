using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using System.Threading.Tasks;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            // agregar pipes and filters

            IPipe pipeNull = new PipeNull();
            IFilter FilterNegative = new FilterNegative();

            PipeSerial pipeSerial = new PipeSerial(FilterNegative, pipeNull); //constructor1

            IPicture image2 = pipeSerial.Send(picture); 

            provider.SavePicture(image2, @"beer_Step1.jpg"); 
            
            FilterGreyscale filterGreyscale = new FilterGreyscale();

            PipeSerial pipeSerial1 = new PipeSerial(filterGreyscale, pipeSerial); //constructor2

            IPicture image = pipeSerial1.Send(picture); 

            //guardo

            provider.SavePicture(image, @"beer_Step2.jpg");    //guardo el resultado en en este archivo

            IFilter filter1 = new FilterSave();


            //ejercicio 2 (save)        
            // no pude realizar el filtro, no comprendo muy bien el porque (FilterSave)
            PictureProvider provider1 = new PictureProvider();
            IPicture picture1 = provider1.GetPicture(@"luke.jpg");

            PipeSerial pipeej2 = new PipeSerial(FilterNegative, pipeNull); //constructor1

            IPicture image3 = pipeej2.Send(picture); 

            IFilter filterSave = new FilterSave(); //filtro de guardado

            PipeSerial pipeej21 = new PipeSerial(filterSave, pipeej2); //constructor2



            //ejercicio 3

            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Image base", @"Beer.jpg"));             // las imagenes se publican correctamente, sin el filtro de save.
            Console.WriteLine(twitter.PublishToTwitter("Image step 1", @"Beer_Step1.jpg"));
            Console.WriteLine(twitter.PublishToTwitter("Image step 2", @"Beer_Step2.jpg"));
 
        }
    }
}

