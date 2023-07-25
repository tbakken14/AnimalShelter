using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AnimalShelter.Models;

public class AnimalController : Controller 
{
    [HttpGet("/Animals")]
    public ActionResult Index()
    {
        List<Animal> animals = Animal.GetAll();
        return View(new {animals = animals});
    }

    [HttpPost("/Animals/Delete")]
    public ActionResult Delete(int id)
    {
        Animal.Delete(id);
        return RedirectToAction("Index");
    }

    [HttpGet("Animals/New")]
    public ActionResult New()
    {
        return View();
    }

    [HttpPost("Animals/New")]
    public ActionResult New(string name, string type, string description)
    {
        Animal.Create(name, description, type);
        return RedirectToAction("Index");
    }
}

