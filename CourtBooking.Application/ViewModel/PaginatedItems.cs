namespace CourtBooking.Application.ViewModel
{
    public class PaginatedItems<TEntity> where TEntity : class

    {

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public long TotalPages { get; private set; }

        public IEnumerable<TEntity> Data { get; set; }

        public PaginatedItems(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = count;
            Data = data;
        }
    }
}
