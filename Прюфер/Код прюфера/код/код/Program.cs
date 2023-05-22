using System;
using System.IO;

namespace Pryffer
{
    public class Pruf
    {
        public void Pr()
        {
            string file = new("код.txt");
            string[] mas = new string[file.Length];
            mas = File.ReadAllLines(file);
            string[,] mass = new string[mas.Length, mas.Length];
            int k = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                string[] tmp = mas[i].Split(";");
                for (int j = 0; j < tmp.Length; j++)
                {
                    mass[i, j] = tmp[j];
                    k++;
                }
                for (int j = 0; j < mas.Length; j++)
                {
                    if (mass[i, j] == null)
                        mass[i, j] = "0";
                }
            }
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas.Length; j++)
                {
                    Console.Write(mass[i, j] + " ");
                }
                Console.WriteLine();
            }
            string code = "";
            while (code.Length <= k - 2)
            {
                int[] num = new int[mas.Length];
                int ii = 0;
                int jj = 0;
                int min = int.MaxValue;
                int Pr = 0;
                for (int i = 0; i < mas.Length; i++)
                {
                    for (int j = mas.Length - 1; j >= 1; j--)
                    {
                        if (Convert.ToInt32(mass[i, j]) != 0)
                        {
                            num[i] = Convert.ToInt32(mass[i, j]);
                            if (num[i] < min)
                            {
                                min = num[i];
                                ii = i;
                                jj = j;
                                Pr = Convert.ToInt32(mass[i, j - 1]);
                            }
                            break;
                        }
                    }
                }
                mass[ii, jj] = "0";
                for (int i = 1; i < mas.Length; i++)
                    for (int j = 0; j < mas.Length; j++)
                    {
                        if (mass[i, j] == mass[i - 1, j] && mass[i, j] != "0")
                            if (mass[i, j + 1] == mass[i - 1, j + 1] && ((mass[i, j + 2] != "0" && mass[i - 1, j + 2] == "0") || (mass[i, j + 2] == "0" && mass[i - 1, j + 2] != "0")))
                            {
                                for (int ik = 0; ik < mas.Length; ik++)
                                    for (int jk = 0; jk < mas.Length; jk++) mass[i, jk] = "0";
                            }
                    }
                code = code + " " + Pr;
                Console.Write(Pr + " ");
            }
            string result = "итог.txt";
            File.WriteAllText(result, code);
        }
    }
    public class PrDec
    {
        public void Pr() 
        {
            string file = File.ReadAllText("код2.txt");
            string tree = "";
            string[] mass = file.Split(";");
            int[] mas = new int[10];
            int tmp = 0;
            for (int i = 0; i < mas.Length; i++) mas[i] = i + 1;
            while (file[file.Length - 1] != 0)
            {
                int[] masmin = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int min = int.MaxValue;               
                for (int i = 0; i < mass.Length; i++)
                    Console.Write(mas[i]+" ");
                for (int j = mas.Length - 1; j >= 0; j--)
                {
                    if (mas[j] != 0)
                    {
                        for (int i = 0; i < mass.Length; i++)
                        {
                            if (mas[j] == Convert.ToInt32(mass[i])) break;
                            else if (i == mass.Length - 1) 
                                masmin[j] = mas[j];
                        }
                    }
                }
                for (int i = 0; i < masmin.Length; i++)
                    if (masmin[i] != 0 && masmin[i] < min) 
                        min = masmin[i];
                if (mass[mass.Length - 1] == "0")
                {
                    for (int i = 0; i < mas.Length; i++) 
                        if (mas[i] != 0) 
                            tree += mas[i];
                    Console.WriteLine("Итог "+tree+" ");
                    break;
                }
                if (mass[mass.Length - 1] != "0")
                {
                    for (int i = 0; i < mass.Length; i++)
                        if (mass[i] != "0")
                        {
                            tree += mass[i];
                            break;
                        }
                    tree += min;
                    Console.WriteLine(tree+" ");
                    mass[tmp] = "0";
                    mas[min - 1] = 0;
                }
                else
                {
                    for (int i = 0; i < mas.Length; i++) if (mas[i] != 0) 
                            tree += mas[i]+" ";
                    Console.WriteLine("Итог "+tree+" ");
                    break;
                }
                tmp++;
            }
            string result = "итог2.txt";
            File.WriteAllText(result, tree);
        
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Pruf pruf = new Pruf();
            //pruf.Pr();
            //PrDec prDec = new PrDec();
            //prDec.Pr();
        }
    }
}