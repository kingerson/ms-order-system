using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MS.ProductsWithoutArtifact.Application
{
    [ExcludeFromCodeCoverage]
    public class BasePagination
    {
        public int Page { get; set; }
        public int Rows { get; set; } = 10;
    }
    public class Pagination<T> where T : new()
    {
        public IEnumerable<T> Rows { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int Total { get; set; }
    }
}
