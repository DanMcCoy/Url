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

        public Url(string uriString)
            : base(uriString)
        {
            if ((uriString ?? string.Empty).Contains('?'))
                this._queryParams = ParseQuery(uriString);
        }
        public Url(string uriString, UriKind uriKind)
            : base(uriString, uriKind)
        {
            if ((uriString ?? string.Empty).Contains('?'))
                this._queryParams = ParseQuery(uriString);
        }
        public Url(Uri baseUri, string relativeUri)
            : base(baseUri, relativeUri)
        {
            if ((baseUri.ToString() ?? string.Empty).Contains('?'))
                this._queryParams = ParseQuery(baseUri.ToString());
        }
        public Url(Uri baseUri, Uri relativeUri)
            : base(baseUri, relativeUri)
        {
            if ((baseUri.ToString() ?? string.Empty).Contains('?'))
                this._queryParams = ParseQuery(baseUri.ToString());
        }
        
        #endregion


        #region public methods

        public Url SetQueryParam(string name, object value)
        {
            this.QueryParams.Set(name, value.ToString());
            return this;
        }

        public Url RemoveQueryParam(string name)
        {
            this.QueryParams.Remove(name);
            return this;
        }

        public override string ToString()
        {
            string strBaseUri = base.ToString();
            if (!string.IsNullOrEmpty(base.ToString()) && base.ToString().Contains('?'))
                strBaseUri = strBaseUri.Substring(0, strBaseUri.IndexOf('?'));

            return string.Concat(strBaseUri, this.Query);
        }

        #endregion


        #region public static methods

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
