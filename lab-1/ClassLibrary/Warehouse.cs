using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Warehouse : IWarehouseOperation
    {
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public Money UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime LastReceived { get; set; }

        public Warehouse(string productName, string unit, Money unitPrice, int quantity, DateTime lastReceived)
        {
            ProductName = productName;
            Unit = unit;
            UnitPrice = unitPrice;
            Quantity = quantity;
            LastReceived = lastReceived;
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public decimal CalculateTotalValue()
        {
            return Quantity * UnitPrice.WholeAmount + (decimal)UnitPrice.FractionalAmount / 100;
        }
    }
}
