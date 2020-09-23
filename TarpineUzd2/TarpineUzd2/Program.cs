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
            List<char> atsakymas = new List<char>();
            char[][] DuruSpyna1 = new char[3][];

            DuruSpyna1[0] = new char[] { '1', '2', '3' };
            DuruSpyna1[1] = new char[] { '4', '5', '6' };
            DuruSpyna1[2] = new char[] { '7', '8', '9' };

            atspausdintiDuruSpyna(DuruSpyna1, 1);

            char[][] DuruSpyna2 = new char[5][];

            DuruSpyna2[0] = new char[1] { '1' };
            DuruSpyna2[1] = new char[3] { '2', '3', '4' };
            DuruSpyna2[2] = new char[5] { '5', '6', '7', '8', '9' };
            DuruSpyna2[3] = new char[3] { 'A', 'B', 'C' };
            DuruSpyna2[4] = new char[1] { 'D' };

            atspausdintiDuruSpyna(DuruSpyna2, 2);

            string path = "abc.txt";
            skaitytiFaila(path);

            atspausdintiDuruKoda(sifruotiKoda(path, DuruSpyna1), 1);
            //su antra duru spyna - nepamirst
            Console.ReadLine();

        }

        private static void atspausdintiDuruSpyna(char[][] spyna, int numeris)
        {
            Console.WriteLine("Durų spyna numeris {0}: ", numeris);
            for (int n = 0; n < spyna.Length; n++)
            {
                for (int m = 0; m < spyna[n].Length; m++)
                {
                    Console.Write("{0}", spyna[n][m]);
                }
                Console.WriteLine();
            }
        }

        private static void skaitytiFaila(string path)
        {
            StreamReader sr = new StreamReader(path);
            string tekstas = sr.ReadToEnd();
            string eil = "";
            List<string> eilutes = new List<string>();
            while ((eil = sr.ReadLine()) != null)
            {
                eilutes.Add(eil);
            }
            sr.Close();
        }

        private static List<char> sifruotiKoda(string path, char[][] spyna)
            {
                List<string> eiles = new List<string>(File.ReadAllLines(path).ToList());
                var atsakymas = new List<char>();
                var ats = new List<char>(); // sarasas bus naudojamas galutiniam kodui parasyti
            int eilute = 1;
                int stulpelis = 1;
                char item = spyna[1][1]; //pradinis taskas
                int skaitliukas = 0;

        Console.WriteLine("Perskaitytas failas {0} ir jo turinys: ", path);
            foreach (string eile in eiles)
            {
                if (string.IsNullOrEmpty(eile))
                {
                    Console.WriteLine(eile);
                }
                else
                {
                    Console.WriteLine("{0}", eile);
                    skaitliukas++;

                    foreach (char raide in eile)
                    {
                        for (int i = 0; i< spyna.Length-2; i++)
                        {
                                if (raide == 'U')
                                {
                                    eilute = eilute - 1;
                                    if (eilute >= 0 && eilute <= 2)
                                    {
                                        item = spyna[eilute][stulpelis];
                                   
                                }
                                    else
                                    {
                                        eilute = eilute + 1;
                                        item = spyna[eilute][stulpelis];
                                   
                                } 
                                }

                                else if (raide == 'D')
                                {
                                    eilute = eilute + 1;
                                    if (eilute >= 0 && eilute <= 2)
                                    {
                                        item  = spyna[eilute][stulpelis];
                                  
                                }
                                    else
                                    {
                                        eilute = eilute - 1;
                                        item = spyna[eilute][stulpelis];
                                   
                                }
                                }

                                else if (raide == 'L')
                                {
                                    stulpelis = stulpelis - 1;
                                    if (stulpelis >= 0 && stulpelis <= 2)
                                    {
                                    item = spyna[eilute][stulpelis];
                                   
                                }
                                    else
                                    {
                                        stulpelis = stulpelis + 1;
                                    item = spyna[eilute][stulpelis];
                                   
                                }
                                }

                                else if (raide == 'R')
                                {         
                                    stulpelis = stulpelis + 1;
                                    if (stulpelis >= 0 && stulpelis <= 2)
                                    {
                                    item = spyna[eilute][stulpelis];
                                   
                                }
                                    else
                                    {
                                        stulpelis = stulpelis - 1;
                                    item = spyna[eilute][stulpelis];
                                  
                                }
                                }  
                        }
                      
                    }
                    atsakymas = ats.Add(item);

                   
                }
                return atsakymas;
            }

           }

        private static void atspausdintiDuruKoda(List<char> list, int numeris)
        {
            Console.Write("Iššifravus failą. Durų spynos {0} kodas gaunasi: ", numeris);
            foreach (char item in list)
            {
                Console.Write(item);
            }
        }

    }
}

