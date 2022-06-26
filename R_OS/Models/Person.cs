using System.ComponentModel.DataAnnotations;

namespace R_OS.Models
{
    public class Person : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public virtual List<ContactInformation> ContactInfo { get; set; }
    }
}
