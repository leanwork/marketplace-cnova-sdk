using System.Net;

namespace Marketplace.Cnova.SDK.Utils
{
    public interface ISimpleRequest
    {
        ISimpleRequest AddHeader(string key, string value);
        ISimpleRequest AddParameter(string key, string value);
        ISimpleRequest SetContentType(string contentType);
        ISimpleRequest SetHost(string host);

        HttpWebResponse GET(string resource);
        HttpWebResponse POST(string resource);
        HttpWebResponse POST(string resource, string requestBody);
        HttpWebResponse POST(string resource, byte[] requestBody);
        HttpWebResponse PUT(string resource);
        HttpWebResponse PUT(string resource, string requestBody);
        HttpWebResponse PUT(string resource, byte[] requestBody);
        HttpWebResponse DELETE(string resource);
    }
}
