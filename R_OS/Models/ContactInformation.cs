using System.ComponentModel.DataAnnotations;

namespace R_OS.Models
{
    public class ContactInformation : BaseModel
    {
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? Location { get; set; }
        public string? Content { get; set; }
        public Guid PersonUUID { get; set; }
    }
}
