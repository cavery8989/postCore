using System;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [HttpGet("/")]
    public ActionResult Index()
    {
        ViewBag.Message = "Hello";
        ViewBag.Time = DateTime.Now;

        string name = "sian";

        ViewBag.name = name;

        return View();
    }
}