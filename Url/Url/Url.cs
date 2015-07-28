using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UrlUtilities
{
    public class Url : Uri
    {

        #region properties

        private NameValueCollection _queryParams = null;
        public NameValueCollection QueryParams
        {
            get
            {
                if (this._queryParams == null)
                    this._queryParams = new NameValueCollection();
                return this._queryParams;
            }
        }

        public new string Query
        {
            get
            {
                return this.QueryParams.ToQueryString();
            }
        }

        #endregion


        #region constructors

        /// <summary>
        /// Initializes a new instance of the UrlUtilities.Url class with the specified URL.
        /// </summary>
        /// <param name="uriString">A URL</param>
        public Url(string uriString)
            : base(uriString)
        {
            if ((uriString ?? string.Empty).Contains('?'))
                this._queryParams = ParseQuery(uriString);
        }

        /// <summary>
        /// Initializes a new instance of the UrlUtilities.Url class with the specified URL.
        /// This constructor allows you to specify if the URI string is a relative URI,
        /// absolute URI, or is indeterminate.
        /// </summary>
        /// <param name="uriString">A string that identifies the resource to be represented by the System.Uri instance.</param>
        /// <param name="uriKind">Specifies whether the URI string is a relative URI, absolute URI, or is indeterminate.</param>
        public Url(string uriString, UriKind uriKind)
            : base(uriString, uriKind)
        {
            if ((uriString ?? string.Empty).Contains('?'))
                this._queryParams = ParseQuery(uriString);
        }

        /// <summary>
        /// Initializes a new instance of the UrlUtilities.Url class based on the 
        /// specified base URI and relative URI string.
        /// </summary>
        /// <param name="baseUri">The base URL</param>
        /// <param name="relativeUri">The relative URL to add to the base URL</param>
        public Url(Uri baseUri, string relativeUri)
            : base(baseUri, relativeUri)
        {
            if ((baseUri.ToString() ?? string.Empty).Contains('?'))
                this._queryParams = ParseQuery(baseUri.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the UrlUtilities.Url class based on the combination
        /// of a specified base System.Uri instance and a relative System.Uri instance.
        /// </summary>
        /// <param name="baseUri">An absolute System.Uri that is the base for the new System.Uri instance.</param>
        /// <param name="relativeUri">A relative System.Uri instance that is combined with baseUri.</param>
        public Url(Uri baseUri, Uri relativeUri)
            : base(baseUri, relativeUri)
        {
            if ((baseUri.ToString() ?? string.Empty).Contains('?'))
                this._queryParams = ParseQuery(baseUri.ToString());
        }
        
        #endregion


        #region public methodsm

        /// <summary>
        /// Adds or updates a querystring parameter key and value.
        /// </summary>
        /// <param name="name">The querystring key</param>
        /// <param name="value">The querystring value to set</param>
        /// <returns>This Url object (for the purpose of method chaining)</returns>
        public Url SetQueryParam(string name, object value)
        {
            this.QueryParams.Set(name, value.ToString());
            return this;
        }

        /// <summary>
        /// Removes the named querystring key and it's value
        /// </summary>
        /// <param name="name">The name of the querystring parameter to remove</param>
        /// <returns>This Url object (for the purpose of method chaining)</returns>
        public Url RemoveQueryParam(string name)
        {
            this.QueryParams.Remove(name);
            return this;
        }

        /// <summary>
        /// Gets a canonical string representation for the specified System.Uri instance
        /// </summary>
        /// <returns>
        /// A System.String instance that contains the unescaped canonical representation
        /// of the System.Uri instance. All characters are unescaped except #, ?, and %.
        /// </returns>
        public override string ToString()
        {
            string strBaseUri = base.ToString();
            if (!string.IsNullOrEmpty(base.ToString()) && base.ToString().Contains('?'))
                strBaseUri = strBaseUri.Substring(0, strBaseUri.IndexOf('?'));

            return string.Concat(strBaseUri, this.Query);
        }

        #endregion


        #region public static methods

        /// <summary>
        /// Parses the given querystring into a NameValueCollection.
        /// </summary>
        /// <param name="strQuery">The querystring to parse</param>
        /// <returns>A NameValueCollection containing the keys and values from the querystring</returns>
        public static NameValueCollection ParseQuery(string strQuery)
        {
            NameValueCollection queryParams = null;
            if (string.IsNullOrEmpty(strQuery))
                queryParams = new NameValueCollection();
            else
            {
                if (strQuery.Contains('?'))
                    strQuery = strQuery.Substring(strQuery.IndexOf('?'));
                queryParams = HttpUtility.ParseQueryString(strQuery);
            }
            return queryParams;
        }

        #endregion

    }
}
