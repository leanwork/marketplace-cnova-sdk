using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class APIResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Error> Errors
        {
            get { return _errors ?? (_errors = new List<Error>()); }
            set { _errors = value; }
        }
        ICollection<Error> _errors;

        public bool IsSuccess()
        {
            return 
                ((StatusCode == HttpStatusCode.OK || StatusCode == HttpStatusCode.Created ||
                StatusCode == HttpStatusCode.Accepted || StatusCode == HttpStatusCode.NoContent) &&
                Errors.Count == 0);
        }
    }
}
