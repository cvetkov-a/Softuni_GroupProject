namespace FitnessHardSoft
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActivityLogs
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainingName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Exercises { get; set; }

        public int UserID { get; set; }

        public virtual Users Users { get; set; }
    }
}
