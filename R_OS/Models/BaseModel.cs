using System.ComponentModel.DataAnnotations;

namespace R_OS.Models
{
    public class BaseModel
    {
        [Key]
        public Guid UUID { get; set; } = Guid.NewGuid();
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
