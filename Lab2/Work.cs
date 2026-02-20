using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Work
{
   private Student[] students = new Student[200];
  private  int count = 0;
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
    public void  Show()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($" Index {i}: Achievements -- {students[i]}");
        }
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
        int sum=0;
        for(int i = 0; i < count; i++)
        {
            sum+=students[i].Score;
        }
        int avarage =sum/count;
        return avarage;
    }
    public void Sort()
    {
        Array.Sort(students,0,count);
        Show();
    }
    public void SetAt(int index,string name,int score)
    {
        students[index]=new Student(name,score);
    }
   
}
        
        
        
        











