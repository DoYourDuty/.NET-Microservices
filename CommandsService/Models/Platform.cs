using System.ComponentModel.DataAnnotations;

namespace CommandsService.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ExTernalID { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}