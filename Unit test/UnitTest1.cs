using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RESTMusic.Data;

namespace RESTMusic.Test;

    public class MusicRepositoryTests
    {
        private MusicRecordsRepository CreateRepository()
        {
            var options = new DbContextOptionsBuilder<MusicContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            var context = new MusicContext(options);

            return new MusicRecordsRepository(context);
        }

        [Fact]
        public void GetAll_ReturnsData()
        {
            var repo = CreateRepository();
            CreateRepository().Add(new MusicRecord
            {
                Title = "Song1",
                Artist = "Artist1",
                Duration = 200,
                PublicationYear = 2020
            });
            var result = repo.GetAll();

            Assert.NotNull(result);
            Assert.True(result.Count() > 0);
        }

        [Fact]
        public void Add_AddsRecord()
        {
            var repo = CreateRepository();
            var record = new MusicRecord
            {
                Title = "Test",
                Artist = "Artist1",
                Duration = 200,
                PublicationYear = 2021
            };

            var result = repo.Add(record);

            Assert.NotNull(result);
            Assert.Equal("Test", result.Title);
        }

        [Fact]
        public void GetById_ReturnsCorrectRecord()
        {
            var repo = CreateRepository();
            var added = repo.Add(new MusicRecord
            {
                Title = "Song1",
                Artist = "Artist1",
                Duration = 200,
                PublicationYear = 2021
            });

            var result = repo.GetById(added.Id);

            Assert.NotNull(result);
            Assert.Equal(added.Id, result.Id);
        }

        [Fact]
        public void Remove_DeletesRecord()
        {
            var repo = CreateRepository();
            var added = repo.Add(new MusicRecord
            {
                Title = "Song1",
                Artist = "Artist1",
                Duration = 200,
                PublicationYear = 2020
            });

            var result = repo.Remove(added.Id);

            Assert.NotNull(result);
            Assert.Null(repo.GetById(added.Id));
        }

        [Fact]
        public void Update_ChangesData()
        {
            var repo = CreateRepository();
            var added = repo.Add(new MusicRecord
            {
                Title = "Song1",
                Artist = "Artist1",
                Duration = 200,
                PublicationYear = 2021
            });

            var updated = new MusicRecord
            {
                Title = "New",
                Artist = "New",
                Duration = 300,
                PublicationYear = 2025
            };

            var result = repo.Update(added.Id, updated);

            Assert.NotNull(result);
            Assert.Equal("New", result.Title);
        }

        [Fact]
        public void Search_FindsByTitle()
        {
            var repo = CreateRepository();

            repo.Add(new MusicRecord { Title = "Hello", Artist = "A", Duration = 100, PublicationYear = 2020 });
            repo.Add(new MusicRecord { Title = "World", Artist = "B", Duration = 200, PublicationYear = 2021 });

            var result = repo.Search("Hello", null);

            Assert.Single(result);
        }
    }
