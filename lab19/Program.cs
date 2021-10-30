using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab19
{
    /*Модель компьютера  характеризуется кодом  и названием  марки компьютера, типом  процессора,  частотой работы  процессора,
     объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством экземпляров,
     имеющихся в наличии.Создать список, содержащий 6-10 записей с различным набором значений характеристик.
     Определить:
     - все компьютеры с указанным процессором.Название процессора запросить у пользователя;
     - все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
     - вывести весь список, отсортированный по увеличению стоимости;
     - вывести весь список, сгруппированный по типу процессора;
     - найти самый дорогой и самый бюджетный компьютер;
     - есть ли хотя бы один компьютер в количестве не менее 30 штук?*/
    class Program
    {
        static void Main(string[] args)
        {
            #region Список компьютеров
            List<Comp> listComp = new List<Comp>()
            {
                new Comp(){ Name="Asus", CPU = "Ryzen 5", Freq = 3.3, RAM = 16, HDD = 500, GPU = 6, Price = 52000, Qty = 20},
                new Comp(){ Name="Aser", CPU = "Ryzen 5", Freq = 3.6, RAM = 16, HDD = 500, GPU = 8, Price = 65000, Qty = 18},
                new Comp(){ Name="HP", CPU = "Ryzen 3", Freq = 2.8, RAM = 8, HDD = 250, GPU = 2, Price = 41000, Qty = 34},
                new Comp(){ Name="Dell", CPU = "Ryzen 7", Freq = 4.2, RAM = 32, HDD = 1000, GPU = 12, Price = 120000, Qty = 8},
                new Comp(){ Name="Lenovo", CPU = "Core i3", Freq = 2.6, RAM = 4, HDD = 250, GPU = 1, Price = 34000, Qty = 32},
                new Comp(){ Name="MSI", CPU = "Core i5", Freq = 3.2, RAM = 8, HDD = 500, GPU = 4, Price = 58000, Qty = 6},
                new Comp(){ Name="Microsoft", CPU = "Core i7", Freq = 4.1, RAM = 32, HDD = 2000, GPU = 12, Price = 140000, Qty = 2},
                new Comp(){ Name="Huawei", CPU = "Core i5", Freq = 3.1, RAM = 8, HDD = 500, GPU = 4, Price = 56000, Qty = 10}
            };
            #endregion
            #region Вывод моделей с указанным процессором            
            Console.WriteLine("Выберите модель процессора\n1 - Ryzen 3\n2 - Ryzen 5\n3 - Ryzen 7\n4 - Core i3\n5 - Core i5\n6 - Core i7");
            try
            {
                string cpu = "";
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            cpu = "Ryzen 3";
                            break;
                        }
                    case 2:
                        {
                            cpu = "Ryzen 5";
                            break;
                        }
                    case 3:
                        {
                            cpu = "Ryzen 7";
                            break;
                        }
                    case 4:
                        {
                            cpu = "Core i3";
                            break;
                        }
                    case 5:
                        {
                            cpu = "Core i5";
                            break;
                        }
                    case 6:
                        {
                            cpu = "Core i7";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверный выбор");
                            break;
                        }
                }
                List<Comp> cpuChoice = listComp
                    .Where(d => d.CPU == cpu)
                    .ToList();
                foreach (Comp d in cpuChoice)
                {
                    Console.WriteLine($"{d.Name} {d.CPU} {d.Freq} {d.RAM} {d.HDD} {d.GPU} {d.Price} {d.Qty}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Для продолжения нажмите любую клавишу");            
            Console.ReadKey();
            Console.WriteLine();
            #endregion

            #region Вывод моделей с указанным объемом ОЗУ
            Console.Write("Введите объем оперативной памяти компьютера: ");
            try
            {
                int ram = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Компьютеры с объемом памяти не менее {ram}");
                List<Comp> ramChoice = listComp
                    .Where(d => d.RAM >= ram)
                    .ToList();
                foreach (Comp d in ramChoice)
                {
                    Console.WriteLine($"{d.Name} {d.CPU} {d.Freq} {d.RAM} {d.HDD} {d.GPU} {d.Price} {d.Qty}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Для продолжения нажмите любую клавишу");            
            Console.ReadKey();
            Console.WriteLine();
            #endregion

            #region Сортировка по увеличению стоимости
            Console.WriteLine("Сортировка компьютеров по увеличению стоимости:");
            List<Comp> sortPrice = listComp
                .OrderBy(d => d.Price)
                .ToList();
            foreach (Comp d in sortPrice)
            {
                Console.WriteLine($"{d.Name} {d.CPU} {d.Freq} {d.RAM} {d.HDD} {d.GPU} {d.Price} {d.Qty}");
            }
            Console.WriteLine("Для продолжения нажмите любую клавишу");            
            Console.ReadKey();
            Console.WriteLine();
            #endregion

            #region Группировка по типу процессора
            Console.WriteLine("Группировка компьютеров по типу процессора:\n");
            var sortCPU = listComp
                .GroupBy(d => d.CPU)
                .ToList();            
            foreach (var d in sortCPU)
            {
                Console.WriteLine($"Компьютеры с процессором {d.Key}:");
                foreach (var c in d)
                {
                    Console.WriteLine($"{c.Name} {c.CPU} {c.Freq} {c.RAM} {c.HDD} {c.GPU} {c.Price} {c.Qty}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Для продолжения нажмите любую клавишу");            
            Console.ReadKey();
            Console.WriteLine();
            #endregion

            #region Самый дорогой и самый бюджетный компьютер            
            var max = sortPrice.Last();
            var min = sortPrice.First();
            Console.WriteLine($"Самый дорогой компьютер: {max.Name} {max.CPU} {max.Freq} {max.RAM} {max.HDD} {max.GPU} {max.Price} {max.Qty}");
            Console.WriteLine($"Самый дешевый компьютер: {min.Name} {min.CPU} {min.Freq} {min.RAM} {min.HDD} {min.GPU} {min.Price} {min.Qty}");            
            Console.WriteLine("Для продолжения нажмите любую клавишу");            
            Console.ReadKey();
            Console.WriteLine();
            #endregion

            #region Компьютер к количестве не менее 30 штук
            bool avail = listComp.Any(q => q.Qty >= 30);
            if (avail)
            {
                Console.WriteLine("Компьютеры в количестве 30 штук и более:");                
                List<Comp> store = listComp
                    .Where(d => d.Qty >= 30)
                    .ToList();
                foreach (Comp d in store)
                {
                    Console.WriteLine($"{d.Name} {d.CPU} {d.Freq} {d.RAM} {d.HDD} {d.GPU} {d.Price} {d.Qty}");
                }
            }
            else
            {
                Console.WriteLine("Нет ни одного компютера в количестве 30 штук и более");
            }
            #endregion
            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();
        }
    }
    class Comp
    {        
        public string Name { get; set; }
        public string CPU { get; set; }
        public double Freq { get; set; }
        public int RAM { get; set; }
        public int HDD { get; set; }
        public int GPU { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
    }
}
