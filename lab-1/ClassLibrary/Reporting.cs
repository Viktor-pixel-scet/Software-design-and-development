using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class ReportingService : IReportingService
    {
        public void RegisterIncome(Warehouse warehouse, int quantity)
        {
            warehouse.Quantity += quantity;
            Console.WriteLine($"{quantity} {warehouse.ProductName} додано на склад");
        }

        public void RegisterExpenditure(Warehouse warehouse, int quantity)
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

        public void GenerateInventoryReport(List<Warehouse> warehouses)
        {
            foreach (var warehouse in warehouses)
            {
                Console.WriteLine($"{warehouse.ProductName}: {warehouse.Quantity} одиниць в наявності");
            }
        }
    }
}