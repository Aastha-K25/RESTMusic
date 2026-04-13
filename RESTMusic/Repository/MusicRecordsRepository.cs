namespace RESTMusic;

public class MusicRecordsRepository
{
    private List<MusicRecord> _musicRecords = new List<MusicRecord>();
    private static int nextid = 1;

        public MusicRecordsRepository() { }

        // læs om readonly collections i C# og overvej at bruge det i stedet for at returnere en kopi af listen, tænk på pladsen listen bruger i hukommelsen, og om det er nødvendigt at returnere en kopi af listen, eller om det er nok at returnere en readonly collection, som ikke kan ændres uden for klassen.
        public IEnumerable<MusicRecord> GetAll()
        {
            List<MusicRecord> musicRecords = new List<MusicRecord>(_musicRecords);
            return musicRecords;
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
            MusicRecord? existingMusicRecord = _musicRecords.FirstOrDefault(m => m.Id == id);
            if (existingMusicRecord == null)
            {
                return null;
            }
            existingMusicRecord.Title = updatedMusicRecord.Title;
            existingMusicRecord.Artist = updatedMusicRecord.Artist;
            existingMusicRecord.Duration = updatedMusicRecord.Duration;
            existingMusicRecord.PublicationYear = updatedMusicRecord.PublicationYear;
            MusicRecord musicRecordCopy = new MusicRecord
            {
                Id = existingMusicRecord.Id,
                Title = existingMusicRecord.Title,
                Artist = existingMusicRecord.Artist,
                Duration = existingMusicRecord.Duration,
                PublicationYear = existingMusicRecord.PublicationYear
            };
            return musicRecordCopy;
        }
}