namespace RealEstate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<Ad> ads = Ad.LoadFromCsv("../../../src/realestates.csv");
            Console.WriteLine($"1. Földszinti ingatlanok átlagos alapterülete: {Math.Round(ads.Where(a => a.Floors == 0).Average(a => a.Area), 2)} m2");
            var meseOvodahozLegkozelebb = ads.MinBy(a => a.DistanceTo("47.4164220114023,19.066342425796986"));
            Console.WriteLine("2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai:");
            Console.WriteLine($"\t{"Eladó neve",-15}: {meseOvodahozLegkozelebb.Seller.Name}");
            Console.WriteLine($"\t{"Eladó telefonja",-15}: {meseOvodahozLegkozelebb.Seller.Phone}");
            Console.WriteLine($"\t{"Alapterület",-15}: {meseOvodahozLegkozelebb.Area}");
            Console.WriteLine($"\t{"Szobák száma",-15}: {meseOvodahozLegkozelebb.Rooms}");
            
        }
    }
}
