using RESTMusic.Data;

namespace RESTMusic;

public class MusicRecordsRepository
{
    private readonly MusicContext _context;

    public MusicRecordsRepository(MusicContext context)
    {
        _context = context;
    }
    
        public IEnumerable<MusicRecord> GetAll()
        {
            return _context.MusicRecords.ToList();
        }

        public IEnumerable<MusicRecord> Search(string? title, string? artist)
        {
            var query = _context.MusicRecords.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(m => m.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(artist))
            {
                query = query.Where(m => m.Artist.Contains(artist));
            }

            return query.ToList();
        }

        public MusicRecord? GetById(int id)
        {
            MusicRecord musicRecord = _context.MusicRecords.Find(id);
            if (musicRecord == null)
            {
                return null;
            }

            return musicRecord;
        }

        public MusicRecord Add(MusicRecord musicRecord)
        {
            _context.MusicRecords.Add(musicRecord);
            _context.SaveChanges();
            return musicRecord;
        }

        public MusicRecord? Remove(int id)
        {
            MusicRecord? record = _context.MusicRecords.Find(id);
            
            if (record == null)
            { 
                return null;
            }

            _context.MusicRecords.Remove(record);
            _context.SaveChanges();

            return record;
        }
        public MusicRecord? Update(int id, MusicRecord updated)
        {
            MusicRecord? existing = _context.MusicRecords.Find(id);
            if (existing == null)
            {
                return null;
            }
            
            existing.Title = updated.Title;
            existing.Artist = updated.Artist;
            existing.Duration = updated.Duration;
            existing.PublicationYear = updated.PublicationYear;

            _context.SaveChanges();

            return existing;
           
        }
}