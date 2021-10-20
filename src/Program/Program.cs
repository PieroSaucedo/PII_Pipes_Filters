using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
        PictureProvider provider = new PictureProvider();
        IPicture picture = provider.GetPicture(@".\luke.jpg");
        IPipe pipeNull = new PipeNull();
        IFilter filterNegative = new FilterNegative();
        IPipe pipeSerialFirst = new PipeSerial(filterNegative, pipeNull);
        IFilter filterGreyscale = new FilterGreyscale();
        IPipe pipeSerialSecond = new PipeSerial(filterGreyscale, pipeSerialFirst);

        IPicture final = pipeSerialSecond.Send(picture);
        provider.SavePicture(final, @".\img.jpg");
        }
    }
}
