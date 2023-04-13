using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LINQ__5
{
    internal class Program
    {
        public static void Main()
        {
            const int currentYear = 2023;
            
            PreserveFactory preserveFactory = new PreserveFactory();
            List<Preserve> preserves = new List<Preserve>(preserveFactory.Create());

            Console.WriteLine("Все запасы");
            preserves.ForEach(preserve=>preserve.ShowInfo());
            
            var overduePreserves = preserves.Where(preserve => preserve.ExpirationDate < currentYear).ToList();

            Console.WriteLine(new string('_',40));
            Console.WriteLine("Просрочка");
            overduePreserves.ForEach(overduePreserve=>overduePreserve.ShowInfo());
        }
    }

    public class Preserve
    {
        private readonly int _dateOfProduction;
        private string _name = "консервы";

        public Preserve(int dateOfProduction, int shelfLife)
        {
            _dateOfProduction = dateOfProduction;
            ExpirationDate = dateOfProduction + shelfLife;
        }

        public int ExpirationDate { get; }

        public void ShowInfo()
        {
            Console.WriteLine(
                $"{_name} | дата производства {_dateOfProduction} |дата конца срока годности  {ExpirationDate}");
        }
    }

    public class PreserveFactory
    {
        private static readonly Random _random = new Random();

        public List<Preserve> Create()
        {
            const int MaxCountPreserves = 15;
            const int MinCountPreserves = 5;

            const int MinDateOfProduction = 2019;
            const int MaxDateOfProduction = 2023;

            const int MinShelfLife = 1;
            const int MaxShelfLife = 6;

            int countPreserves = _random.Next(MinCountPreserves, MaxCountPreserves + 1);
            List<Preserve> preserves = new List<Preserve>();
            int dateOfProduction;
            int shelfLife;
            
            for (int i = 0; i < countPreserves; i++)
            {
                dateOfProduction = _random.Next(MinDateOfProduction, MaxDateOfProduction + 1);
                shelfLife = _random.Next(MinShelfLife, MaxShelfLife + 1);
                preserves.Add(new Preserve(dateOfProduction,shelfLife));
            }

            return preserves;
        }
    }
}