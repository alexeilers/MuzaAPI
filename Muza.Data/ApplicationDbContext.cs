using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Muza.Data.Entities;

namespace Muza.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users {get; set;}
        public DbSet<ArtistEntity> Artists {get; set;}
        public DbSet<AlbumEntity> Albums {get; set;}
        public DbSet<ArtistRatingEntity> ArtistRating {get; set;}
        public DbSet<AlbumRatingEntity> AlbumRatings {get; set;}
    }
}