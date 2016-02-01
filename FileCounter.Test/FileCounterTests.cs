using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileCounter.Test
{
    [TestClass]
    public class FileCounterTests
    {
        [TestMethod]
        public void FileCounterTest1()
        {
            var counter = new FileCounter.ImageFilesCounter();

            counter.scanDir(@"C:\Users\Schulung\Documents\Visual Studio 2012\Projects\Bildergalerie");

            int jc = counter.JpegFilesCount;
            int gc = counter.GifFilesCount;

            counter.ResetCounters();

            counter.scanDir(@"C:\Users\Schulung\Documents\Visual Studio 2012\Projects\Bildergalerie");

            Assert.AreEqual(jc, counter.JpegFilesCount);
            Assert.AreEqual(gc, counter.GifFilesCount);


        }
    }
}
