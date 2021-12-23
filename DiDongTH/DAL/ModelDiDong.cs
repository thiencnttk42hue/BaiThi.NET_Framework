using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DiDongTH.DAL
{
    public partial class ModelDiDong : DbContext
    {
        public ModelDiDong()
            : base("name=ModelDiDongTH")
        {
        }

        public virtual DbSet<DiDong> DiDong { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
