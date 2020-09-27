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
            // Tarpine uzduotis Nr2 - Agna Semaškaitė

            // Reikia iššifruoti durų kodą, kuris duotas su teksto failu. (abc.txt ir input.txt)
            // U, D, R, L raidės žymi atitinkamai kryptį - aukštyn, žemyn, dešinėn, kairėn.
            // Yra dvi durų spynos:
            // 1.   1 2 3
            //      4 5 6
            //      7 8 9 
            // 2.     1 
            //      2 3 4 
            //    5 6 7 8 9 
            //      A B C 
            //        D 
            //Pradedama yra nuo skaičiaus 5 durų spynose.

            Console.WriteLine("Programa, skirta iššifruoti durų kodą, pagal duotą\n" +
                "teksto failą.");
            atspausdintiLinija();

            char[][] DuruSpyna1 = new char[3][];

            DuruSpyna1[0] = new char[] { '1', '2', '3' };
            DuruSpyna1[1] = new char[] { '4', '5', '6' };
            DuruSpyna1[2] = new char[] { '7', '8', '9' };

            atspausdintiDuruSpyna(DuruSpyna1, 1);
            atspausdintiLinija();

            char[][] DuruSpyna2 = new char[5][];

            DuruSpyna2[0] = new char[] { ' ', ' ', '1', ' ', ' ' };
            DuruSpyna2[1] = new char[] { ' ', '2', '3', '4', ' ' };
            DuruSpyna2[2] = new char[] { '5', '6', '7', '8', '9' };
            DuruSpyna2[3] = new char[] { ' ', 'A', 'B', 'C', ' ' };
            DuruSpyna2[4] = new char[] { ' ', ' ', 'D', ' ', ' ' };

            atspausdintiDuruSpyna(DuruSpyna2, 2);
            atspausdintiLinija();

            string path = "abc.txt"; //abc.txt arba input.txt
            skaitytiFaila(path);

            Console.WriteLine("\nPerskaitytas failas {0} ir jo turinys: ", path);
            atspausdintiDuruKoda(sifruotiKoda(path, DuruSpyna1, 0, 2, 0, 2, 1, 1, 2), 1);
            atspausdintiLinija();
            Console.WriteLine("\nPerskaitytas failas {0} ir jo turinys: ", path);
            atspausdintiDuruKoda(sifruotiKoda(path, DuruSpyna2, 0, 4, 0, 5, 2, 0, 4), 2);
            atspausdintiLinija();
            Console.WriteLine("\nPrograma darbą baigė.");
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
                Console.WriteLine(" ");
            }
        }
        private static void skaitytiFaila(string path)
        {
            StreamReader sr = new StreamReader(path);
            string eil = "";
            List<string> eilutes = new List<string>();
            while ((eil = sr.ReadLine()) != null)
            {
                eilutes.Add(eil);
            }
            sr.Close();
        }
        private static List<char> sifruotiKoda(string path, char[][] spyna, int masyvoEiluciuRezis1, int masyvoEiluciuRezis2, int masyvoStulpeliuRezis1, int masyvoStulpeliuRezis2, int eilute, int stulpelis, int sumazininimas)
        {
            List<string> eiles = new List<string>(File.ReadAllLines(path).ToList());
            var atsakymas = new List<char>();
            char item = spyna[eilute][stulpelis]; //pradinis taskas
            int skaitliukas = 0;

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

                    Console.WriteLine("Pradinis taskas: {0}", item);

                    foreach (char raide in eile)
                    {
                        for (int i = 0; i < spyna.Length - sumazininimas; i++)
                        {
                            for (int j = 0; j < spyna[i].Length - sumazininimas; j++)
                            {
                                if (raide == 'U')
                                {
                                    eilute = eilute - 1;
                                    if (eilute >= masyvoEiluciuRezis1 && eilute <= masyvoEiluciuRezis2)
                                    {
                                        item = spyna[eilute][stulpelis];
                                        if (item != ' ')
                                        {
                                            item = spyna[eilute][stulpelis];
                                            Console.WriteLine("Item: {0}", item);
                                        }
                                        else
                                        {
                                            eilute = eilute + 1;
                                            item = spyna[eilute][stulpelis];
                                            Console.WriteLine("Item: {0}", item);
                                        }
                                    }
                                    else
                                    {
                                        eilute = eilute + 1;
                                        item = spyna[eilute][stulpelis];
                                        Console.WriteLine("Item: {0}", item);
                                    }

                                }

                                else if (raide == 'D')
                                {
                                    eilute = eilute + 1;
                                    if (eilute >= masyvoEiluciuRezis1 && eilute <= masyvoEiluciuRezis2)
                                    {
                                        item = spyna[eilute][stulpelis];
                                        if (item != ' ')
                                        {
                                            item = spyna[eilute][stulpelis];
                                            Console.WriteLine("Item: {0}", item);
                                        }
                                        else
                                        {
                                            eilute = eilute - 1;
                                            item = spyna[eilute][stulpelis];
                                            Console.WriteLine("Item: {0}", item);
                                        }
                                    }
                                    else
                                    {
                                        eilute = eilute - 1;
                                        item = spyna[eilute][stulpelis];
                                        Console.WriteLine("Item: {0}", item);
                                    }
                                }

                                else if (raide == 'L')
                                {
                                    stulpelis = stulpelis - 1;
                                    if (item != ' ')
                                    {
                                        if (stulpelis >= masyvoStulpeliuRezis1 && stulpelis <= masyvoStulpeliuRezis2)
                                        {
                                            item = spyna[eilute][stulpelis];
                                            if (item != ' ')
                                            {
                                                item = spyna[eilute][stulpelis];
                                                Console.WriteLine("Item: {0}", item);
                                            }
                                            else
                                            {
                                                stulpelis = stulpelis + 1;
                                                item = spyna[eilute][stulpelis];
                                                Console.WriteLine("Item: {0}", item);
                                            }
                                        }
                                        else
                                        {
                                            stulpelis = stulpelis + 1;
                                            item = spyna[eilute][stulpelis];
                                            Console.WriteLine("Item: {0}", item);
                                        }
                                    }
                                }

                                else if (raide == 'R')
                                {
                                    stulpelis = stulpelis + 1;
                                    if (item != ' ')
                                    {
                                        if (stulpelis >= masyvoStulpeliuRezis1 && stulpelis <= masyvoStulpeliuRezis2)
                                        {
                                            item = spyna[eilute][stulpelis];
                                            if (item != ' ')
                                            {
                                                item = spyna[eilute][stulpelis];
                                                Console.WriteLine("Item: {0}", item);
                                            }
                                            else
                                            {
                                                stulpelis = stulpelis + 1;
                                                item = spyna[eilute][stulpelis];
                                                Console.WriteLine("Item: {0}", item);
                                            }
                                        }
                                        else
                                        {
                                            stulpelis = stulpelis - 1;
                                            item = spyna[eilute][stulpelis];
                                            Console.WriteLine("Item: {0}", item);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    atsakymas.Add(item);
                }
            }
            return atsakymas;
        }
        private static void atspausdintiDuruKoda(List<char> list, int numeris)
        {
            Console.Write("Iššifravus failą. Durų spynos {0} kodas gaunasi: ", numeris);
            foreach (char item in list)
            {
                Console.Write(item);
            }
        }
        private static void atspausdintiLinija()
        {
            Console.WriteLine("\n---------------------------------------------------\n");
        }

    }
}

