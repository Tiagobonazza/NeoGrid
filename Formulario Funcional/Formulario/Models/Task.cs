using System.ComponentModel.DataAnnotations;

namespace Formulario.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}