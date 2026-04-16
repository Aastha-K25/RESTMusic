using Microsoft.AspNetCore.Mvc;
using RESTMusic;

namespace RESTMusic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MusicController : ControllerBase
{
    private readonly MusicRecordsRepository _repo;

    public MusicController(MusicRecordsRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("GetAll")]
    public ActionResult<IEnumerable<MusicRecord>> GetAll()
    {
        var records = _repo.GetAll();

        if (records == null || !records.Any())
        {
            return NoContent(); // 204
        }

        return Ok(records); // 200
    }

    [HttpGet("GetById")]
    public ActionResult<MusicRecord> GetById(int id)
    {
        var record = _repo.GetById(id);
        if (record == null)
        {
            return NotFound();
        }
        return Ok(record);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<MusicRecord>> Search(string? title, string? artist)
    {
        var records = _repo.Search(title, artist);

        if (!records.Any())
        {
            return NoContent();
        }

        return Ok(records);
    }

    [HttpPost("Add")]
    public ActionResult<MusicRecord> Add(MusicRecord newRecord)
    {
        if (newRecord == null || string.IsNullOrEmpty(newRecord.Title))
        {
            return BadRequest("Title mangler");
        }

        var created = _repo.Add(newRecord);

        return Created($"api/music/{created.Id}", created);
    }

    [HttpPut("Update")]
    public ActionResult<MusicRecord> Update(int id, MusicRecord updated)
    {  
        if (updated == null)
        {
            return BadRequest();
        }

        var record = _repo.Update(id, updated);
        if (record == null)
        {
            return NotFound();
        }
        
        return Ok(record);
    }

    [HttpDelete("Delete")]
    public ActionResult<MusicRecord> Delete(int id)
    {
        var record = _repo.Remove(id);

        if (record == null)
        {
            return NotFound();
        }
        return Ok(record);
    }
    
    
}