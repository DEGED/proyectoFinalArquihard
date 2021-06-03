using System;
using System.IO;

namespace proyectoFinalArquihard
{
    class Program
    {
        private static int SIZE = 3;

        static void Main(string[] args)
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
        static byte[] filteringAlgorithmV1(byte[] data)
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

                            C[x, y] = (byte)(C[x, y] + data[offset + row * n + col] * kernel[i][j]);
                        }
                    }
                }
            }
            long time2 = DateTime.Now.Ticks;
            long finalTime = (time2 - time) / 100;
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
            long finalTime = (time2 - time) / 100;
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

        static byte[] filteringAlgorithmV3(byte[] data)
        {
            int offset = 1078;
            int n = (int)Math.Sqrt(data.Length - offset);
            byte[,] C = new byte[n, n];

            long time = DateTime.Now.Ticks;
            for (int y = 1; y < n - 1; y++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int x = 1; x < n - 1; x++) // starts at 1 because
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
            long finalTime = (time2 - time) / 100;

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
            for (int y = 1; y < n - 1; y++) // starts at offset + n because image upper limit of the image is ignored
            {
                for (int x = 1; x < n - 1; x++) // starts at 1 because
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
            long finalTime = (time2 - time) / 100;
            
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
            byte[] imagenConFiltro = filteringAlgorithmV1(data);
            
            FileInfo output = new FileInfo("../../../../Imagenes/"+i+"outPut.bmp");
            using (FileStream fs = output.OpenWrite())
            {
                fs.Write(data, 0, data.Length);
            }
        }
    }
}
