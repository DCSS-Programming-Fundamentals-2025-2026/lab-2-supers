using System.Collections;
using Lab2.Comparers;
public class Work : IEnumerable
{
    private Student[] students = new Student[200];
    private int count = 0;
    public int Count => count;
    public void Add(string name, int score)
    {
        students[count] = new Student(name, score);
        count++;
    }
    public void Delete(int index)
    {
        for (int i = index; i < count - 1; i++)
        {
            students[i] = students[i + 1];
        }
        students[count - 1] = null;
        count--;
    }

    public string Get(int index)
    {
        return students[index].Name;
    }
    public int Avarage()
    {
        if (count == 0)
        {
            return -1;
        }
        int sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += students[i].Score;
        }
        int avarage = sum / count;
        return avarage;
    }
    public void Sort()
    {
        Array.Sort(students, 0, count);
    }
    public void SetAt(int index, string name, int score)
    {
        students[index] = new Student(name, score);
    }
    public Student GetAt(int index)
    {
        return students[index];
    }
    public IEnumerator GetEnumerator()
    {
        return new WorkEnumerator(this);
    }
    public void SortByName()
    {
        Array.Sort(students, 0, count, new StudentNameComparer());
    }
}






















