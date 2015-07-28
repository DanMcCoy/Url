using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Url
{
    public static class Extensions
    {
        /// <summary>
        /// Returns the querystring section of the uri from this UriBuilder in the form of a NameValueCollection.      
        /// </summary>
        /// <returns>A NameValueCollection containing the keys and values from the querystring</returns>
        public static NameValueCollection ParseQuery(this UriBuilder thisUriBuilder)
        {
            return HttpUtility.ParseQueryString(thisUriBuilder.Query);
        }

        /// <summary>
        /// Set the querystring section of the Uri for this UriBuilder.
        /// Safer than calling the .Query property directly as this method inteligently deals with the '?' character.
        /// </summary>
        /// <param name="query"></param>
        public static void SetQuery(this UriBuilder thisUriBuilder, string query)
        {
            if (thisUriBuilder != null)
            {
                query = (query ?? string.Empty);
                if (query.StartsWith("?"))
                    query = query.Remove(0, 1);

                thisUriBuilder.Query = query;
            }
        }

        /// <summary>
        /// Adds or updates a querystring parameter key and value.
        /// </summary>
        /// <param name="name">The querystring key</param>
        /// <param name="value">The querystring value to set</param>
        public static void SetQueryParam(this UriBuilder thisUriBuilder, string name, object value)
        {
            if (thisUriBuilder != null)
            {
                NameValueCollection namedValues = thisUriBuilder.ParseQuery();
                namedValues.Set(name, value.ToString());
                thisUriBuilder.SetQuery(namedValues.ToQueryString());
            }
        }

        /// <summary>
        /// Removes the named querystring key and it's value from the resulting Uri
        /// </summary>
        /// <param name="name">The name of the querystring parameter to remove</param>
        public static void RemoveQueryParam(this UriBuilder thisUriBuilder, string name)
        {
            if (thisUriBuilder != null)
            {
                NameValueCollection namedValues = thisUriBuilder.ParseQuery();
                namedValues.Remove(name);
                thisUriBuilder.SetQuery(namedValues.ToQueryString());
            }
        }

        /// <summary>
        /// Builds a querystring using the names and values from this collection.
        /// Resulting string will be prefixed with a '?' and delimited with '&'.
        /// </summary>
        /// <param name="thisCollection"></param>
        /// <returns>A querystring prefixed with a '?' and delimited with '&'.</returns>
        /// <example>?KeyA</example>
        public static string ToQueryString(this NameValueCollection thisCollection)
        {
            StringBuilder queryString = new StringBuilder();

            if (thisCollection != null && thisCollection.Count > 0)
            {
                foreach (string key in thisCollection)
                {
                    queryString.Append(queryString.Length == 0 ? "?" : "&");

                    // Remember that with querystrings, keys can actually be null or empty. Each is slightly different in the querystring:
                    // Named value:     ?myKey=myValue
                    // Zero length key: ?=myValue
                    // Null key:        ?myValue
                    queryString.Append(key == null ? thisCollection[key] : key + "=" + thisCollection[key]);
                }
            }

            return queryString.ToString();
        }
    }
}
