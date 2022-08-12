namespace Sample.Core.DataTransperObjects
{
    public class PagedModelDTO<TModel>
    {
        private const int MaxPageSize = 500;
        private int _pageSize;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<TModel> Items { get; set; }

        public PagedModelDTO()
        {
            Items = new List<TModel>();
        }
    }
}