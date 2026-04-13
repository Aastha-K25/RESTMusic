namespace RESTMusic;

public class MusicRecordsRepository
{
    private List<MusicRecord> _musicRecords = new List<MusicRecord>();
    private static int nextid = 1;

        public MusicRecordsRepository() { }
    
        public IEnumerable<MusicRecord> GetAll()
        {
            List<MusicRecord> musicRecords = new List<MusicRecord>(_musicRecords);
            return musicRecords;
        }

        public IEnumerable<MusicRecord> Search(string? title, string? artist)
        {
            IEnumerable<MusicRecord> result = _musicRecords;
            if (!string.IsNullOrEmpty(title))
            {
                result = result.Where(m => m.Title.ToLower().Contains(title.ToLower()));
            }

            if (!string.IsNullOrEmpty(artist))
            {
                result = result.Where(m => m.Artist.ToLower().Contains(artist.ToLower()));
            }
            return result;
        }

        public MusicRecord? GetById(int id)
        {
            MusicRecord musicRecord = _musicRecords.FirstOrDefault(m => m.Id == id);
            if (musicRecord == null)
            {
                return null;
            }
            MusicRecord musicRecordCopy = new MusicRecord
            {
                Id = musicRecord.Id,
                Title = musicRecord.Title,
                Artist = musicRecord.Artist,
                Duration = musicRecord.Duration,
                PublicationYear = musicRecord.PublicationYear

            };
            return musicRecordCopy;

        }

        public MusicRecord Add(MusicRecord musicRecord)
        {
            musicRecord.Id = nextid++;
            _musicRecords.Add(musicRecord);

            MusicRecord musicRecordCopy = new MusicRecord
            {
                Id = musicRecord.Id,
                Title = musicRecord.Title,
                Artist = musicRecord.Artist,
                Duration = musicRecord.Duration,
                PublicationYear = musicRecord.PublicationYear
            };
            return musicRecordCopy;

        }

        public MusicRecord? Remove(int id)
        {
            MusicRecord? musicRecord = _musicRecords.FirstOrDefault(m => m.Id == id);
            if (musicRecord == null)
            {
                return null;
            }
            _musicRecords.Remove(musicRecord);

            MusicRecord musicRecordCopy = new MusicRecord
            {
                Id = musicRecord.Id,
                Title = musicRecord.Title,
                Artist = musicRecord.Artist,
                Duration = musicRecord.Duration,
                PublicationYear = musicRecord.PublicationYear
            };
            return musicRecordCopy;

        }
        public MusicRecord? Update(int id, MusicRecord updatedMusicRecord)
        {
            MusicRecord? existing = _musicRecords.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return null;
            }
            existing.Title = updatedMusicRecord.Title;
            existing.Artist = updatedMusicRecord.Artist;
            existing.Duration = updatedMusicRecord.Duration;
            existing.PublicationYear = updatedMusicRecord.PublicationYear;
            MusicRecord musicRecordCopy = new MusicRecord
            {
                Id = existing.Id,
                Title = existing.Title,
                Artist = existing.Artist,
                Duration = existing.Duration,
                PublicationYear = existing.PublicationYear
            };
            return musicRecordCopy;
        }
}