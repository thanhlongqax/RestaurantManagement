using Microsoft.EntityFrameworkCore;
using TableServices.Models;

namespace TableServices.Context
{
    public class TableContext : DbContext
    {
        public DbSet<Table> tables { get; set; }
        public TableContext(DbContextOptions<TableContext> options) : base(options)
        {
        }
    }
 
}
