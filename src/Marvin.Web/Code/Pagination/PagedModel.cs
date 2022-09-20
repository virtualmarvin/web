namespace Marvin.Web
{
    // Base viewmodel for paginated pages

    public abstract class PagedModel : BaseModel
    {
        // Default values 

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 15;
        public string Sort { get; set; } = "-Id";
        public int Filter { get; set; } = 0;
        public bool AdvancedFilter { get; set; } = false;

        public int TotalRows { get; set; }

        // Shorthand for Entity Framework Skip and Take methods

        public int Skip { get => Math.Max(FirstRow - 1, 0); } 
        public int Take { get => PageSize; } 

        // Pagination helpers 

        public int FirstRow { get => Math.Min(Math.Max(1, ((Page - 1) * PageSize) + 1), TotalRows); } 
        public int LastRow { get => Math.Min(FirstRow + PageSize - 1, TotalRows); } 
        public string Range { get => FirstRow.ToString() + " - " + LastRow.ToString(); } 
        public int TotalPages { get => (int)Math.Ceiling(((double)TotalRows) / PageSize); } 
        public bool HasPrevPage { get => Page > 1; } 
        public bool HasNextPage { get => Page < TotalPages; } 
        public string UnsignedSort { get => Sort[0] == '-' ? Sort.Substring(1) : Sort; } 
        public string Order { get => Sort[0] == '-' ? "Desc" : "Asc"; } 
        public string OrderBy { get => UnsignedSort + " " + Order; } 
        public int NextPage { get => HasNextPage ? Page + 1 : -1; } 
        public int PrevPage { get => HasPrevPage ? Page - 1 : -1; }
    }

    // Typed base viewmodel supporting a list of paginated items

    public abstract class PagedModel<T> : PagedModel
    {
        public List<T> Items { get; set; } = new ();
    }
}
