using System;
using System.IO;
using System.Text;

namespace proyectoFinalArquihard
{
    class Program
    {
        private static int SIZE = 3;
        protected static String[] timesArray = new String[6];

        static void Main(string [] args)
        {
            Program pruebaVojabes = new Program();
            pruebaVojabes.init();
            //imagen que se va a leer
            int i = 12;
            //cambiar general por su respectivo cache
            String path = "../../../../Imagenes/cacheLectamo/" + i+".bmp";
            pruebaVojabes.leerImagen(path, i);
            
            
        }

        protected static sbyte[][] kernel;

        private void init()
        {
            kernel = new sbyte[][] { new sbyte[] {0, 1, 0} , new sbyte[] { 1,-4, 1 }, new sbyte[] { 0, 1, 0 } };
        }
        static byte[] filteringAlgorithmV1(byte[] dataArray, int iv)
        {

            

            int offset = 1078;
            int n = (int)Math.Sqrt(dataArray.Length - offset);
            byte[,] ImageArray = new byte[n, n];
            long time = DateTime.Now.Ticks;
          

            for (int x = 1; x < n - 1; x++)
            {
                for (int y = 1; y < n - 1; y++) 
                {
                    for (int i = 0; i < SIZE; i++)
                    {
                        for (int j = 0; j < SIZE; j++)
                        {
                            int row = x + i - 1;
                            int col = y + j - 1;

                            ImageArray[x, y] = (byte)(ImageArray[x, y] + dataArray[offset + row * n + col] * kernel[i][j]);
                        }
                    }
                }
            }

            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;
            timesArray[0] = "1-xyij,"+finalTime;
            int co = 0;
            for (int x = 0; x < n; x++) 
            {
                for (int y = 0; y < n; y++) 
                {
                    dataArray[offset + co] = ImageArray[x, y];
                    co++;
                }
            }
   
            return dataArray;
        }

        static byte[] filteringAlgorithmV2(byte[] dataArray)
        {
            int offset = 1078;
            int n = (int)Math.Sqrt(dataArray.Length - offset);
            byte[,] ImageArray = new byte[n, n];
            long time = DateTime.Now.Ticks;

            for (int x = 1; x < n - 1; x++) 
            {
                for (int y = 1; y < n - 1; y++) 
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        for (int i = 0; i < SIZE; i++)
                        {
                            int row = x + i - 1;
                            int col = y + j - 1;

                            ImageArray[x, y] = (byte)(ImageArray[x, y] + dataArray[offset + row * n + col] * kernel[i][j]);
                        }
                    }
                }
            }
            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;
            int co = 0;
            timesArray[1] = "2-xyji,"+finalTime;
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++) 
                {
                    dataArray[offset + co] = ImageArray[x, y];
                    co++;
                }
            }

            return dataArray;
        }

        static byte[] filteringAlgorithmV3(byte[] dataArray)
        {
            int offset = 1078;
            int n = (int)Math.Sqrt(dataArray.Length - offset);
            byte[,] ImageArray = new byte[n, n];
            long time = DateTime.Now.Ticks;
            int maximo = offset + n * (n - 1) + 1 - n;

            for (int y = 1; y < n - 1; y++) 
            {
                for (int x = 1; x < n - 1; x++)
                {
                    for (int i = 0; i < SIZE; i++)
                    {
                        for (int j = 0; j < SIZE; j++)
                        {
                            int row = x + i - 1;
                            int col = y + j - 1;

                            ImageArray[x, y] = (byte)(ImageArray[x, y] + dataArray[offset + row * n + col] * kernel[i][j]);
                        }
                    }
                }
            }
            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;

            timesArray[2] = "3-yxij," + finalTime;

            int co = 0;
            for (int x = 0; x < n; x++) 
            {
                for (int y = 0; y < n; y++) 
                {
                    dataArray[offset + co] = ImageArray[x, y];
                    co++;
                }
            }

            return dataArray;
        }

        static byte[] filteringAlgorithmV4(byte[] dataArray)
        {
            int offset = 1078;
            int n = (int)Math.Sqrt(dataArray.Length - offset);
            byte[,] ImageArray = new byte[n, n];

            long time = DateTime.Now.Ticks;

            int maximo = offset + n * (n - 1) + 1 - n;
            for (int y = 1; y < n - 1; y++)
            {
                for (int x = 1; x < n - 1; x++) 
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        for (int i = 0; i < SIZE; i++)
                        {
                            int row = x + i - 1;
                            int col = y + j - 1;

                            ImageArray[x, y] = (byte)(ImageArray[x, y] + dataArray[offset + row * n + col] * kernel[i][j]);
                        }
                    }
                }
            }
            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;
            timesArray[3] = "4-yxji,"+finalTime;

            int co = 0;
            for (int x = 0; x < n; x++) 
            {
                for (int y = 0; y < n; y++) 
                {
                    dataArray[offset + co] = ImageArray[x, y];
                    co++;
                }
            }

            return dataArray;
        }

        static byte[] filteringAlgorithmV5(byte[] dataArray)
        {
            int offset = 1078;
            int n = (int)Math.Sqrt(dataArray.Length - offset);
            byte[,] ImageArray = new byte[n, n];
            long time = DateTime.Now.Ticks;

            for (int x = 1; x < n - 1; x++) 
            {
                for (int y = 1; y < n - 1; y++)
                {
                    ImageArray[x, y] =  (byte)(ImageArray[x, y] + dataArray[offset + x * n + (0 - 1) * n + y + 0 - 2] * kernel[0][0]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (0 - 1) * n + y + 1 - 2] * kernel[0][1]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (0 - 1) * n + y + 2 - 2] * kernel[0][2]);

                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (1 - 1) * n + y + 0 - 2] * kernel[1][0]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (1 - 1) * n + y + 1 - 2] * kernel[1][1]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (1 - 1) * n + y + 2 - 2] * kernel[1][2]);

                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (2 - 1) * n + y + 0 - 2] * kernel[2][0]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (2 - 1) * n + y + 1 - 2] * kernel[2][1]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (2 - 1) * n + y + 2 - 2] * kernel[2][2]);
                }
            }

            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;
            int co = 0;

            timesArray[4] = "5-xy," + finalTime;

            for (int x = 0; x < n; x++) 
            {
                for (int y = 0; y < n; y++) 
                {
                    dataArray[offset + co] = ImageArray[x, y];
                    co++;
                }
            }
            
            return dataArray;
        }

        static byte[] filteringAlgorithmV6(byte[] dataArray)
        {
            int offset = 1078;
            int n = (int)Math.Sqrt(dataArray.Length - offset);
            byte[,] ImageArray = new byte[n, n];
            long time = DateTime.Now.Ticks;

            for (int y = 1; y < n - 1; y++)
            {
                for (int x = 1; x < n - 1; x++) 
                {

                    ImageArray[x, y] =  (byte)(ImageArray[x, y] + dataArray[offset + x * n + (0 - 1) * n + y + 0 - 2] * kernel[0][0]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (0 - 1) * n + y + 1 - 2] * kernel[0][1]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (0 - 1) * n + y + 2 - 2] * kernel[0][2]);

                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (1 - 1) * n + y + 0 - 2] * kernel[1][0]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (1 - 1) * n + y + 1 - 2] * kernel[1][1]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (1 - 1) * n + y + 2 - 2] * kernel[1][2]);

                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (2 - 1) * n + y + 0 - 2] * kernel[2][0]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (2 - 1) * n + y + 1 - 2] * kernel[2][1]);
                    ImageArray[x, y] += (byte)(ImageArray[x, y] + dataArray[offset + x * n + (2 - 1) * n + y + 2 - 2] * kernel[2][2]);
                }
            }

            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) * 100;
            int co = 0;

            timesArray[5] = "6-yx,"+finalTime;

            for (int x = 0; x < n; x++) 
            {
                for (int y = 0; y < n; y++) 
                {
                    dataArray[offset + co] = ImageArray[x, y];
                    co++;
                }
            }
            return dataArray;
        }

        protected void leerImagen(String path, int i)
        {
            
            FileInfo fileInfo = new FileInfo(path);
            byte[] dataArray = new byte[fileInfo.Length];
            

            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Read(dataArray, 0, dataArray.Length);
            }
            byte[] imagenConFiltro1 = filteringAlgorithmV1(dataArray, i);

            FileInfo output = new FileInfo("../../../../Imagenes/general/" + i + "-V1-outPut.bmp");
            using (FileStream fs = output.OpenWrite())
            {
                fs.Write(dataArray, 0, dataArray.Length);
            }

           
            

            byte[] imagenConFiltro2 = filteringAlgorithmV2(dataArray);

            FileInfo output2 = new FileInfo("../../../../Imagenes/general/" + i + "-V2-outPut.bmp");
            using (FileStream fs = output2.OpenWrite())
            {
                fs.Write(dataArray, 0, dataArray.Length);
            }

           
            

            byte[] imagenConFiltro3 = filteringAlgorithmV3(dataArray);

            FileInfo output3 = new FileInfo("../../../../Imagenes/general/" + i + "-V3-outPut.bmp");
            using (FileStream fs = output3.OpenWrite())
            {
                fs.Write(dataArray, 0, dataArray.Length);
            }
            
            

            byte[] imagenConFiltro4 = filteringAlgorithmV4(dataArray);

            FileInfo output4 = new FileInfo("../../../../Imagenes/general/" + i + "-V4-outPut.bmp");
            using (FileStream fs = output4.OpenWrite())
            {
                fs.Write(dataArray, 0, dataArray.Length);
            }
            
           

            byte[] imagenConFiltro5 = filteringAlgorithmV5(dataArray);

            FileInfo output5 = new FileInfo("../../../../Imagenes/general/" + i + "-V5-outPut.bmp");
            using (FileStream fs = output5.OpenWrite())
            {
                fs.Write(dataArray, 0, dataArray.Length);
            }
            
            

            byte[] imagenConFiltro6 = filteringAlgorithmV6(dataArray);

            FileInfo output6 = new FileInfo("../../../../Imagenes/general/" + i + "-V6-outPut.bmp");
            using (FileStream fs = output6.OpenWrite())
            {
                fs.Write(dataArray, 0, dataArray.Length);
            }
            guardarTimes(timesArray, i);
            timesArray = new String[6];
        }

        static void guardarTimes(String[] times, int i)
        {
            string path = @"../../../../Imagenes" + i + ".txt";
            string timesString = "";
            for (int j = 0; j < times.Length; j++)
            {
                timesString += times[j] +"\n";
            }

            if (i == 1)
            {
                timesString += "tamaño : 100";
            }else if (i == 2)
            {
                timesString += "tamaño : 120";
            }
            else if (i == 3)
            {
                timesString += "tamaño : 170";
            }
            else if (i == 4)
            {
                timesString += "tamaño : 176";
            }
            else if (i == 5)
            {
                timesString += "tamaño : 240";
            }
            else if (i == 6)
            {
                timesString += "tamaño : 350";
            }
            else if (i == 7)
            {
                timesString += "tamaño : 400";
            }
            else if (i == 8)
            {
                timesString += "tamaño : 510";
            }

            //Cada uno cambio de aqui en adelante el tamaño
            else if (i == 9)
            {
                timesString += "tamaño : 1550";
            }
            else if (i == 10)
            {
                timesString += "tamaño : 2172";
            }
            else if (i == 11)
            {
                timesString += "tamaño : 2660";
            }
            else if (i == 12)
            {
                timesString += "tamaño : 3070";
            }
            try
            {
                
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(timesString);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

               
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
