using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Caching;

namespace SifirGibiMakina
{
    public static class DataCacheHelper
    {
        public static T GetDataFromCacheOrDB<T>(string cacheKey, Func<T> dataRetrievalMethod, TimeSpan cacheDuration) where T : class
        {
            var data = HttpRuntime.Cache[cacheKey] as T;

            if (data == null)
            {
                data = dataRetrievalMethod();
                HttpRuntime.Cache.Insert(cacheKey, data, null, DateTime.Now.Add(cacheDuration), Cache.NoSlidingExpiration);
            }

            return data;
        }


    }

}