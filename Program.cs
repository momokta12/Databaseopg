using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DatabaseOpgApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Vælg en operation: ");
                Console.WriteLine("1: Tilføj Hotel");
                Console.WriteLine("2: Vis Hoteller");
                Console.WriteLine("3: Opdater Hotel");
                Console.WriteLine("4: Slet Hotel");
                Console.WriteLine("5: Tilføj Facilitet");
                Console.WriteLine("6: Vis Faciliteter");
                Console.WriteLine("7: Opdater Facilitet");
                Console.WriteLine("8: Slet Facilitet");
                Console.WriteLine("9: Exit");
                var valg = Console.ReadLine();

                switch (valg)
                {
                    case "1":
                        TilføjHotel();
                        break;
                    case "2":
                        VisHotel();
                        break;
                    case "3":
                        OpdaterHotel();
                        break;
                    case "4":
                        SletHotel();
                        break;
                    case "5":
                        TilføjFacilitet();
                        break;
                    case "6":
                        VisFaciliteter();
                        break;
                    case "7":
                        OpdaterFacilitet();
                        break;
                    case "8":
                        SletFacilitet();
                        break;
                    case "9":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        break;
                }
            }
        }

        static void TilføjHotel()
        {
            try
            {
                Console.WriteLine("Indtast hotelnavn:");
                string navn = Console.ReadLine();
                Console.WriteLine("Indtast adresse:");
                string adresse = Console.ReadLine();

                var hotel = new Hotel { Navn = navn, Adresse = adresse };

                using (var db = new HotelDbContext())
                {
                    db.Hotel.Add(hotel);
                    db.SaveChanges();
                }

                Console.WriteLine("Hotel tilføjet.");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Der opstod en fejl under opdatering af databasen: {ex.InnerException.Message}");
            }
        }

        static void VisHotel()
        {
            using (var db = new HotelDbContext())
            {
                var hoteller = db.Hotel.ToList();
                foreach (var hotel in hoteller)
                {
                    Console.WriteLine($"ID: {hotel.HotelID}, Navn: {hotel.Navn}, Adresse: {hotel.Adresse}");
                }
            }
        }

        static void OpdaterHotel()
        {
            Console.WriteLine("Indtast ID for det hotel, du vil opdatere:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast nyt navn:");
            string nytNavn = Console.ReadLine();
            Console.WriteLine("Indtast ny adresse:");
            string nyAdresse = Console.ReadLine();

            using (var db = new HotelDbContext())
            {
                var hotel = db.Hotel.Find(id);
                if (hotel != null)
                {
                    hotel.Navn = nytNavn;
                    hotel.Adresse = nyAdresse;
                    db.SaveChanges();
                    Console.WriteLine("Hotel opdateret.");
                }
                else
                {
                    Console.WriteLine("Hotel ikke fundet.");
                }
            }
        }

        static void SletHotel()
        {
            Console.WriteLine("Indtast ID for det hotel, du vil slette:");
            int id = int.Parse(Console.ReadLine());

            using (var db = new HotelDbContext())
            {
                var hotel = db.Hotel.Find(id);
                if (hotel != null)
                {
                    db.Hotel.Remove(hotel);
                    db.SaveChanges();
                    Console.WriteLine("Hotel slettet.");
                }
                else
                {
                    Console.WriteLine("Hotel ikke fundet.");
                }
            }
        }

        static void TilføjFacilitet()
        {
            Console.WriteLine("Indtast facilitetnavn:");
            string navn = Console.ReadLine();

            var facilitet = new Facilitet { Beskrivelse = navn };

            using (var db = new HotelDbContext())
            {
                db.Facilitet.Add(facilitet);
                db.SaveChanges();
            }

            Console.WriteLine("Facilitet tilføjet.");
        }

        static void VisFaciliteter()
        {
            using (var db = new HotelDbContext())
            {
                var faciliteter = db.Facilitet.ToList();
                foreach (var facilitet in faciliteter)
                {
                    Console.WriteLine($"ID: {facilitet.FacilitetID}, Navn: {facilitet.Beskrivelse}");
                }
            }
        }

        static void OpdaterFacilitet()
        {
            Console.WriteLine("Indtast ID for den facilitet, du vil opdatere:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast nyt navn:");
            string nytNavn = Console.ReadLine();

            using (var db = new HotelDbContext())
            {
                var facilitet = db.Facilitet.Find(id);
                if (facilitet != null)
                {
                    facilitet.Beskrivelse = nytNavn;
                    db.SaveChanges();
                    Console.WriteLine("Facilitet opdateret.");
                }
                else
                {
                    Console.WriteLine("Facilitet ikke fundet.");
                }
            }
        }

        static void SletFacilitet()
        {
            Console.WriteLine("Indtast ID for den facilitet, du vil slette:");
            int id = int.Parse(Console.ReadLine());

            using (var db = new HotelDbContext())
            {
                var facilitet = db.Facilitet.Find(id);
                if (facilitet != null)
                {
                    db.Facilitet.Remove(facilitet);
                    db.SaveChanges();
                    Console.WriteLine("Facilitet slettet.");
                }
                else
                {
                    Console.WriteLine("Facilitet ikke fundet.");
                }
            }
        }
    }
}
