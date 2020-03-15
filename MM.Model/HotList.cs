using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.Model
{
    public class HotList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(5)]
        [MinLength(1)]
        public string Symbol { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Archvied { get; set; } = false;
        [Required]
        public string Image { get; set; }
    }
}
