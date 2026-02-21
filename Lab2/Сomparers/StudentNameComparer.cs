using System.Collections;
namespace Lab2.Comparers;
using Lab2;
public class StudentNameComparer : IComparer
{
    public int Compare(object x, object y)
    {
        Student s1 = x as Student;
        Student s2 = y as Student;
        if (s1 == null || s2 == null) return 0;
        return string.Compare(s1.Name, s2.Name);
    }
}




