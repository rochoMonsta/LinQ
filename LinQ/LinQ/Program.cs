using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQ
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            var products = new List<Product>();

            for (int i = 0; i < 10; i++)
                products.Add(new Product("Product" + i, rnd.Next(0, 100)));

            //Вибір тільки тих об'єктів, чия енергетична цінність менше 50
            var result = products.Where(item => item.Energy < 50);
            PrintCollection(result);
            //Вибір тільки Енергетичної цінності кожного об'єкту
            var SelectCollectionEnergy = products.Select(product => product.Energy);
            PrintCollection(SelectCollectionEnergy);
            //OrderBy (сортування елементів колекції від більшого до меншого (Energy))
            //OrderByDecending (сортування від найбільшого до найменшого (Energy))
            //ThenBy (додаткове сортування відсортованої колекції по ще одній умові (зростання))
            var OrderbyCollection = products.OrderBy(product => product.Energy)
                                            .ThenBy(product => product.Name);
            PrintCollection(OrderbyCollection);

            //GroupBy це створення колекції(як словника (ключ - пара))
            //в якому ми шукаємо відповідні для ключа значення та записуємо
            //їх в нашу колекцію
            var groupCollection = products.GroupBy(product => product.Energy);
            foreach (var group in groupCollection)
            {
                Console.WriteLine(group.Key);
                foreach(var item in group)
                {
                    Console.WriteLine($"\t{item}");
                }
                Console.WriteLine();
            }
            //All вертає true, якщо в колекції продуктів енергетична
            //цінність всіх елементів рівна 30
            var all = products.All(item => item.Energy == 30);
            //Any вертає true, якщо є хоча б один елемент
            //чия енергетична цінність рівна 30
            var any = products.Any(item => item.Energy == 30);
            Console.WriteLine(all + " " + any);
            //Contains вертає true, якщо в колекції є елемент який шукається
            var contain = products.Contains(products[4]);

            var array1 = new int[] { 1, 2, 3, 4 };
            var array2 = new int[] { 3, 4, 5, 6 };
            //intersect включає в себе ті значення, які є спільні для array1 та array2
            var intersect = array1.Intersect(array2);
            PrintCollection(intersect);
            //except включає в себе всі елементи які є унікальні для array1(якийх немає в array2)
            var except = array1.Except(array2);
            PrintCollection(except);

            var maxEnergy = products.Max(item => item.Energy);
            var minEnergy = products.Min(item => item.Energy);
            Console.WriteLine(minEnergy);
            //перемножує всі елементи в array1
            var aggregate = array1.Aggregate((x, y) => x * y);
            //skip(2) означає, що ми пропускаємо перші 2 елементи в колекції
            var aggreageteResultSkip = array1.Skip(2).Aggregate((x, y) => x * y);
            Console.WriteLine(aggreageteResultSkip);
            //Skip(1) - пропускаємо перший елемент колекції
            //Take(2) - беремо 2 елементи колекції
            var aggregateSkipTake = array1.Skip(1).Take(2).Aggregate((x, y) => x * y);
            Console.WriteLine(aggregateSkipTake);

            Console.ReadLine();
        }
        public static void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (var element in collection)
                Console.WriteLine(element);
            Console.WriteLine();
        }
    }
}
