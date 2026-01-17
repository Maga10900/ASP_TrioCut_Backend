namespace TriVibe.Common.GlobalResponse.Generics;

public class Pagination<T>
{
    public List<T> Data { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public int TotalCount { get; set; }
    public Pagination(List<T> data, int page, int size, int totalCount)
    {
        Data = data;
        Page = page;
        Size = size;
        TotalCount = totalCount;
    }
public Pagination()
    {
    Data = new List<T>();
    Page = 1;
    Size = 10;
    TotalCount = 0;
    }
}
