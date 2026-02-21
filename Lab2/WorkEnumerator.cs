using System.Collections;
class WorkEnumerator : IEnumerator
{
    private readonly Work work;
    private int position = -1;
    public object Current
    {
        get
        {
            return work.GetAt(position);
        }
    }
    public WorkEnumerator(Work work)
    {
        this.work = work;
    }
    public bool MoveNext()
    {
        position++;
        if (position < work.Count)
        {
            return true;
        }
        return false;
    }
    public void Reset()
    {
        position = -1;
    }
}