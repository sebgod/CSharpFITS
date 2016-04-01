using System;
using System.IO;
using nom.tam.util;
using NUnit.Framework;

namespace nom.tam.fits
{
    [TestFixture]
    public class FitsCopyTester
    {
        [Test]
        public void TestFitsCopy( /*String[] args*/)
        {
            String file = @"C:\SourceCode\SidWatch\CSharpFITS\src\tests\resources\nom\tam\fits\test\test_dup.fits";

            Fits f = new Fits(file);
            int i = 0;
            BasicHDU h;

            do
            {
                h = f.ReadHDU();
                if (h != null)
                {
                    if (i == 0)
                    {
                        System.Console.Out.WriteLine("\n\nPrimary header:\n");
                    }
                    else
                    {
                        System.Console.Out.WriteLine("\n\nExtension " + i + ":\n");
                    }
                    i += 1;
                    h.Info();
                }
            } while (h != null);

            BufferedFile bf = new BufferedFile("gbfits3.fits" /*args[1]*/, FileAccess.ReadWrite, FileShare.ReadWrite);
            f.Write(bf);
            bf.Close();
        }
    }
}