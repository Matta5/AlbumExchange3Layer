using Albums3Layer.BLL;
using Microsoft.AspNetCore.Mvc;
using Albums3Layer.Models;
using DAL;
using Albums3Layer.BBL.Models;

namespace Albums3Layer.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;

        public UserController()
        {
            userService = new UserService(new UserRepository());
        }

        public IActionResult Index()
        {
            List<User> users = userService.GetAllUsers();
            return View(users);
        }

        
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            User user = userService.GetUserById(id);
            if (user == null)
            {
                return View();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user, IFormFile profilePicture)
        {
            try
            {
                // Check if a file has been uploaded
                if (profilePicture != null)
                {
                    // Check if the file is an image
                    var extension = Path.GetExtension(profilePicture.FileName).ToLower();
                    if (extension != ".jpg" && extension != ".png")
                    {
                        ModelState.AddModelError("", "Invalid file type. Only JPG and PNG file types are allowed.");
                        return View(user);
                    }

                    // Save the profile picture to wwwroot/Images and get the file path
                    var fileName = Path.GetFileName(profilePicture.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await profilePicture.CopyToAsync(fileStream);
                    }

                    // Save the relative file path to the database
                    user.profile_picture = Path.Combine("Images", fileName);
                }

                // User creation logic
                userService.CreateUser(user);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        // Other actions...
    }
}
