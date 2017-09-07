using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gynvael_Misja010
{
    class Program
    {
        static void Main(string[] args)
        {
            int startindex = 0;
            int endindex = 0;
            int lenght = 0;
            byte[] imagebytes = File.ReadAllBytes("misja.pdf"); //Kopiowanie pliku jako tablica bajtów.
            for(int i = 0; i < imagebytes.Length; i++)
            {
                if(Convert.ToString(imagebytes[i]) == "255")
                {
                    if(Convert.ToString(imagebytes[i+1]) == "216")
                    {
                        startindex = i;
                        Console.WriteLine(startindex);
                    }
                    if (Convert.ToString(imagebytes[i + 1]) == "217")
                    {
                        endindex = i;
                        Console.WriteLine(endindex);
                    }
                }

            }
            Console.Read();
            lenght = endindex - startindex + 1; //Sprawdzenie długości obrazka w bitach
            byte[] newimage = new byte[lenght]; //Deklaracja bitów na obrazek
            Array.Copy(imagebytes, startindex, newimage, 0, lenght); //Kopiowanie bitów do obrazka
            File.WriteAllBytes("image.jpg", newimage);

        }
    }
}
