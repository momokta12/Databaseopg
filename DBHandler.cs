using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseOpgApp
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelID { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
    }


    public class Facilitet
    {
        public int FacilitetID { get; set; }
        public string Beskrivelse { get; set; }
    }

    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Facilitet> Facilitet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MOMO;initial Catalog=Obli.Dataopg.; Integrated Security=True;");

        }
    }
}
