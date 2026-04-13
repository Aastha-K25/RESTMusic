using Microsoft.AspNetCore.Mvc;
using RESTMusic;

namespace RESTMusic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MusicController : ControllerBase
{
    private readonly MusicRecordsRepository _repo;

    public MusicController()
    {
        _repo = new MusicRecordsRepository();
    }

    [HttpGet]
    public ActionResult<IEnumerable<MusicRecord>> GetAll()
    {
        var records = _repo.GetAll();

        if (records == null || !records.Any())
        {
            return NoContent(); // 204
        }

        return Ok(records); // 200
    }
}