using System;
using System.Collections.Generic;
using System.Drawing;
using ZXing;
using ZXing.Common;

namespace OCR_BarcodeReader
{
    class Program
    {
        static void Main(string[] args) 
        {
            string path = "file.png";

            IBarcodeReader reader = new BarcodeReader()
            {
                AutoRotate = true,
                TryInverted = true,
                Options = new DecodingOptions
                {
                    TryHarder = true,
                    PureBarcode = false,
                    ReturnCodabarStartEnd = true,
                    PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.CODE_128, BarcodeFormat.CODE_39, BarcodeFormat.UPC_E }
                }
            };

            Bitmap oBitmap = new Bitmap(path);
            var results = reader.DecodeMultiple(oBitmap);

            if (results.Length >= 1)
            {
                foreach (Result result in results)
                {
                    Console.WriteLine(result.Text + "," + result.BarcodeFormat);
                }
            }

        }
    }
}
