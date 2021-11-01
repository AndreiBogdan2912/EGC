using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class ReadFile
    {
        private int[] vec = new int[30];
        private int[,] ObjectVertex= new int[3,200];
        private int SizeVec = 0;
        private bool IsRead = false;
        public ReadFile(String file)
        {
            if (File.Exists(file))
            {
                IsRead = true;
            string linie;
            char[] sep = { ',' };


            int i = 0;
            int jObject = 0;

            StreamReader f = new StreamReader(file);
            while ((linie = f.ReadLine()) != null)
            {
                if (linie.Equals("}"))
                {
                    for (int j = 0; j < i; j++)
                        ObjectVertex[jObject, j] = vec[j];

                    if ((linie = f.ReadLine()) != null)
                    {
                        jObject++;
                        i = 0;
                        vec = new int[30];

                    }
                    else
                        break;
                }
                string[] numere = linie.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                foreach (string x in numere)
                {
                    if (i + 1 > vec.Length)
                        Array.Resize(ref vec, vec.Length + 10);
                    vec[i++] = int.Parse(x);

                }

            }
            SizeVec = --i;
        }
        else
                Console.WriteLine("Fisier de intrare inexistent!");
        }
        public int[] ReturnArray()
        {
            return vec;
        }
        public int ReturnSizeArray()
        {
            return SizeVec;
        }
        public bool getIsRead()
        {
            return IsRead;
        }
        public int[,] ReturnArray2D()
        {
            return ObjectVertex;
        }

        internal bool Exists(string v)
        {
            throw new NotImplementedException();
        }
    }
}
