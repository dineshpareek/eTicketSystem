namespace eTicketSystem.Models.Common
{
    public static class GridUtility
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                         int page, int pageSize,string sort="",string sortdir="") where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query//.OrderBy(sort + " " + sortdir)
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return result;
        }

    }
}
