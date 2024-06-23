using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pcrepairshop.Data;
using pcrepairshop.Models;

namespace pcrepairshop.Controllers
{
    public class UserController : Controller
    {
        private readonly PCrepairshopDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(PCrepairshopDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var result = await _context.User.ToListAsync();
            return View(result);
        }

        //Users Register
        [HttpGet]
        public IActionResult Register()
        {
            var response = new User();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }

            var newUserResponse = await _userManager.CreateAsync(registerViewModel, registerViewModel.PasswordHash);

            if (newUserResponse.Succeeded)
            {
                var newUser = await _userManager.FindByEmailAsync(registerViewModel.Email);
                if (newUser == null)
                {
                    TempData["Error"] = "Error creating user";
                    return View(registerViewModel);
                }
                await _userManager.AddToRoleAsync(newUser, "Users");
            }

            return RedirectToAction("Index", "Home");
        }

        //Employees Register
        [HttpGet]
        public IActionResult EmployeeRegister()
        {
            var response = new User();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterEmployee(User registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }

            var newUserResponse = await _userManager.CreateAsync(registerViewModel, registerViewModel.PasswordHash);

            if (newUserResponse.Succeeded)
            {
                var newUser = await _userManager.FindByEmailAsync(registerViewModel.Email);
                if (newUser == null)
                {
                    TempData["Error"] = "Error creating user";
                    return View(registerViewModel);
                }
                await _userManager.AddToRoleAsync(newUser, "Employees");
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Login()
        {
            var response = new User();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(User loginViewModel)
        {
            //if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user != null)
            {
                //User is found, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.PasswordHash);
                if (passwordCheck)
                {
                    //Password correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.PasswordHash, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                //Password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginViewModel);
            }
            //User not found
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



    }
}
