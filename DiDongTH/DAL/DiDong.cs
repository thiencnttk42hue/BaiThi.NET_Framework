namespace DiDongTH.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiDong")]
    public partial class DiDong
    {
        public long id { get; set; }

        [Required]
        [StringLength(50)]
        public string tendd { get; set; }

        [StringLength(255)]
        public string thongsokythuat { get; set; }

        public long? gia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaynhap { get; set; }

        [StringLength(50)]
        public string noisanxuat { get; set; }
    }
}
