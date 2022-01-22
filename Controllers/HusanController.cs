using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test1.Data;
using test1.Entity;
using test1.Models;

namespace test1.Controllers;

public class HusanController : Controller
{
    private readonly ILogger<HusanController> _logger;
    private readonly PostDbContext _db;

    public HusanController(ILogger<HusanController> logger,PostDbContext cop)
    {
        _logger = logger;
        _db=cop;
    }
    

    public IActionResult Index()
    {
        var posts=_db.posts;
        var pl=new List<PostEntity>();
        foreach (var item in posts)
        {
            pl.Add(item);
        }
        return View(pl);
    }

    [HttpGet]
    public IActionResult Write()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Write(Post model)
    {
        var res = model.ToEntity(model);
        _db.Add(res);
        _db.SaveChanges();

        return LocalRedirect($"~/Husan/Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
