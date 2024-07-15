using System;
using System.Collections.Generic;
using System.Collections;   
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp164
{
    internal class Vidrizok
    {
        public bool isPeretun { get; set; } = false;
        public int NumberOfGroupe { get; set;}
        public bool perevireno { get; set; } = false;
        public Point p1 { get; }
        public Point p2 { get; }
        public Point point { get; set; }
        public Vidrizok(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public (int a, int b, long c) Pryama
        {
            get
            {
                return (p2.Y - p1.Y, p1.X - p2.X, p1.Y * p2.X - p1.X * p2.Y);
            }
        }
        bool CheckPorizni(Point p1, Point p2)
        {
            long res1 = Pryama.a * p1.X + Pryama.b * p1.Y + Pryama.c;
            long res2 = Pryama.a * p2.X + Pryama.b * p2.Y + Pryama.c;
            if (Math.Sign(res1) != Math.Sign(res2))
                return true;
            return false;
        }
        public static bool IsPeretun(Vidrizok v1, Vidrizok v2)
        {
            if (v1.CheckPorizni(v2.p1, v2.p2) && v2.CheckPorizni(v1.p1, v1.p2))
            {
                v1.isPeretun = true;
                v2.isPeretun = true;
                return true;
            }
            return false;
        }
        public static void FindFuckingGroupe(List<Vidrizok> list)
        {
            bool flag = false;
            int count = 0;  
            do
            {
                count++;
                flag = false;
                for(int i = 0; i < list.Count; i++)
                { 
                    for (int j = i; j < list.Count; j++)
                        if (Vidrizok.IsPeretun(list[i], list[j]) && !list[i].perevireno)
                        {
                            flag = true;
                            list[i].NumberOfGroupe = count;
                            break;
                        }
                    if (list[i].NumberOfGroupe==count)
                        break;
                }
                foreach (Vidrizok v1 in list.Where((x) => x.NumberOfGroupe == count))
                    foreach(Vidrizok v2 in list.Where((x) => !x.perevireno))
                        if (Vidrizok.IsPeretun(v1, v2))
                            v2.NumberOfGroupe = count;
                for(int i =0; i < list.Count;i++)
                    if(list[i].NumberOfGroupe == count)
                        list[i].perevireno = true;
            }while (flag);
        }
    }
}
