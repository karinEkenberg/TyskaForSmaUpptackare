using TyskaForSmaUpptackare.Models;

namespace TyskaForSmaUpptackare.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public ContactViewModel Contact { get; set; }
    }

    public class ContactViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
