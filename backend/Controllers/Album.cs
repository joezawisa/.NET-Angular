namespace PhotosApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PhotosApi.Entities;

[ApiController]
[Route("[controller]")]
public class AlbumsController : ControllerBase
{
    private List<Album> _albums = new List<Album>
    {
        new Album { Id = 1, Name = "Holidays" },
        new Album { Id = 2, Name = "Parties" }
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_albums);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var album = _albums.Find(x => (x.Id == id));
        if (album == null)
            return NotFound();

        return Ok(album);
    }
}