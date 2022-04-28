using System.ComponentModel.DataAnnotations;

namespace PersonalCodeApi
{
    public class PersonalCode
    {
        [Key]
        public string? Code { get; set; }
        public string? Message { get; set; }

    }
}