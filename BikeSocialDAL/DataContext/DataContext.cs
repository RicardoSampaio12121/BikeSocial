//This file contains the database sets to be created by the entity framework

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
        public DbSet<Place> Places { get; set; }
        public DbSet<TrainingType> TrainingTypes{ get; set; }
        public DbSet<Plan> TrainingPlans { get; set; }
        public DbSet<Trainings> Trainings { get; set; }
        public DbSet<Equipa> Equipa { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<Athlete> Athlete { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<RouteType> RouteTypes{ get; set; }
        public DbSet<TeamDirector> Directors { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<ConAtletaEqui> ConAtletaEqui { get; set; }
        public DbSet<ConCoachEqui> ConCoachEqui { get; set; }
        public DbSet<RoutePeople> RoutePeople { get; set; }
        public DbSet<RoutePeopleInvited> RoutePeopleInvited { get; set; }
        public DbSet<TrainingInvites> TrainingInvites { get; set; }
        public DbSet<RaceResults> RaceResults { get; set; }

        //public DbSet<Friend> Friend { get; set; }

    }
}
