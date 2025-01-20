namespace Vsk.VooDoo.Adapters.Infrastructure.Entityes
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    [Comment("Пользователь")]
    internal class UserEntity
    {
        [Key]
        [Column("ID")]
        [Required]
        public long Id { get;  set; }

        [Required]
        [Comment("Имя пользователя")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Comment("E-mail пользователя")]
        [MaxLength(255)]
        public string Email { get; set; }
    }
}
