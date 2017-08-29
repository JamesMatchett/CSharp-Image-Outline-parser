using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            string path = (@"E:\Programming\C#\ImageProcessing\Input.jpg");


            //make a new bitmap based on the image path input
            Bitmap img = new Bitmap(path);

            //make a multidimensional string array that uses the mininum memory possible
            string[,,] pixelarray = new string[img.Width, img.Height, 3];

            Console.WriteLine("Image found and contains " + (img.Height * img.Width) + " Pixels");
            Console.WriteLine(img.Width + (" pixels wide and ") + img.Height + (" pixels tall"));
            Console.WriteLine("Press enter to begin");
            Console.ReadKey();
            int total = (img.Height * img.Width);


            Console.WriteLine("Processing");

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);



                    //Console.WriteLine(progress + "% done");
                    


                    //add to array with coords
                    //array format will be Height, width, alpha, r ,g, b,

                    pixelarray[i, j, 0] = Convert.ToString(pixel.R);
                    pixelarray[i, j, 1] = Convert.ToString(pixel.G);
                    pixelarray[i, j, 2] = Convert.ToString(pixel.B);

                    //verification outputs
                    /*
                                        Console.WriteLine("At width " + i + " and height " + j + " there is an alpha of " + pixelarray[i, j, 0]);
                                        Console.WriteLine("A red of " + pixelarray[i, j, 1]);
                                        Console.WriteLine("A blue of " + pixelarray[i, j, 2]);
                                        Console.WriteLine("a green of " + pixelarray[i, j, 3]);
                                        Console.WriteLine("");

                     * */




                }

            }

            Console.WriteLine("");
            Console.WriteLine("Processing done");
            Console.WriteLine("Enter 1. to save input image as text array, Enter 2. to not");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {

                try
                {

                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter(@"C:\Users\DevUser\Downloads\pixels.txt");

                    //Write a line of text
                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            sw.WriteLine(Convert.ToString(i) + (" ") + Convert.ToString(j) + " " + pixelarray[i, j, 0] + (" ") + pixelarray[i, j, 1] + (" ") + pixelarray[i, j, 2]);

                        }

                    }






                    //Close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                
            }

            int[,,] ContrastArray = new int[img.Width, img.Height, 1];

            for (int i = 1; i < img.Width - 2; i = i + 2)
            {
                for (int j = 1; j < img.Height - 2; j = j + 2)
                {
                    int theshold = 30;
                    //overall brightness not colour change on this one
                    int brightness1 = (Convert.ToInt32(pixelarray[i, j, 0]) + Convert.ToInt32(pixelarray[i, j, 1]) + Convert.ToInt32(pixelarray[i, j, 2]));

                    int brightness2 = (Convert.ToInt32(pixelarray[i, j + 1, 0]) + Convert.ToInt32(pixelarray[i, j + 1, 1]) + Convert.ToInt32(pixelarray[i, j + 1, 2]));
                    int total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold)
                    {
                        //add to second array
                        ContrastArray[i, j, 0] = total1;
                    }


                    brightness2 = (Convert.ToInt32(pixelarray[i, j - 1, 0]) + Convert.ToInt32(pixelarray[i, j - 1, 1]) + Convert.ToInt32(pixelarray[i, j - 1, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold)
                    {
                        //add to second array
                        if (total1 > ContrastArray[i, j, 0])
                        {
                            ContrastArray[i, j, 0] = total1;
                        }
                    }


                    brightness2 = (Convert.ToInt32(pixelarray[i + 1, j + 1, 0]) + Convert.ToInt32(pixelarray[i + 1, j + 1, 1]) + Convert.ToInt32(pixelarray[i + 1, j + 1, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold)
                    {
                        //add to second array
                        if (total1 > ContrastArray[i, j, 0])
                        {
                            ContrastArray[i, j, 0] = total1;
                        }
                    }


                    brightness2 = (Convert.ToInt32(pixelarray[i - 1, j - 1, 0]) + Convert.ToInt32(pixelarray[i - 1, j - 1, 1]) + Convert.ToInt32(pixelarray[i - 1, j - 1, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold)
                    {
                        //add to second array
                        if (total1 > ContrastArray[i, j, 0])
                        {
                            ContrastArray[i, j, 0] = total1;
                        }
                    }


                    brightness2 = (Convert.ToInt32(pixelarray[i - 1, j, 0]) + Convert.ToInt32(pixelarray[i - 1, j, 1]) + Convert.ToInt32(pixelarray[i - 1, j, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold)
                    {
                        //add to second array
                        if (total1 > ContrastArray[i, j, 0])
                        {
                            ContrastArray[i, j, 0] = total1;
                        }
                    }


                    brightness2 = (Convert.ToInt32(pixelarray[i - 1, j + 1, 0]) + Convert.ToInt32(pixelarray[i - 1, j + 1, 1]) + Convert.ToInt32(pixelarray[i - 1, j + 1, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold)
                    {
                        //add to second array
                        if (total1 > ContrastArray[i, j, 0])
                        {
                            ContrastArray[i, j, 0] = total1;
                        }
                    }


                    brightness2 = (Convert.ToInt32(pixelarray[i + 1, j, 0]) + Convert.ToInt32(pixelarray[i + 1, j, 1]) + Convert.ToInt32(pixelarray[i + 1, j, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold)
                    {
                        //add to second array
                        if (total1 > ContrastArray[i, j, 0])
                        {
                            ContrastArray[i, j, 0] = total1;
                        }
                    }


                    brightness2 = (Convert.ToInt32(pixelarray[i + 1, j - 1, 0]) + Convert.ToInt32(pixelarray[i + 1, j - 1, 1]) + Convert.ToInt32(pixelarray[i + 1, j - 1, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold)
                    {
                        //add to second array
                        if (total1 > ContrastArray[i, j, 0])
                        {
                            ContrastArray[i, j, 0] = total1;
                        }
                    }

                }
            }

            Console.WriteLine("Contrast processed, 1. to save to texfile, 2. to not");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {

                try
                {

                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter(@"C:\Users\DevUser\Downloads\contrast.txt");

                    //Write a line of text
                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            if (ContrastArray[i, j, 0] != 0)
                            {
                                sw.WriteLine(Convert.ToString(i) + (" ") + Convert.ToString(j) + " " + ContrastArray[i, j, 0]);
                            }

                        }

                    }
                    sw.WriteLine(img.Width + " " + img.Height);






                    //Close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("File was saved successfully.");
                }


            }



            //now add in the analytics, the text file above was purely for backup, look for a large change in color value in adjacent
            //pixels and plot as a point of contrast, if value differs my 33% add it as a point of contrast.




            Console.WriteLine("Processing Contrast");

            //can we get a redraw of the image's contrast?

            Bitmap image = new Bitmap(img.Width, img.Height);
            SolidBrush brush = new SolidBrush(Color.Empty);
            using (Graphics g = Graphics.FromImage(image))
            {

                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        if (ContrastArray[x, y, 0] != 0)
                        {
                            int r = Convert.ToInt32(pixelarray[x, y, 0]);
                            int g1 = Convert.ToInt32(pixelarray[x, y, 1]);
                            int b = Convert.ToInt32(pixelarray[x, y, 2]);

                            brush.Color = Color.FromArgb(255, r, g1, b);
                            
                            g.FillRectangle(brush, x, y, 1, 1);
                        }

                        if (ContrastArray[x, y, 0] == 0)
                        {
                            brush.Color = Color.FromArgb(255, 0, 0, 0);
                           
                            g.FillRectangle(brush, x, y, 1, 1);

                        }
                    }
                }
            }


            string SavePath = @"E:\Programming\C#\ImageProcessing\saveImage.jpeg";

            image.Save(SavePath, ImageFormat.Jpeg);

            Console.WriteLine("");
            Console.WriteLine("Image generated");
            Console.ReadKey();




        }
    }
}
