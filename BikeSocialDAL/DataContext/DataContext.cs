//This file contains the database sets to be created by the entity framework

//using BikeSocialEntities;
using Microsoft.EntityFrameworkCore;
using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialDAL.DataContext
{
    /// <summary>
    /// This class contains the database sets to be created
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer("Server = localhost; Database = BikeSocialDB; Trusted_Connection = True;");



        public DbSet<User> Users { get; set; }
<<<<<<< HEAD
        public DbSet<Place> Places { get; set; }
        public DbSet<TrainingType> TrainingTypes{ get; set; }
        public DbSet<Plan> TrainingPlans { get; set; }
        public DbSet<Trainings> Trainings { get; set; }
=======

        

        public DbSet<Equipa> Equipa { get; set; }
>>>>>>> 2d67ca2d623fafb7141890589669ed820423fd2c
    }
}
