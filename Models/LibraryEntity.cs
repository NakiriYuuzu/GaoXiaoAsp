using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GaoXiaoAsp.Models
{
    public partial class LibraryEntity : DbContext
    {
        public LibraryEntity()
            : base("name=LibraryEntitys")
        {
        }

        public virtual DbSet<DiscussionRoom> DiscussionRooms { get; set; }
        public virtual DbSet<LendingStatu> LendingStatus { get; set; }
        public virtual DbSet<Librarian> Librarians { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscussionRoom>()
                .Property(e => e.RoomNumber)
                .IsUnicode(false);

            modelBuilder.Entity<DiscussionRoom>()
                .Property(e => e.RoomType)
                .IsUnicode(false);

            modelBuilder.Entity<DiscussionRoom>()
                .Property(e => e.RoomAccess)
                .IsUnicode(false);

            modelBuilder.Entity<DiscussionRoom>()
                .HasMany(e => e.LendingStatus)
                .WithRequired(e => e.DiscussionRoom1)
                .HasForeignKey(e => e.DiscussionRoom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Librarian>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Librarian>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Librarian>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Sid)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LendingStatus)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
