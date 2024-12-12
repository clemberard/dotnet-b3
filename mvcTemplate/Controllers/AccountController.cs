using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
public class AccountController : Controller
{
    private readonly SignInManager<Account> _signInManager;
    private readonly UserManager<Account> _userManager;
    public AccountController(SignInManager<Account> signInManager, UserManager<Account> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult LoginTeacher()
    {
        return View();
    }

    public IActionResult LoginStudent()
    {
        return View();
    }

    public IActionResult RegisterTeacher()
    {
        return View();
    }

    public IActionResult RegisterStudent()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterTeacher(AccountViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = new Teacher
        {
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            Email = model.Email,
            UserName = (model.Firstname + model.Lastname).ToLower()
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home"); 
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterStudent(AccountViewModelStudent model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = new Student
        {
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            Age = model.Age,
            UserName = (model.Firstname + model.Lastname).ToLower()
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Student");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> LoginTeacher(LogInViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var user = await _userManager.FindByEmailAsync(model.Email);
        var result = await _signInManager.PasswordSignInAsync(user?.UserName!, model.Password, false, false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> LoginStudent(LogInStudentViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Student");
        }

        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        return View(model);
    }
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}