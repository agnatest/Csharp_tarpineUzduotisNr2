using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TarpineUzd2
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] DuruKodas1 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            char[][] DuruKodas2 =
             { 
                new char[] { '1' },
                new char[] { '2', '3', '4' },
                new char[] { '5', '6', '7', '8', '9' },
                new char[] { 'A', 'B', 'C' },
                new char[] { 'D' }
             };

            string path = "abc.txt";
            StreamReader sr = new StreamReader(path);

            string tekstas = sr.ReadToEnd();
            string eil = "";
            List<string> eilutes = new List<string>();
            while ((eil = sr.ReadLine()) != null)
            {
                eilutes.Add(eil);
            }
            sr.Close();

            //Pirmas metodas kai sukuriam sarasa ir priskiriame jam 
            //pradines reiksmes is tekstinio failo
            List<string> eiles = new List<string>(File.ReadAllLines(path));

            //Antras metodas kai sukuriamas sarasas uz mus
            eiles = File.ReadAllLines(path).ToList();

            int DuruKodo1Pradzia = DuruKodas1[1, 1]; // 5 duru kodo pradzia
            int atsakymas = 0; // bus naudojamas galutiniam kodui parasyti
            int eilute = 1;
            int stulpelis = 1;
            int skaicius;

            int skaitliukas = 0;
            foreach (string eile in eiles)
            {
                if (string.IsNullOrEmpty(eile))
                {
                    Console.WriteLine(eile);
                }
                else
                {
                    Console.WriteLine("[{0}][{1}]", skaitliukas, eile);
                    skaitliukas++;

                    foreach (char raide in eile)
                    {
                        Console.WriteLine("[{0}]", raide);

                            for (int i = 0; i < DuruKodas1.GetLength(0) - 2; i++)
                            {

                                if (raide == 'U')
                                {
                                    eilute = eilute - 1;

                                    if (eilute >= 0 && eilute <= 2)
                                    {
                                        skaicius = DuruKodas1[eilute, stulpelis];
                                        Console.WriteLine("{0}", skaicius);
                                    }
                                    else
                                    {
                                        skaicius = DuruKodas1[eilute + 1, stulpelis];
                                        Console.WriteLine("{0}", skaicius);
                                    }
                                }

                                else if (raide == 'D')
                                {
                                    eilute = eilute + 1;

                                    if (eilute >= 0 && eilute <= 2)
                                {
                                        skaicius = DuruKodas1[eilute, stulpelis];
                                        Console.WriteLine("{0}", skaicius);
                                    }
                                    else
                                    {
                                        skaicius = DuruKodas1[eilute - 1, stulpelis];
                                        Console.WriteLine("{0}", skaicius);
                                    }
                                }
                                else if (raide == 'L')
                                {
                                    stulpelis = stulpelis - 1;
                                    if (stulpelis >= 0 && stulpelis <= 2)
                                    {
                                        skaicius = DuruKodas1[eilute, stulpelis];
                                        Console.WriteLine("{0}", skaicius);
                                    }
                                    else
                                    {
                                        skaicius = DuruKodas1[eilute, stulpelis + 1];
                                        Console.WriteLine("{0}", skaicius);
                                    }

                                }

                                else if (raide == 'R')
                                {
                                    stulpelis = stulpelis + 1;
                                    if (stulpelis >= 0 && stulpelis <= 2)
                                    {
                                        skaicius = DuruKodas1[eilute, stulpelis];
                                        Console.WriteLine("{0}", skaicius);
                                    }
                                    else
                                    {
                                        skaicius = DuruKodas1[eilute, stulpelis - 1];
                                        Console.WriteLine("{0}", skaicius);
                                    }
                                }

                                //  Console.WriteLine("{0}", skaicius);
                            }

                        
                    }
                }
            }

                Console.ReadLine();





                //for (int i = 0; i < DuruKodas1.GetLength(0); i++)
                //{
                //    string skaicius = "";
                //    for (int j = 0; j < DuruKodas1.GetLength(1); j++)
                //    {
                //        skaicius = DuruKodas1[i+1, j] + " ";

                //    }
                //    Console.WriteLine("[{0}]", skaicius);
                //}

                //for (int i = 0; i < 4; i++)
                //{
                //        for  (int j=0; j< 4; j++)
                //        {           
                //            if (raide == 'U')
                //            {
                //                 rodykle = rodykle++;
                //                 Console.WriteLine("Ats yra: {1}", rodykle);
                //            }
                //            else if (raide == 'D') { }
                //            else if (raide == 'L') { }
                //            else if (raide == 'R') { }
                //        }
                //    }
                //}

        }
    }
}
