using Xunit;
using System.Linq;
namespace RESTMusic.Test;

public class UnitTest1
{
    [Fact]
    public void GetAll_ReturnsData()
    {
        MusicRecordsRepository repo = new MusicRecordsRepository(true); // arrange

        var result = repo.GetAll(); // Act
        
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
        MusicRecordsRepository repo = new MusicRecordsRepository(true);

        var result = repo.GetById(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public void remove_DeletesRecord()
    {
        MusicRecordsRepository repo = new MusicRecordsRepository(true);

        var result = repo.Remove(1);

        Assert.NotNull(result);
    }

    [Fact]
    public void Update_ChangesData()
    {
        MusicRecordsRepository repo = new MusicRecordsRepository(true);

        MusicRecord updated = new MusicRecord()
        {
            Title = "Updted",
            Artist = "Updted",
            Duration = 200,
            PublicationYear = 2021
        };

        var result = repo.Update(1, updated);

        Assert.NotNull(result);
        Assert.Equal("Updted", result.Title);
    }
}