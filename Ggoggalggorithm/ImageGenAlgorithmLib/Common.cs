using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImageGenAlgorithmLib
{
    public static class Common
    {
        class GgoggalggorithmException : Exception { }
        class SolutionNotFound : GgoggalggorithmException { }
        class InvalidSourceImage : GgoggalggorithmException { }



        public static Bitmap drawGeneratedImage(ICollection<Polygon> stepOutput, Bitmap image)
        {
            SolidBrush solidBlack = new SolidBrush(Color.Black);

            //Take our picture box and draw on it
            using (Graphics g = Graphics.FromImage(image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //Draw it all black
                g.FillRectangle(solidBlack, new Rectangle(0, 0, image.Width, image.Height));

                //Now we should draw each polygon
                foreach (var poly in stepOutput)
                {
                    if (poly.Ignore)
                        continue;
                    g.FillPolygon(new SolidBrush(poly.baseColor), poly.vertices.ToArray());
                }

            }

            return image;
        }

        public static int indexOfBestFit(Bitmap srcImage, List<List<Polygon>> allPolyLists, out double fitness, int skipEvery_firstPass, int skipAmount_firstPass)
        {
            double currentBestFitness = -1;
            int currentBestFitnessIndex = -1;

            double secondBestFitness = -2;
            int secondBestFitnessIndex = -2;

            for (int i = 0; i < allPolyLists.Count; i++)
            {
                double currFitness = -1;
                DetermineFitness(srcImage, drawGeneratedImage(allPolyLists[i], new Bitmap(srcImage)), out currFitness, skipEvery_firstPass, skipAmount_firstPass);

                if (currFitness > currentBestFitness)
                {
                    secondBestFitness = currentBestFitness;
                    secondBestFitnessIndex = currentBestFitnessIndex;

                    currentBestFitness = currFitness;
                    currentBestFitnessIndex = i;
                }
            }

            //Lets compare the two best
            double fitnessBest = -1;
            double fitnessSecond = -1;
            if (secondBestFitnessIndex < 0)
            {
                DetermineFitness(srcImage, drawGeneratedImage(allPolyLists[currentBestFitnessIndex], new Bitmap(srcImage)), out fitnessBest, -1, -1);
                fitness = fitnessBest;
                return currentBestFitnessIndex;
            }

            DetermineFitness(srcImage, drawGeneratedImage(allPolyLists[currentBestFitnessIndex], new Bitmap(srcImage)), out fitnessBest, -1, -1);
            DetermineFitness(srcImage, drawGeneratedImage(allPolyLists[secondBestFitnessIndex], new Bitmap(srcImage)), out fitnessSecond, -1, -1);

            //And pick the winner
            if (fitnessBest < fitnessSecond)
            {
                fitness = fitnessSecond;
                return secondBestFitnessIndex;
            }
            else
            {
                fitness = fitnessBest;
                return currentBestFitnessIndex;
            }

        }

        public static bool DetermineFitness(Bitmap srcImage, List<Polygon> polys, out double fitness, int skipEvery = -1, int skipAmount = 3)
        {
            //Draw a new image, and pass it though
            return DetermineFitness(srcImage, drawGeneratedImage(polys, new Bitmap(srcImage)), out fitness, skipEvery, skipAmount);
        }

        public static bool DetermineFitness(Bitmap srcB, Bitmap genB, out double fitness, int skipEvery = -1, int skipAmount = 3)
        {
            //Fitness starts at -1 in case of error
            fitness = -1;
            //First of all, are the two images the same bounds?
            if (!srcB.Size.Equals(genB.Size))
                return false;

            //Set the fitness to the total number of colors
            fitness = srcB.Size.Height * srcB.Size.Width * 3 * 255;

            //Time to get unsafe...
            Rectangle rect = new Rectangle(0, 0, srcB.Width, srcB.Height);
            BitmapData srcData = srcB.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData genData = genB.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);


            //Lets check our skip amount
            int numberBeforeSkip = -1;
            bool skipping = true;
            if (skipEvery <= 1)
            {
                skipping = false;
            }


            numberBeforeSkip = skipEvery - 1;

            unsafe
            {
                
                int height = rect.Height;
                int width = rect.Width * 3; // for 24bpp pixel data

                byte* ptrStartOfImage_src = (byte*)srcData.Scan0.ToPointer();
                byte* ptrEndOfImage_src = ptrStartOfImage_src + (width * height);
                byte* ptr1 = ptrStartOfImage_src;

                byte* ptrStartOfImage_gen = (byte*)genData.Scan0.ToPointer();
                byte* ptrEndOfImage_gen = ptrStartOfImage_gen + (width * height);
                byte* ptr2 = ptrStartOfImage_gen;


                //We are already starting at the beginning of the image
                //Go until the pointer is greater than...
                int currentRow = 0;
                int maxRow = height;

                while (ptr1 < ptrEndOfImage_src)
                {
                    //We should be at the start of the current row.
                    byte* ptrEndOfRow_src = ptrStartOfImage_src + ((currentRow + 1) * width);
                    int currentCol = 0;
                    while(ptr1 < ptrEndOfRow_src)
                    {
                        //Do we need to skip?
                        if (currentCol++ == numberBeforeSkip && skipping)
                        {
                            currentCol = 0;
                            //We need to skip ahead
                            ptr1 += skipAmount;
                            ptr2 += skipAmount;
                        }
                        else
                        {
                            int diff = *ptr1 - *ptr2;
                            fitness -= diff < 0 ? -diff : diff;
                            //Move to the next color (or pixel, if we are at the last color in this pixel)
                            ptr1++;
                            ptr2++;
                        }
                        
                    }
                    
                
                    //We need to point to the start of the row...
                    currentRow++;
                    ptr1 = ptrStartOfImage_src + ((currentRow + 1) * width);
                    ptr2 = ptrStartOfImage_gen + ((currentRow + 1) * width);
                }

               // //For each row...
               // for (int y = 0; y < rect.Height; y++)
               // {
               //     //For each column in that row...
               //     for (int x = 0; x < width; x++)
               //     {
               //         int diff = *ptr1 - *ptr2;
               //         fitness -= diff < 0 ? -diff : diff;
               //
               //         //Move to the next color (or pixel, if we are at the last color in this pixel)
               //         ptr1++;
               //         ptr2++;
               //     }
               //     //Move the pointers to the next row
               //     ptr1 += srcData.Stride - width;
               //     ptr2 += genData.Stride - width;
               // }
            }
            srcB.UnlockBits(srcData);
            genB.UnlockBits(genData);

            //Made it here? Return success
            return true;
        }

    }
}