using System.Net;

namespace Identity4WebClient.Microsoft
{
    public class MyMsConfig
    {
        public string AppId { get; set; }
        public string AppPwd { get; set; }

        public string EnpointAuthorize { get; set; }

        public string EnpointToken { get; set; }

        public string BuildOauthUrl( string endcodedUrlRedirect, string state = "")
        {
            endcodedUrlRedirect = WebUtility.UrlEncode(endcodedUrlRedirect);

            var cfg = this;
            var url= $"https://login.microsoftonline.com/common/oauth2/v2.0/authorize" +
                $"?client_id={cfg.AppId}" +
                $"&response_type=code&redirect_uri={endcodedUrlRedirect}" +
                $"&response_mode=query" +
                $"&scope=openid%20offline_access%20https%3A%2F%2Fgraph.microsoft.com%2Fuser.read";
            if (!string.IsNullOrEmpty(state))
            {
                url= url + "&state={state}";
            }
            return url;
        }

    }   

}
