using System.ComponentModel.DataAnnotations;

namespace TyskaForSmaUpptackare.Models
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "E-post krävs")]
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress")]
        public string Email { get; set; }
    }
}
