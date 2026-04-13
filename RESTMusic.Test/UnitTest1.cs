using Xunit;
using System.Linq;
namespace RESTMusic.Test;

public class UnitTest1
{
    [Fact]
    public void GetAll_ReturnsData()
    {
        MusicRecordsRepository repo = new MusicRecordsRepository(); // arrange
        
        repo.Add(new MusicRecord
        {
            Title = "Song1",
            Artist = "Artist1",
            Duration = 200,
            PublicationYear = 2020
        });

        var result = repo.GetAll(); // Act
        
        // Assert
        Assert.NotNull(result);
        Assert.True(result.Count() > 0);
    }

    [Fact]
    public void Add_AddsRecord()
    {
        MusicRecordsRepository repo = new MusicRecordsRepository();
        MusicRecord record = new MusicRecord
        {
            Title = "Test",
            Artist = "Test",
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
        MusicRecordsRepository repo = new MusicRecordsRepository();

        var added = repo.Add(new MusicRecord
        {
            Title = "Song1",
            Artist = "Artist1",
            Duration = 200,
            PublicationYear = 2021
        });
        var result = repo.GetById(added.Id); // act

        // assert
        Assert.NotNull(result);
        Assert.Equal(added.Id, result.Id);

    }

    [Fact]
    public void remove_DeletesRecord()
    {
        MusicRecordsRepository repo = new MusicRecordsRepository();

        var added = repo.Add(new MusicRecord
        {
            Title = "Song1",
            Artist = "Artist1",
            Duration = 200,
            PublicationYear = 2020
        });

        var result = repo.Remove(added.Id);

        Assert.NotNull(result);
    }

    [Fact]
    public void Update_ChangesData()
    {
        MusicRecordsRepository repo = new MusicRecordsRepository();  // arrange

        var added = repo.Add(new MusicRecord
        {
            Title = "Old",
            Artist = "Old",
            Duration = 100,
            PublicationYear = 2020
        });
        
        MusicRecord updated = new MusicRecord()
        {
            Title = "New",
            Artist = "New",
            Duration = 300,
            PublicationYear = 2025
        };

        var result = repo.Update(added.Id, updated); // act

        // assert
        Assert.NotNull(result);
        Assert.Equal("New", result.Title);
    }
}