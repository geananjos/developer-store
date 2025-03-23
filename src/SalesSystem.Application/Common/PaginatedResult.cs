namespace SalesSystem.Application.Common
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public PaginatedResult() { }

        public PaginatedResult(IEnumerable<T> data, int totalItems, int currentPage, int pageSize)
        {
            Data = data;
            TotalItems = totalItems;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}
