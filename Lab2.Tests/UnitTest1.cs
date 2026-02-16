public class UnitTest1
{
    private readonly Work work;
    private readonly StudentService service;


    public UnitTest1()
    {
        work = new Work();
        service = new StudentService(work);
    }

    [Fact]
    public void CountTest()
    {
        service.AddStudent("Zahar", 100);
        Assert.Equal(1, work.Count);

        Assert.Throws<ArgumentException>(() => service.AddStudent("masha", 101));
    }


    [Fact]
    public void EdgeTest()
    {
        service.AddStudent("MinStudent", 0);
        service.AddStudent("MaxStudent", 100);
        Assert.Equal(2, work.Count);
    }
    [Fact]
    public void DeleteCheck()
    {
        service.AddStudent("zahar", 90);
        service.AddStudent("ivan", 80);
        service.AddStudent("masha", 40);
        service.Remove(1);
        Assert.Equal(2, work.Count);
        string check = service.GetName(1);
        Assert.Equal("masha", check);
    }
    [Fact]
    public void AvarageCheck()
    {
        service.AddStudent("zahar", 100);
        service.AddStudent("ivan", 50);
        int avarage = service.GetAvarage();
        Assert.Equal(75, avarage);
    }
}

