using System;
using System.Drawing;
using System.IO;
using ZXing;


namespace MejorPrecio.Common
{
    public class BarcodeScanner
    {
        public string ScanBarcode(Stream imageStream)//devuelve el codigo de barras
        {
            // create a barcode reader instance
            var barcodeReader = new BarcodeReader();
            barcodeReader.Options.TryHarder = true;
 
            // create an in memory bitmap
            var barcodeBitmap = new Bitmap(imageStream);
    
            // decode the barcode from the in memory bitmap
            var barcodeResult = barcodeReader.Decode(barcodeBitmap);
 
            
            if(barcodeResult?.Text == null)
            {
                return null;
            }
 
            // output results to console
            /* Console.WriteLine($"Decoded barcode text: {barcodeResult?.Text}");
            Console.WriteLine($"Barcode format: {barcodeResult?.BarcodeFormat}"); */
            
            return barcodeResult?.Text;
        }    

    }
}