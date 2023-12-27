using System.Collections;

namespace Beltek.CollectionsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //array list object tutar list istediğimiz verileri tutar
            ArrayList al = new ArrayList();
            //al.Add(10);
            //al.Add(20);
            //al.Add(30);
            //al.Add(30);
            //al.Add(10);
            //al.Add(10);
            //al.Add(10);
            //al.Add(10);
            // al.Add(10);
          
            //al.Capacity = al.Count;

            //Console.WriteLine($"Capacity:{al.Capacity}\nCount:{al.Count}");

            //int sonuc = 0;
            //foreach (var item in al) 
            //{
            //    Console.WriteLine(item);
            //    //cw tab tab
            //    sonuc += (int)item;

            //}
            //Console.WriteLine(sonuc);

            //List<int> lst = new List<int>();
            //lst.Add(10);
            //lst.Add(20);
            //lst.Add(30);
            //lst.Add(30);
            //lst.Add(30);

            //lst.Capacity = lst.Count();
            //Console.WriteLine($"Capacity:{lst.Capacity}\nCount:{lst.Count}");

            
        }
    }
    //LAYOUT VİEW İÇERİSİNDE KONUMLANDIRILIR;TÜM SAYFALARDA GÖZÜKMESİ GEREKEN SABİT İÇERİKLER; MENÜ GİBİ FOOTER GİBİ MENÜ 
    interface ITest
    {
        int Topla(int s1, int s2);
        
    }
    class Text : A, ITest
    {
        public int Topla(int s1, int s2)
        {
            return s1 + s2;
        }
    }

    class A
    {

    }

    class B 
    {

    }
}
