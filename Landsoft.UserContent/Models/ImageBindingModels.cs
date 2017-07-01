using System.ComponentModel.DataAnnotations;

namespace Landsoft.UserContent.Models
{
    public class CreateImageBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string MimeType { get; set; }

        public byte[] Data { get; set; }
    }
}