using System;
using System.Linq;
using System.Net.Http;
using TokenAuthorization.Core.Caching;
using TokenAuthorization.Core.Extensions;

namespace TokenAuthorization.Core.Fetchers.Data
{
    public class QueryStringDataFetcher : CacheableDataFetcher
    {
 public QueryStringDataFetcher(string dataName) : base(dataName, new NonCachedStrategy())
        {
        }

        public QueryStringDataFetcher(Lazy<string> lazyDataName) : base(lazyDataName, new NonCachedStrategy())
        {
        }

        public QueryStringDataFetcher(string dataName, IDataCacheStrategy cacheStrategy)
            : base(dataName, cacheStrategy)
        {
        }

        public QueryStringDataFetcher(Lazy<string> lazyDataName, IDataCacheStrategy cacheStrategy)
            : base(lazyDataName, cacheStrategy)
        {
        }

        public override string CacheableFetchData(HttpRequestMessage request)
        {
            return request.GetQueryNameValuePairs().FirstOrDefault(p => p.Key == DataName).Value;
        }
    }

    public class HeaderDataFetcher : CacheableDataFetcher
    {
        public HeaderDataFetcher(string dataName, IDataCacheStrategy cacheStrategy) : base(dataName, cacheStrategy)
        {
        }

        public HeaderDataFetcher(Lazy<string> lazyDataName, IDataCacheStrategy cacheStrategy) : base(lazyDataName, cacheStrategy)
        {
        }

        public override string CacheableFetchData(HttpRequestMessage request)
        {
            return request.GetHeader(DataName);
        }
    }
}