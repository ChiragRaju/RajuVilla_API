using Microsoft.EntityFrameworkCore;
using Raju_VillaAPI.Models;

namespace Raju_VillaAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }
        public DbSet<Villas> villass {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villas>().HasData(
                new Villas()
                {
                    Id = 1,
                    Name = "RoyalVilla",
                    Details = "This exquisite villa is nestled along the pristine shores of Malibu, California, offering breathtaking ocean views from every room. ",
                    ImageUrl = "https://media.istockphoto.com/id/1177798051/photo/modern-house-with-terrace-and-a-swimming-pool.jpg?s=612x612&w=is&k=20&c=HOSI3bLneTix9-nZnGrd0TlDFAE-erolwhen6PjxBiw=",
                    Occupancy = 4,
                    Rate = 200,
                    Sq = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                },
                new Villas()
                {
                    Id = 2,
                    Name = "QueenVilla",
                    Details = "Located in the heart of the Tuscan countryside, this charming villa exudes old-world charm with its terracotta roof, lush vineyards, and olive groves. ",
                    ImageUrl = "https://media.istockphoto.com/id/1177798051/photo/modern-house-with-terrace-and-a-swimming-pool.jpg?s=612x612&w=is&k=20&c=HOSI3bLneTix9-nZnGrd0TlDFAE-erolwhen6PjxBiw=",
                    Occupancy = 4,
                    Rate = 200,
                    Sq = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                },
                new Villas()
                {
                    Id = 3,
                    Name = "PrinceVilla",
                    Details = "Situated in the prestigious Emirates Hills, this ultramodern villa boasts sleek, cutting-edge design and smart home automation.",
                    ImageUrl = "https://photos.homerez.com/v7/_S3-photos_/41250449/E1sXLAlrTsrlPvid26kYBnMIofmloaQRMMQP8WKea/url.jpg?h=800&optipress=2",
                    Occupancy = 4,
                    Rate = 200,
                    Sq = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                });

        }
    }
}
