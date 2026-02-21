using System;
using Xunit;

public class StudentServiceTests
{
    private readonly Work work;
    private readonly StudentService service;

    public StudentServiceTests()
    {
        // Arrange
        work = new Work();
        service = new StudentService(work);
    }

    [Fact]
    public void EdgeCaseCheck()
    {
        // Arrange
        int initialCount = work.Count;

        // Act
        service.AddStudent("MinStudent", 0);
        service.AddStudent("MaxStudent", 100);

        // Assert
        Assert.Equal(initialCount + 2, work.Count);
    }

    [Fact]
    public void InvalidGradeStudentCheck()
    {
        // Arrange
        service.AddStudent("Zahar", 100);
        int countBefore = work.Count;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => service.AddStudent("Masha", 101));
        Assert.Equal(countBefore, work.Count);
    }

    [Fact]
    public void EmptyNameStudentCheck()
    {
        // Arrange
        int countBefore = work.Count;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => service.AddStudent("", 50));
        Assert.Equal(countBefore, work.Count);
    }

    [Fact]
    public void RemoveStudentCheck()
    {
        // Arrange
        service.AddStudent("Zahar", 90);
        service.AddStudent("Ivan", 80);
        service.AddStudent("Masha", 40);

        // Act
        service.Remove(1);

        // Assert
        Assert.Equal(2, work.Count);
        Assert.Equal("Masha", service.GetName(1));
    }

    [Fact]
    public void GetAverageCalculatesCorrectly()
    {
        // Arrange
        service.AddStudent("Zahar", 100);
        service.AddStudent("Ivan", 50);

        // Act
        int average = service.GetAvarage();

        // Assert
        Assert.Equal(75, average);
    }

    [Fact]
    public void IntegrationTest___AddDeleteGetAverage()
    {
        // Arrange
        service.AddStudent("Zahar", 100);
        service.AddStudent("Oleg", 60);
        service.AddStudent("Anna", 40);

        // Act 
        service.Remove(0);
        int finalAverage = service.GetAvarage();

        // Assert 
        Assert.Equal(2, work.Count);
        Assert.Equal(50, finalAverage);
    }

    [Fact]
    public void InvalidGradeAndAvarageTest()
    {
        // Arrange
        service.AddStudent("Zahar", 100);

        // Act
        Assert.Throws<ArgumentException>(() => service.AddStudent("Error", -5));
        service.AddStudent("Ivan", 50);
        int average = service.GetAvarage();

        // Assert
        Assert.Equal(2, work.Count);
        Assert.Equal(75, average);
    }

    [Fact]
    public void GetCheckInvalidindex()
    {
        // Arrange
        service.AddStudent("Ivan", 90);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => service.GetAt(1));
    }

    [Fact]
    public void RemoveCheckInvalidindex()
    {
        // Arrange
        service.AddStudent("Ivan", 90);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => service.Remove(1));
    }

    [Fact]
    public void SetAtCheck()
    {
        // Arrange
        service.AddStudent("Zahar", 40);

        // Act
        service.SetStudent(0, "Masha", 50);

        // Assert
        Assert.Equal("Masha", service.GetName(0));
    }
    [Fact]
    public void IComparableCheck()
    {
        //Arrange
        service.AddStudent("Zahar", 90);
        service.AddStudent("Ivan", 100);

        //Act

        service.ArraySort();

        Assert.Equal("Zahar", service.GetName(1));
    }
    [Fact]
    public void ComparerCheck()
    {
        //Arrange
        service.AddStudent("Anton", 90);
        service.AddStudent("Ivan", 80);

        //Act 

        service.SortByName();
        //Assert

        Assert.Equal("Ivan", service.GetName(1));
    }
}



