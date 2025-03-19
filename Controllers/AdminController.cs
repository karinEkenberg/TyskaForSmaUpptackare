using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Climate;
using TyskaForSmaUpptackare.Data;

namespace TyskaForSmaUpptackare.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AdminController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("lägg-till-bilder-och-ljud")]
		[HttpGet]
        public IActionResult AddImagesAndAudio()
        {
			var imgPath = Path.Combine(_env.WebRootPath, "img");
			List<string> images = new List<string>();

			if (Directory.Exists(imgPath))
			{
				var allowedExtensions = new[] { ".png", ".webp" };
				images = Directory.GetFiles(imgPath)
					.Where(f => allowedExtensions.Contains(Path.GetExtension(f).ToLower()))
					.Select(f => Path.GetFileName(f))
					.ToList();
			}

			ViewBag.Images = images;
			return View();
        }

        [Route("kunders-kop")]
        public async Task<IActionResult> Orders()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();
            return View(orders);
        }

		[HttpPost]
		public async Task<IActionResult> UploadImage(IFormFile imageFile)
		{
			if (imageFile == null || imageFile.Length == 0)
			{
				ModelState.AddModelError("", "Ingen bildfil vald.");
				return View("AddImagesAndAudio");
			}

			var allowedExtensions = new[] { ".png", ".webp" };
			var fileExtension = Path.GetExtension(imageFile.FileName)?.ToLower();

			if (Array.IndexOf(allowedExtensions, fileExtension) < 0)
			{
				ModelState.AddModelError("", "Felaktig filtyp. Endast .png och .webp tillåts för bilder.");
				return View("AddImagesAndAudio");
			}

			var imgPath = Path.Combine(_env.WebRootPath, "img");
			if (!Directory.Exists(imgPath))
			{
				Directory.CreateDirectory(imgPath);
			}

			var fileName = Path.GetFileName(imageFile.FileName);
			var fullPath = Path.Combine(imgPath, fileName);

			try
			{
				using (var stream = new FileStream(fullPath, FileMode.Create))
				{
					await imageFile.CopyToAsync(stream);
				}
				ViewBag.ImageMessage = "Bild uppladdad!";
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "Ett fel inträffade vid uppladdning av bilden: " + ex.Message);
			}

			return View("AddImagesAndAudio");
		}

		[HttpPost]
		public async Task<IActionResult> UploadAudio(IFormFile audioFile)
		{
			if (audioFile == null || audioFile.Length == 0)
			{
				ModelState.AddModelError("", "Ingen ljudfil vald.");
				return View("AddImagesAndAudio");
			}

			var allowedExtensions = new[] { ".mp3" };
			var fileExtension = Path.GetExtension(audioFile.FileName)?.ToLower();

			if (Array.IndexOf(allowedExtensions, fileExtension) < 0)
			{
				ModelState.AddModelError("", "Felaktig filtyp. Endast .mp3 tillåts för ljud.");
				return View("AddImagesAndAudio");
			}

			var audioPath = Path.Combine(_env.WebRootPath, "audio");
			if (!Directory.Exists(audioPath))
			{
				Directory.CreateDirectory(audioPath);
			}

			var fileName = Path.GetFileName(audioFile.FileName);
			var fullPath = Path.Combine(audioPath, fileName);

			try
			{
				using (var stream = new FileStream(fullPath, FileMode.Create))
				{
					await audioFile.CopyToAsync(stream);
				}
				ViewBag.AudioMessage = "Ljudfil uppladdad!";
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "Ett fel inträffade vid uppladdning av ljudfilen: " + ex.Message);
			}

			return View("AddImagesAndAudio");
		}

		[HttpGet]
		public JsonResult GetImageListJson()
		{
			var imgPath = Path.Combine(_env.WebRootPath, "img");
			List<string> images = new List<string>();

			if (Directory.Exists(imgPath))
			{
				var allowedExtensions = new[] { ".png", ".webp" };
				images = Directory.GetFiles(imgPath)
					.Where(f => allowedExtensions.Contains(Path.GetExtension(f).ToLower()))
					.Select(f => Path.GetFileName(f))
					.ToList();
			}

			return Json(images);
		}
	}
}