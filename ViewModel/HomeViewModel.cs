using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using TyskaForSmaUpptackare.Models;

namespace TyskaForSmaUpptackare.ViewModel
{
    public class HomeViewModel
    {
        [BindNever]
        public IEnumerable<Product> Products { get; set; }
        public ContactViewModel Contact { get; set; }
    }

    public class ContactViewModel
    {
        [Required(ErrorMessage = "Namn är obligatoriskt.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-post är obligatorisk.")]
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Meddelande får inte vara tomt.")]
        public string Message { get; set; }

        public bool MessageSent { get; set; } = false;
    }
}
