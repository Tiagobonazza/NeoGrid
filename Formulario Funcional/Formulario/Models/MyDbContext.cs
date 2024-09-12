using MySql.Data.EntityFramework;
using System.Data.Entity;

namespace Formulario.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyDbContext") { }

        public DbSet<Task> Tasks { get; set; }
    }
}