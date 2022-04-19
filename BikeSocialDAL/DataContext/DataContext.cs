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
        
        //-----------------------Definição das tabelas--------------------------------------------//

        public DbSet<Users> Users { get; set; }
        public DbSet<UserTypes> UserTypes { get; set; }
        public DbSet<PasswordRecoveryCodes> PasswordRecoveryCodes { get; set; }

        public DbSet<Places> Places { get; set; }
        
        public DbSet<Athletes> Athletes { get; set; }
        public DbSet<AthleteTypes> AthleteTypes { get; set; }
        public DbSet<AthleteParents> AthleteParents { get; set; }
        public DbSet<AthleteFederationRequests> AthleteFederationRequests { get; set; }

        public DbSet<Teams> Teams { get; set; }
        public DbSet<TeamInviteAthletes> TeamInviteAthletes { get; set; }
        public DbSet<TeamInviteCoaches> TeamInviteCoaches { get; set; }
        public DbSet<TeamFederationRequests> TeamFederationRequests  { get; set; }

        public DbSet<Races> Races { get; set; }
        public DbSet<RaceTypes> RaceTypes { get; set; }
        public DbSet<RaceInvites> RaceInvites { get; set; }
        public DbSet<RaceResults> RaceResults { get; set; }

        public DbSet<Trainings> Trainings { get; set; }
        public DbSet<TrainingInvites> TrainingInvites { get; set; }
        public DbSet<TrainingTypes> TrainingTypes { get; set; }

        public DbSet<Routes> Routes { get; set; }
        public DbSet<RouteTypes> RouteTypes { get; set; }
        public DbSet<RouteInvites> RouteInvites { get; set; }

        public DbSet<Coaches> Coaches { get; set; }

        public DbSet<Clubs> Clubs { get; set; }

        public DbSet<Directors> Directors { get; set; }
        public DbSet<DirectorTypes> DirectorTypes { get; set; }

        public DbSet<Federations> Federations { get; set; }

        public DbSet<Friend> Friend { get; set; }

        public DbSet<Profile> Profiles { get; set; }
        
        public DbSet<Achievements> Achievements { get; set; }
        public DbSet<AchievementTypes> AchievementTypes { get; set; }
        public DbSet<AthleteAchievements> AthleteAchievements { get; set; }
        public DbSet<ProfileAchievements> ProfileAchievements { get; set; }
        
        public DbSet<Prizes> Prizes { get; set; }
        
        public DbSet<Plans> Plans { get; set; }
    }
}
