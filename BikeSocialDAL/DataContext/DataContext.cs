//This file contains the database sets to be created by the entity framework

//using BikeSocialEntities;
using Microsoft.EntityFrameworkCore;


namespace BikeSocialDAL.DataContext
{
    /// <summary>
    /// This class contains the database sets to be created
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}
