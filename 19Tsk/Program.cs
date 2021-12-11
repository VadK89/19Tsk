using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19Tsk
{


    class Program
    {

        // Модель компьютера  характеризуется кодом  и названием  марки компьютера, типом  процессора,
        // частотой работы  процессора,  объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты,
        // стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии.Создать список,
        // содержащий 6-10 записей с различным набором значений характеристик.
        //Определить:
        //- все компьютеры с указанным процессором.Название процессора запросить у пользователя;
        //- все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
        //- вывести весь список, отсортированный по увеличению стоимости;
        //- вывести весь список, сгруппированный по типу процессора;
        //- найти самый дорогой и самый бюджетный компьютер;
        //- есть ли хотя бы один компьютер в количестве не менее 30 штук?

        static void Main(string[] args)
        {

            List<PC> pclist = new List<PC>()
            {
                new PC() { Code = 4761281, Mark = "Acer XC-830", Cpu = "Celeron", CpuFreq = 2000, RamVal = 4, HddVal = 128, VidMem = 1, Cost = 17777, Remains = 50 },
                new PC() { Code = 4795423, Mark = "Mac mini 2020", Cpu = "Apple M1", CpuFreq = 3200, RamVal = 16, HddVal = 1024, VidMem = 1, Cost = 121499, Remains = 2 },
                new PC() { Code = 4815455, Mark = "Trident A 11TC", Cpu = "Core i5", CpuFreq = 2600, RamVal = 16, HddVal = 1000, VidMem = 6, Cost = 124999, Remains = 1 },
                new PC() { Code = 4761281, Mark = "ROG Strix G15DK", Cpu = "Ryzen 5", CpuFreq = 3700, RamVal = 32, HddVal = 512, VidMem = 8, Cost = 174999, Remains = 0 },
                new PC() { Code = 4815799, Mark = "HP Pavilion", Cpu = "Ryzen 3", CpuFreq = 4000, RamVal = 8, HddVal = 520, VidMem = 4, Cost = 69999, Remains = 33 },
                new PC() { Code = 4775603, Mark = "DEXP Jupiter P342", Cpu = "Core i5", CpuFreq = 2900, RamVal = 16, HddVal = 500, VidMem = 6, Cost = 104999, Remains = 10 },
                new PC() { Code = 4794032, Mark = "MSI Cubi 5 10M", Cpu = "Celeron", CpuFreq = 2000, RamVal = 4, HddVal = 128, VidMem = 1, Cost = 22500, Remains = 5 },
                new PC() { Code = 4761281, Mark = "IdeaCentre 3 ", Cpu = "Athlon", CpuFreq = 2300, RamVal = 4, HddVal = 128, VidMem = 1, Cost = 23999, Remains = 15 },
                new PC() { Code = 4761281, Mark = "HYPERPC NANO X", Cpu = "Core i5", CpuFreq = 2600, RamVal = 16, HddVal = 2000, VidMem = 6, Cost = 213546, Remains = 1 },
                new PC() { Code = 4761281, Mark = "HPS01", Cpu = "Athlon", CpuFreq = 2300, RamVal = 8, HddVal = 256, VidMem = 2, Cost = 33333, Remains = 31 },            
            };
            //Вывод ПК из списка с указанным пользователем процессором
            Console.WriteLine("Введите модель процессора");
            string proc = Console.ReadLine();
            List<PC> pc1 = pclist
                .Where(cp => cp.Cpu == proc)
                .ToList();
            foreach (PC cp in pc1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{cp.Code}  {cp.Mark}  {cp.Cpu} {cp.CpuFreq}  {cp.RamVal}  {cp.HddVal}  {cp.VidMem}  {cp.Cost}  {cp.Remains} ");
                Console.ResetColor();
            }
            //Вывод ПК из списка с объемом ОЗУ не ниже, чем указано
            Console.WriteLine("Введите объем ОЗУ ");
            int mem = Convert.ToInt32(Console.ReadLine());
            List<PC> pc2 = pclist
                .Where(cp1 => cp1.RamVal >= mem)
                .ToList();
            foreach (PC cp1 in pc2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{cp1.Code}  {cp1.Mark}  {cp1.Cpu} {cp1.CpuFreq}  {cp1.RamVal}  {cp1.HddVal}  {cp1.VidMem}  {cp1.Cost}  {cp1.Remains} ");
                Console.ResetColor();
            }
            //список ПК, отсортированный по увеличению стоимости
            List<PC> pcsort = pclist
                .OrderBy(cst => cst.Cost)
                .ToList();            
            Console.WriteLine("Сортировка по возрастанию цены");
            foreach (PC cst in pcsort)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{cst.Code}  {cst.Mark}  {cst.Cpu} {cst.CpuFreq}  {cst.RamVal}  {cst.HddVal}  {cst.VidMem}  {cst.Cost}  {cst.Remains} ");
                Console.ResetColor();
            }
            //список, сгруппированный по типу процессора
            var pcgroup = pclist
                .GroupBy(cps => cps.Cpu)
                .ToList();
            Console.WriteLine("Группировка по типу процессора");
            foreach (IGrouping<string, PC> comp in pcgroup)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(comp.Key);
                foreach (var t in comp)
                    Console.WriteLine($"{t.Code}  {t.Mark}  {t.Cpu} {t.CpuFreq}  {t.RamVal}  {t.HddVal}  {t.VidMem}  {t.Cost}  {t.Remains} ");
                Console.ResetColor();
            }
            //Поиск самого дорогого и самый бюджетного компьютера
            int max = pclist.Max(n => n.Cost);
            Console.WriteLine("Стоимость самого дорогого компьютера");
            Console.WriteLine(max);
            List<PC> pcmsx = pclist
                .Where(cos => cos.Cost == max)
                .ToList();
            foreach (PC cos in pcmsx)
            {
                Console.WriteLine("Самый дорогой компьютер");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{cos.Code}  {cos.Mark}  {cos.Cpu} {cos.CpuFreq}  {cos.RamVal}  {cos.HddVal}  {cos.VidMem}  {cos.Cost}  {cos.Remains} "); ;
                Console.ResetColor();
            }
            int min = pclist.Min(m => m.Cost);
            Console.WriteLine("Стоимость самого дешевого компьютера");
            Console.WriteLine(min);
            List<PC> pcmin = pclist
                .Where(cos1 => cos1.Cost == min)
                .ToList();
            foreach (PC cos1 in pcmin)
            {
                Console.WriteLine("Самый дешевый компьютер");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{cos1.Code}  {cos1.Mark}  {cos1.Cpu} {cos1.CpuFreq}  {cos1.RamVal}  {cos1.HddVal}  {cos1.VidMem}  {cos1.Cost}  {cos1.Remains} ");
                Console.ResetColor();
            }
            Console.WriteLine();
            //Поиск компьютера в количестве не менее 30 штук
            bool search = pclist.Any(col => col.Remains >= 30);
            if (search)
            {
                Console.WriteLine("В списке есть компьютеры в количестве более 30 штук");
            }
            else
            {
                Console.WriteLine("В списке нет компьютеров в количестве более 30 штук");
            }     
            Console.ReadKey();
        }
    }
    class PC
    {
        public int Code { get; set; }
        public string Mark { get; set; }
        public string Cpu { get; set; }
        public int CpuFreq { get; set; }
        public int RamVal { get; set; }
        public int HddVal { get; set; }
        public int VidMem { get; set; }
        public int Cost { get; set; }
        public int Remains { get; set; }
    }
}
