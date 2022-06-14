namespace GaoXiaoAsp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LendingStatu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LendingID { get; set; }

        public int UserID { get; set; }

        public int DiscussionRoom { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int NumberOfPeople { get; set; }

        public int? Lid { get; set; }

        public byte IsExpired { get; set; }

        public virtual DiscussionRoom DiscussionRoom1 { get; set; }

        public virtual Librarian Librarian { get; set; }

        public virtual User User { get; set; }
    }
}
