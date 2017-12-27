using System;
using System.Drawing;
using ZXing;


namespace MejorPrecio.Common
{
    public class BarcodeScanner
    {
        public string ScanBarcode( string image )//devuelve el codigo de barras
        {
            // create a barcode reader instance
            var barcodeReader = new BarcodeReader();
            barcodeReader.Options.TryHarder = true;
 
            // create an in memory bitmap
            var barcodeBitmap = (Bitmap)Bitmap.FromFile(image);
    
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