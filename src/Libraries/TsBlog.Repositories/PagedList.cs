using System;
using System.Collections.Generic;
using System.Linq;

namespace TsBlog.Repositories
{
    /// <summary>
    /// Paging Component Entity Class
    /// </summary>
    /// <typeparam name="T">generic entity </typeparam>

    [Serializable]
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">data source</param>
        /// <param name="page index">paging index </param>
        /// <param name="pageSize">paging size </param>
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;

            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">data source</param>
        /// <param name="page index">paging index </param>
        /// <param name="pageSize">paging size </param>
        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">data source</param>
        /// <param name="page index">paging index </param>
        /// <param name="pageSize">paging size </param>
        /// <param name="total Count">total number of records </param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source);
        }

        /// <summary>
        /// Paging Index
        /// </summary>
        public int PageIndex { get; }
        /// <summary>
        /// Paging size
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// Total number of records
        /// </summary>
        public int TotalCount { get; }
        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Is there a previous page?
        /// </summary>
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        /// <summary>
        /// Is there the next page?
        /// </summary>
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}