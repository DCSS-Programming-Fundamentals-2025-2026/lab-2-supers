using System;
using System.Collections;

namespace Comparers
{
    public class StudentScoreComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Student s1 = x as Student;
            Student s2 = y as Student;

            if (s1 == null || s2 == null)
            {
                throw new ArgumentException("Both objects must be of type Student");
            }

            return s2.Score.CompareTo(s1.Score);
        }
    }
}