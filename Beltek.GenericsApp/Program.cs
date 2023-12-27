namespace Beltek.GenericsApp
{
    internal class Program
    {
        //Değer Tipi-->Object:Boxing
        //Object-->Değer Tipi:Unboxing
        static void Main(string[] args)
        {
            //var d = new Deneme<int>();
            //d.Value1 = 1;
            //d.Value2 = 2;
            //Console.WriteLine((int)d.Value1+(int)d.Value2);

            //var d = new Deneme<int, object>();//<int, object>();
            //d.Value1 = 1;
            //d.Value2 = 2;
            //Console.WriteLine(d.Value1 + d.Value2);

            //string isim = null;//referans tipleri varsayılan olarak nullable'dır
            //Nullable<int> sayi = null;
            //int? number = null;//int soru işareti ile nullable tanımlamış oluruz.--> değersiz bir değer tipi tanımlamak için nullable yaparız
            //Değer tiplerini istersek nullable yapabiliriz.


            //var d2 = new Deneme<string>();
            //d2.Value1 = "Ahmet";
            //d2.Value2 = "Mehmet";

            //d.Yazdir(5);
            //d2.Yazdir("Beltek");

            var t = new Test<int>();
            t.Value1 = 10;
            t.Value2 = 20;

            int sonuc = t.Value1 + t.Value2;
        }
    }
    //performans kaybı ,sürekli heapten stack'e veri gezdirmek almak tür dönüşümü(boxing ,unboxing)

    //Generic Class:Class içinde kullanılan veritiplerinin class'a müdahale etmeden sonradan değiştirilebilmesini sağlar,böylece class'ın önceden kullanıldığı yerlerde hata alınmaz.Veri tiplerinin dinamik olması.Avantajlarından bir değeri,class içinde her veri tipini kullanabilmek için object kullanmak yerine bunu dinamik hale getirerek boxing ve unboxing nedeniyle oluşan performans kayıplarının önüne geçer  
    //T:Type

    //class içinde kullandığımız verinin dinamik hale gelmesine yarayan yapı
    //generic'in avantajı unboxing ve boxing yapmadan daha performanslı bir yapı oluşturduk
    //hep değer tipi yazmak için where T: struct
    //                           where U: struct kullanılır.
    //Bunlara Generic Constraints denir.
    //stringler hata verdi çünkü;stringler struct değildir ,classtır.
    //string f12 --> class,int f12 -->struct
    class Deneme<T, U> where T:struct
                       where U : class//Generic Constraints(kısıtlayıcılar)
    {
        public T Value1 { get; set; }
        public U Value2 { get; set; }

        public void Yazdir(T value)//(object value)
        {
            Console.WriteLine(value);

        }
    }

    class Test<T> where T:struct
    {
        public T Value1 { get; set; } 
        public T Value2 { get; set; }  
    
    
    }

}

//stack hızlı bölge heap referans tipleri tutar objectler heapde tutulur.stackte int tutulur
//object heap ,int stack bölgesinde saklanır inte erişim daha hızlı sağlanır