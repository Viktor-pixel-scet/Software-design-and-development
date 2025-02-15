using task_2;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        var runways = new Runway[]
        {
                new Runway(),
                new Runway()
        };

        var aircrafts = new Aircraft[]
        {
                new Aircraft("Boeing 747", 100),
                new Aircraft("Airbus A320", 80),
                new Aircraft("Boeing 737", 70)
        };

        var commandCentre = new CommandCentre(runways, aircrafts);

        aircrafts[0].Land();
        aircrafts[1].Land();
        aircrafts[2].Land();

        aircrafts[0].TakeOff();
        aircrafts[2].Land();

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }
}