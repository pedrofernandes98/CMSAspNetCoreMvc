
using cmsMvc.Models.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace cmsMVC.Models.Infra.Database
{
    public class CmsDataContext : DbContext
    {
        public CmsDataContext(DbContextOptions<CmsDataContext> options): base(options)
        {
            
        }

        public CmsDataContext() 
        {       
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // JToken configuration = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "apsettings.json")));
            // optionsBuilder.UseSqlServer(configuration["ConnectionStrings"].ToString());
        }

        public DbSet<Administrador> Adminastradores {get; set;}
    }
}