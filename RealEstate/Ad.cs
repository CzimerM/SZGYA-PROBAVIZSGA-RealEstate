using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    public class Ad
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public int Rooms { get; private set; }
        public int Area { get; private set; }
        public int Floors { get; private set; }
        public Category Category { get; private set; }
        public Seller Seller { get; private set; }
        public bool FreeOfCharge { get; private set; }
        public string ImageUrl { get; private set; }
        public string LatLong { get; private set; }
        public DateTime CreateAt { get; private set; }

        public Ad(int id, string description, int rooms, int area, int floors, Category category, Seller seller, bool freeOfCharge, string imageUrl, string latlong, DateTime createAt)
        {
            Id = id;
            Description = description;
            Rooms = rooms;
            Area = area;
            Floors = floors;
            Category = category;
            Seller = seller;
            FreeOfCharge = freeOfCharge;
            ImageUrl = imageUrl;
            LatLong = latlong;
            CreateAt = createAt;
        }

        public double DistanceTo(string coords)
        {
            List<double> ownCoords = LatLong.Split(',').Select(c => double.Parse(c.Replace('.', ','))).ToList();
            List<double> otherCoords = coords.Split(',').Select(c => double.Parse(c.Replace('.', ','))).ToList();

            return Math.Sqrt(Math.Pow(ownCoords[0] - otherCoords[0], 2) + Math.Pow(ownCoords[1] - otherCoords[1], 2));

        }

        public static List<Ad> LoadFromCsv(string csvPath)
        {
            StreamReader sr = new StreamReader(csvPath, Encoding.UTF8);
            _ = sr.ReadLine();
            List<Ad> ads = new List<Ad>();
            while (!sr.EndOfStream) 
            {
                string[] data = sr.ReadLine().Split(';');
                ads.Add(new Ad(
                    id: int.Parse(data[0]),
                    rooms: int.Parse(data[1]),
                    latlong: data[2],
                    floors: int.Parse(data[3]),
                    area: int.Parse(data[4]),
                    category: new Category(int.Parse(data[12]), data[13]),
                    seller: new Seller(int.Parse(data[9]), data[10], data[11]),
                    description: data[5],
                    freeOfCharge: data[6] == "1",
                    imageUrl: data[7],
                    createAt: DateTime.Parse(data[8])
                ));
            }
            return ads;
        }
    }
}
