using System;
using System.IO;
using System.Text;

namespace proyectoFinalArquihard
{
    class Program
    {
        private static int SIZE = 3;
        protected static long[] timesArray = new long[6];

        static void Main(string [] args)
        {
            Program pruebaVojabes = new Program();
            pruebaVojabes.init();
            for (int i = 1; i<13; i++)
            {
                String path = "../../../../Imagenes/"+i+".bmp";
                pruebaVojabes.leerImagen(path, i);
            }
            
        }

        protected static sbyte[][] kernel;

        private void init()
        {
            kernel = new sbyte[][] { new sbyte[] {0, 1, 0} , new sbyte[] { 1, 4, 1 }, new sbyte[] { 0, 1, 0 } };
        }
        static byte[] filteringAlgorithmV1(byte[] data, int iv)
        {

            

            int offset = 1078;
            int n = (int)Math.Sqrt(data.Length - offset);
            byte[,] C = new byte[n, n];
            long time = DateTime.Now.Ticks;
          

            for (int x = 1; x < n - 1; x++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int y = 1; y < n - 1; y++) // starts at 1 because
                {
                    for (int i = 0; i < SIZE; i++)
                    {
                        for (int j = 0; j < SIZE; j++)
                        {
                            int row = x + i - 1;
                            int col = y + j - 1;
                            //X + (i - 1) * n + y + j - 2
                            C[x, y] = (byte)(C[x, y] + data[offset + row * n + col] * kernel[i][j]);
                        }
                    }
                }
            }

            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;
            timesArray[0] = finalTime;
            int co = 0;
            for (int x = 0; x < n; x++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int y = 0; y < n; y++) // starts at 1 because
                {
                    data[offset + co] = C[x, y];
                    co++;
                }
            }
   
            return data;
        }

        static byte[] filteringAlgorithmV2(byte[] data)
        {
            int offset = 1078;
            int n = (int)Math.Sqrt(data.Length - offset);
            byte[,] C = new byte[n, n];
            long time = DateTime.Now.Ticks;

            for (int x = 1; x < n - 1; x++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int y = 1; y < n - 1; y++) // starts at 1 because
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        for (int i = 0; i < SIZE; i++)
                        {
                            int row = x + i - 1;
                            int col = y + j - 1;

                            C[x, y] = (byte)(C[x, y] + data[offset + row * n + col] * kernel[i][j]);
                        }
                    }
                }
            }
            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;
            int co = 0;
            timesArray[1] = finalTime;
            for (int x = 0; x < n; x++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int y = 0; y < n; y++) // starts at 1 because
                {
                    data[offset + co] = C[x, y];
                    co++;
                }
            }

            return data;
        }

        static byte[] filteringAlgorithmV3(byte[] data)
        {
            int offset = 1078;
            int n = (int)Math.Sqrt(data.Length - offset);
            byte[,] C = new byte[n, n];
            long time = DateTime.Now.Ticks;
            int maximo = offset + n * (n - 1) + 1 - n;

            for (int y = 1; y < n - 1; y++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int x = 1; x < n - 1; x++) // starts at offset + n because image upper limit of the image is ignored
                {
                    for (int i = 0; i < SIZE; i++)
                    {
                        for (int j = 0; j < SIZE; j++)
                        {
                            int row = x + i - 1;
                            int col = y + j - 1;

                            C[x, y] = (byte)(C[x, y] + data[offset + row * n + col] * kernel[i][j]);
                        }
                    }
                }
            }
            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;

            timesArray[2] = finalTime;

            int co = 0;
            for (int x = 0; x < n; x++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int y = 0; y < n; y++) // starts at 1 because
                {
                    data[offset + co] = C[x, y];
                    co++;
                }
            }

            return data;
        }

        static byte[] filteringAlgorithmV4(byte[] data)
        {
            int offset = 1078;
            int n = (int)Math.Sqrt(data.Length - offset);
            byte[,] C = new byte[n, n];

            long time = DateTime.Now.Ticks;

            int maximo = offset + n * (n - 1) + 1 - n;
            for (int y = 1; y < n - 1; y++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int x = 1; x < n - 1; x++) // starts at offset + n because image upper limit of the image is ignored
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        for (int i = 0; i < SIZE; i++)
                        {
                            int row = x + i - 1;
                            int col = y + j - 1;

                            C[x, y] = (byte)(C[x, y] + data[offset + row * n + col] * kernel[i][j]);
                        }
                    }
                }
            }
            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;
            timesArray[3] = finalTime;

            int co = 0;
            for (int x = 0; x < n; x++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int y = 0; y < n; y++) // starts at 1 because
                {
                    data[offset + co] = C[x, y];
                    co++;
                }
            }

            return data;
        }

        static byte[] filteringAlgorithmV5(byte[] data)
        {
            int offset = 1078;
            int n = (int)Math.Sqrt(data.Length - offset);
            byte[,] C = new byte[n, n];
            long time = DateTime.Now.Ticks;

            for (int x = 1; x < n - 1; x++) 
            {
                for (int y = 1; y < n - 1; y++)
                {
                   // int row = x + i - 1;
                    //int col = y + j - 1;
                    //X + (i - 1) * n + y + j - 2
                    //C[x, y] = (byte)(C[x, y] + data[offset + row * n + col] * kernel[i][j]);

                    C[x, y] =  (byte)(C[x, y] + data[offset + x * n + (0 - 1) * n + y + 0 - 2] * kernel[0][0]);

                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (0 - 1) * n + y + 1 - 2] * kernel[0][1]);
                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (0 - 1) * n + y + 2 - 2] * kernel[0][2]);

                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (1 - 1) * n + y + 0 - 2] * kernel[1][0]);
                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (1 - 1) * n + y + 1 - 2] * kernel[1][1]);
                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (1 - 1) * n + y + 2 - 2] * kernel[1][2]);

                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (2 - 1) * n + y + 0 - 2] * kernel[2][0]);
                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (2 - 1) * n + y + 1 - 2] * kernel[2][1]);
                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (2 - 1) * n + y + 2 - 2] * kernel[2][2]);
                }
            }

            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;
            int co = 0;

            timesArray[4] = finalTime;

            for (int x = 0; x < n; x++) 
            {
                for (int y = 0; y < n; y++) 
                {
                    data[offset + co] = C[x, y];
                    co++;
                }
            }
            
            return data;
        }

        static byte[] filteringAlgorithmV6(byte[] data)
        {
            int offset = 1078;
            int n = (int)Math.Sqrt(data.Length - offset);
            byte[,] C = new byte[n, n];
            long time = DateTime.Now.Ticks;

            for (int y = 1; y < n - 1; y++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int x = 1; x < n - 1; x++) // starts at 1 because
                { 
                
                    C[x, y] = (byte)(C[x, y] + data[offset + x * n + (0 - 1) * n + y + 0 - 2] * kernel[0][0]);
                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (0 - 1) * n + y + 1 - 2] * kernel[0][1]);
                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (0 - 1) * n + y + 2 - 2] * kernel[0][2]);

                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (1 - 1) * n + y + 0 - 2] * kernel[1][0]);
                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (1 - 1) * n + y + 1 - 2] * kernel[1][1]);
                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (1 - 1) * n + y + 2 - 2] * kernel[1][2]);

                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (2 - 1) * n + y + 0 - 2] * kernel[2][0]);
                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (2 - 1) * n + y + 1 - 2] * kernel[2][1]);
                    C[x, y] += (byte)(C[x, y] + data[offset + x * n + (2 - 1) * n + y + 2 - 2] * kernel[2][2]);
                }
            }

            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;
            int co = 0;

            timesArray[5] = finalTime;

            for (int x = 0; x < n; x++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int y = 0; y < n; y++) // starts at 1 because
                {
                    data[offset + co] = C[x, y];
                    co++;
                }
            }
            return data;
        }

        protected void leerImagen(String path, int i)
        {
            // Load file meta data with FileInfo
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine(fileInfo.Length);
            // The byte[] to save the data in
            byte[] data = new byte[fileInfo.Length];
            // Load a filestream and put its content into the byte[]

            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Read(data, 0, data.Length);
            }
            byte[] imagenConFiltro1 = filteringAlgorithmV1(data, i);

            FileInfo output = new FileInfo("../../../../Imagenes/" + i + "-V1-outPut.bmp");
            using (FileStream fs = output.OpenWrite())
            {
                fs.Write(data, 0, data.Length);
            }

           
            

            byte[] imagenConFiltro2 = filteringAlgorithmV2(data);

            FileInfo output2 = new FileInfo("../../../../Imagenes/" + i + "-V2-outPut.bmp");
            using (FileStream fs = output2.OpenWrite())
            {
                fs.Write(data, 0, data.Length);
            }

           
            

            byte[] imagenConFiltro3 = filteringAlgorithmV3(data);

            FileInfo output3 = new FileInfo("../../../../Imagenes/" + i + "-V3-outPut.bmp");
            using (FileStream fs = output3.OpenWrite())
            {
                fs.Write(data, 0, data.Length);
            }
            
            

            byte[] imagenConFiltro4 = filteringAlgorithmV4(data);

            FileInfo output4 = new FileInfo("../../../../Imagenes/" + i + "-V4-outPut.bmp");
            using (FileStream fs = output4.OpenWrite())
            {
                fs.Write(data, 0, data.Length);
            }
            
           

            byte[] imagenConFiltro5 = filteringAlgorithmV5(data);

            FileInfo output5 = new FileInfo("../../../../Imagenes/" + i + "-V5-outPut.bmp");
            using (FileStream fs = output5.OpenWrite())
            {
                fs.Write(data, 0, data.Length);
            }
            
            

            byte[] imagenConFiltro6 = filteringAlgorithmV6(data);

            FileInfo output6 = new FileInfo("../../../../Imagenes/" + i + "-V6-outPut.bmp");
            using (FileStream fs = output6.OpenWrite())
            {
                fs.Write(data, 0, data.Length);
            }
            guardarTimes(timesArray, i);
            timesArray = new long[6];
        }

        static void guardarTimes(long[] times, int i)
        {
            string path = @"../../../../image" + i + ".txt";
            string timesString = "";
            for (int j = 0; j < times.Length; j++)
            {
                timesString += times[j] +"\n";
            }

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(timesString);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine("FFFF");
            }
        }
    }

}
