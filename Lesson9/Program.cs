using System.Text;

namespace Lesson9
{
    public class Program
    {
        static CustomCollection<string>[] strCol = new CustomCollection<string>[] {
                new CustomCollection<string>(),
                new CustomCollection<string> (new string[]{ "one", "two" }),
                new CustomCollection<string> (new string[]{ "something", "coming", "this", "way" }),
            };
        static CustomCollection<int>[] intCol = new CustomCollection<int>[]
        {
                new CustomCollection<int>(15)
        };
        static IntCollection[] intColAdv = new IntCollection[]
        {
                new IntCollection(),
                new IntCollection()
        };


        public static void Main(string[] args)
        {
            PrintStatusStr();
            strCol[0].Add("one");
            strCol[0].Add("two");
            strCol[2][0] = "nothing";
            strCol[2].Remove("coming");
            Console.WriteLine();
            Console.WriteLine("After add in StrCol[0], also change by index and remove in StrCol[2]:");
            PrintStatusStr();

            Console.WriteLine();
            Console.WriteLine("Now for int collections:");

            foreach (var c in intColAdv) { FillRandom(c); }
            intCol[0] = new CustomCollection<int>(intColAdv[0]);
            PrintStatusInt();
        }


        public static void FillRandom(CustomCollection<int> c, int lowBound =0, int upBound = 100, int maxLength = 10)
        {
            var len = Random.Shared.Next() % maxLength;
            for (int i = 0; i < len; i++)
            {
                c.Add(lowBound + Random.Shared.Next() % 100);
            }
        }

        public static void PrintStatusStr()
        {
            for (int i = 0; i < strCol.Length; i++)
            {
                Console.WriteLine($"StrCol[{i}]={CollectionToString(strCol[i])}");
            }
            Console.WriteLine($"StrCol[0] == StrCol[1]: {strCol[0] == strCol[1]}");
            Console.WriteLine($"StrCol[0] != StrCol[1]: {strCol[0] != strCol[1]}");
        }
        public static void PrintStatusInt()
        {
            for (int i = 0; i < intCol.Length; i++)
            {
                Console.WriteLine($"intCol[{i}]   ={CollectionToString(intCol[i])}");
            }
            for (int i = 0; i < intColAdv.Length; i++)
            {
                Console.WriteLine($"intColAdv[{i}]={CollectionToString(intColAdv[i])}");
            }
            Console.WriteLine($"intColAdv[0]+intColAdv[1]={CollectionToString(intColAdv[0] + intColAdv[1])}");
            Console.WriteLine($"intCol[0] == intColAdv[0]: {intCol[0] == intColAdv[0]}");
            Console.WriteLine($"intCol[0] == intColAdv[1]: {intCol[0] == intColAdv[1]}");

        }

        public static string CollectionToString<T>(CustomCollection<T> c)
        {
            if (c.Count == 0) return "[]";
            StringBuilder b = new StringBuilder();
            b.Append("[");
            for (int i = 0; i < c.Count - 1; i++)
            {
                b.Append(c[i]); b.Append(", ");
            }
            b.Append(c[c.Count - 1]);
            b.Append("]");
            return b.ToString();
        }
    }
}