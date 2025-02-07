using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Reporting
    {
        public static void RegisterIncome(Warehouse warehouse, int quantity)
        {
            warehouse.Quantity += quantity;
            Console.WriteLine($"{quantity} {warehouse.ProductName} додано на склад");
        }

        public static void RegisterExpenditure(Warehouse warehouse, int quantity)
        {
            if (warehouse.Quantity >= quantity)
            {
                warehouse.Quantity -= quantity;
                Console.WriteLine($"{quantity} {warehouse.ProductName} відправлено");
            }
            else
            {
                Console.WriteLine("Недостатньо товару на складі");
            }
        }

        public static void InventoryReport(List<Warehouse> warehouses)
        {
            foreach (var warehouse in warehouses)
            {
                Console.WriteLine($"{warehouse.ProductName}: {warehouse.Quantity} одиниць в наявності");
            }
        }
    }
}
