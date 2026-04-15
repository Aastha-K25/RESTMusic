using Microsoft.EntityFrameworkCore;
using RESTMusic;

namespace RESTMusic.Data;

public class MusicContext : DbContext
{
    public MusicContext(DbContextOptions<MusicContext> options) : base(options)
    {
    }
    public DbSet<MusicRecord> MusicRecords { get; set; }

}