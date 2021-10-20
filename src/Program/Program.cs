using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
        /* //EJERCICIO 1 (Quitar símbolos de comentarios para ejecutar)
        
        PictureProvider provider = new PictureProvider();
        IPicture picture = provider.GetPicture(@".\luke.jpg");
        IPipe pipeNull = new PipeNull();
        IFilter filterNegative = new FilterNegative();
        IPipe pipeSerialFirst = new PipeSerial(filterNegative, pipeNull);
        IFilter filterGreyscale = new FilterGreyscale();
        IPipe pipeSerialSecond = new PipeSerial(filterGreyscale, pipeSerialFirst);

        IPicture final = pipeSerialSecond.Send(picture);
        provider.SavePicture(final, @".\img.jpg");
        
        */

        PictureProvider provider2 = new PictureProvider();
        IPicture picture2 = provider2.GetPicture(@".\luke.jpg");
        
        IPipe pipeNull2 = new PipeNull();
        
        IFilter filterNegative2 = new FilterNegative();
        IPipe pipeSerialFirst2 = new PipeSerial(filterNegative2, pipeNull2);
        IPicture filterNegativePicture = pipeSerialFirst2.Send(picture2);
        provider2.SavePicture(filterNegativePicture, @".\lukeNegativeFilter.jpg");
        
        IFilter filterGreyscale2 = new FilterGreyscale();
        IPipe pipeSerialSecond2 = new PipeSerial(filterGreyscale2, pipeNull2);
        IPicture filterGreyscalePicture = pipeSerialSecond2.Send(picture2);
        provider2.SavePicture(filterGreyscalePicture, @".\lukeGreyscaleFilter.jpg");

        var twitter = new TwitterImage();
        Console.WriteLine(twitter.PublishToTwitter("GreyscaleFiltered Luke", @".\lukeGreyscaleFilter.jpg"));
        Console.WriteLine(twitter.PublishToTwitter("NegativeFiltered Luke", @".\lukeNegativeFilter.jpg"));
        Console.WriteLine(twitter.PublishToTwitter("FinalFiltered Luke", @".\img.jpg"));
        }
    }
}
