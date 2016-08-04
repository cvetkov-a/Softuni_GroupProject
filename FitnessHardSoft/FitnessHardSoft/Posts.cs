namespace FitnessHardSoft
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Posts
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string ContentOfPost { get; set; }

        public int? AuthorID { get; set; }

        public int? TitleID { get; set; }

        public virtual News News { get; set; }

        public virtual Users Users { get; set; }
    }
}
