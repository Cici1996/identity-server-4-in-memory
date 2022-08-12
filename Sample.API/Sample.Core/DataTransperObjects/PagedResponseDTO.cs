namespace Sample.Core.DataTransperObjects
{
    public class PagedResponseDTO<TModel>
    {
        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }

        public List<TModel> Items { get; init; }
    }
}