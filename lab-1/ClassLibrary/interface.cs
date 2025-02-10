using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IMoneyOperation
    {
        void PrintAmount();
        void SetWholeAmount(int amount);
        void SetFractionalAmount(int amount);
    }

    public interface IProductOperation
    {
        void DecreasePrice(int amount);
    }

    public interface IWarehouseOperation
    {
        void UpdateQuantity(int quantity);
        decimal CalculateTotalValue();
    }

    public interface IReportingService
    {
        void RegisterIncome(Warehouse warehouse, int quantity);
        void RegisterExpenditure(Warehouse warehouse, int quantity);
        void GenerateInventoryReport(System.Collections.Generic.List<Warehouse> warehouses);
    }
}
