namespace GaoXiaoAsp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiscussionRoom")]
    public partial class DiscussionRoom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiscussionRoom()
        {
            LendingStatus = new HashSet<LendingStatu>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rid { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomNumber { get; set; }

        public int Floors { get; set; }

        [Required]
        [StringLength(20)]
        public string RoomType { get; set; }

        [Required]
        [StringLength(20)]
        public string RoomAccess { get; set; }

        public int? MinSize { get; set; }

        public int? MaxSize { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LendingStatu> LendingStatus { get; set; }
    }
}
