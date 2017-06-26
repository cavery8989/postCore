using System;
using Core.Mappers;
using Core.Models.Database;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly UserRepository _userRepository;
    
    public HomeController (DatabaseContext databaseContext) 
    {
        
        _userRepository = new UserRepository(databaseContext);
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
        string email = "test@user.com";
        UserDatabaseModel user = _userRepository.GetByEmail(email);

        var viewModel = UserViewModelMapper.MapFrom(user);
        return View(viewModel);
    }
}