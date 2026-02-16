public class StudentService

{

    private readonly Work work;

    public StudentService(Work work)

    {
        this.work = work;
    }


    public void AddStudent(string name, int score)

    {

        if (string.IsNullOrWhiteSpace(name))

        {

            throw new ArgumentException("You wrote an empty space ");

        }

        else if (score < 0 || score > 100)
        {

            throw new ArgumentException("Score must be in range beetween 0 -- 100");
        }
        work.Add(name, score);
    }
    public void Remove(int index)
    {
        if (index < 0 || index > work.Count)
        {
            throw new IndexOutOfRangeException("Student with that index is not exists");
        }
        work.Delete(index);
    }
    public void ShowList()
    {
        work.Show();
    }
    public string GetName(int index)
    {
        return work.Get(index);
    }
    public int GetAvarage()
    {
        int avarage = work.Avarage();
        return avarage;
    }
}















