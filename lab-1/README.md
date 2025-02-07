## 1. Single Responsibility Principle (SRP)
Each class has a clear, focused responsibility:
- `Money`: Manages currency representation
- `Product`: Handles product details and price modifications
- `Warehouse`: Tracks inventory information
- `Reporting`: Manages inventory operations

Example in [Warehouse.cs, рядок 11](https://github.com/Viktor-pixel-scet/Software-design-and-development/lab-1/ClassLibrary/Warehouse.cs#L11):
```csharp
public class Warehouse
{
    // Each property represents a single aspect of warehouse inventory
    public string ProductName { get; set; }
    public string Unit { get; set; }
    public Money UnitPrice { get; set; }
    public int Quantity { get; set; }
    public DateTime LastReceived { get; set; }
}
```

## 2. Open/Closed Principle
Classes are open for extension but closed for modification:
- `Product.DecreasePrice()` allows price modification without changing core logic
- `Reporting` methods can be extended without modifying existing code

Example in [Product.cs, рядок 22](https://github.com/Viktor-pixel-scet/Software-design-and-development/lab-1/ClassLibrary/Product.cs#L22):
```csharp
public void DecreasePrice(int amount)
{
    int newWholeAmount = Price.WholeAmount - amount;
    if (newWholeAmount < 0) newWholeAmount = 0;
    Price.SetWholeAmount(newWholeAmount);
}
```

## 3. DRY (Don't Repeat Yourself)
Reusable methods and centralized logic prevent code duplication:
- `Reporting` class contains centralized inventory management methods
- Consistent error handling in operations

Example in [Reporting.cs, рядок 17](https://github.com/Viktor-pixel-scet/Software-design-and-development/lab-1/ClassLibrary/Reporting.cs#L17):
```csharp
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
```

## 4. KISS (Keep It Simple, Stupid)
Simple, straightforward implementations:
- Methods do one thing
- Clear, readable naming conventions
- Minimal complexity in logic

## 5. Fail Fast
Immediate validation and error checking:
- `RegisterExpenditure` checks quantity before processing
- Prevents invalid operations early in the process

## 6. Composition Over Inheritance
Favors object composition:
- `Warehouse` contains `Money` as a composition
- Flexible design allowing easier modifications

## 7. Program to Interfaces not Implementations
While not explicitly used, the design allows for easy interface implementation:
- Methods could be easily refactored to work with interfaces
- Loose coupling between classes

## Additional Notes
- Demonstrates basic principles of clean, maintainable code
- Provides a simple yet extensible warehouse management system