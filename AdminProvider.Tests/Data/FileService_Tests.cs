
using AdminProvider.Data.Interfaces;
using Moq;

namespace AdminProvider.Tests.Data;

public class FileService_Tests
{
    private readonly Mock<IFileService> _mockFileService;
    private readonly IFileService _fileService; 
    public FileService_Tests()
    {
        _mockFileService = new Mock<IFileService>();
        _fileService = _mockFileService.Object; 
    }

    [Fact]
    public void SaveToFile_ShouldReturnTrue_WhenContentIsSaved() 
    {
        //Arrange
        var filePath = "";
        _mockFileService.Setup(x => x.SaveToFile(filePath, It.IsAny<string>())).Returns(true);

        //Act
        var result = _fileService.SaveToFile(filePath, "Test");

        //Assert
        Assert.True(result);
    }

    [Fact]

    public void GetContentFromFile_ShouldReturnStringContent() 
    {
        //Arrange
        var filePath = "";
        _mockFileService.Setup(x => x.GetContentFromFile(filePath)).Returns("Test");

        //Act
        var result = _fileService.GetContentFromFile(filePath);

        //Assert
        Assert.Equal("Test", result);
    }
}
