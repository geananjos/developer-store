namespace SalesSystem.Application.Common
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
