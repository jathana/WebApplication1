using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.com.ebay.developer;

namespace WebApplication1.eBay
{
   public class GeteBayOfficialTime
   {
      [STAThread]
      public static string GeteBayTime()
      {
         string endpoint = "https://api.sandbox.ebay.com/wsapi";
         string callName = "GeteBayOfficialTime";
         string siteId = "0";
         string appId = "JohnAtha-myfirste-SBX-8e6e3951d-7a88b485";     // use your app ID
         string devId = "9fe1d4f3-4df1-4f02-8ab7-61f94d60e796";     // use your dev ID
         string certId = "SBX-e6e3951d84c0-094b-43f3-ad66-3490";   // use your cert ID
         string version = "405";
         // Build the request URL
         string requestURL = endpoint
         + "?callname=" + callName
         + "&siteid=" + siteId
         + "&appid=" + appId
         + "&version=" + version
         + "&routing=default";
         // Create the service
         eBayAPIInterfaceService service = new eBayAPIInterfaceService();
         // Assign the request URL to the service locator.
         service.Url = requestURL;
         // Set credentials
         service.RequesterCredentials = new CustomSecurityHeaderType();
         service.RequesterCredentials.eBayAuthToken = "AgAAAA**AQAAAA**aAAAAA**cl3qVw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wFk4GjDZeFoAudj6x9nY+seQ**6e0DAA**AAMAAA**iHPSpKxV7a5968OfSvgVRizDr7xGIq7H4rZ5q/iRNoms9BlWC1XvoTJt100cl8YK30nuf4hZ0+CIJ0ZXWlQwHGqzIfb7rXIuBcdzQuzA3MBUOE9N64FqnRbY9tG90gqSZ5zKMD8yoKqBuMZKWCEy0sUKuuQg1bvs5el2/cOI8zPBfRh7XO9wgpcQ9+fGracOWa7vl28nWeqP/fOQISRXavCgYKY5Jk6qmVj/cghcNPgTylPA+5GrflS8yxVqxaKrgd469mbQyhnIMxAKsZMy29bvH+PrgrEe6jpBHYD400erYdJSzti5hyBoC0jtPdMIcPe7peU81y/ulw/3MST9AWnZfOw2dsUzcMh9SE0nnDeR63dkpdLPen6BZJd8Rc/JbNZlr7uJRTVm3c+CT3jiE2hSSVGXusXgRQCS3O2hAbkcjgYN9tyx1zkjdAp8Obexq/FvHbv+3szu6PkjllTws7BdYEmgGKj2tZt7+zQVLFEkcsWid3fRNh2cyGGKGgrHscgpurLJXv5Ey6igiB60g3U9r/OTguIxJ1b1nUZ57p2zHDCwcNRmwjL5U0XQIMKZXNryl7a+sRppZ48aac2h3im6mhzROv0GHHXRhN5BRmIPZ/LRzKrqZDdn+NcgCmVyVgfFQ7EfdveHAZ1tg5PU86CbRkN8fQiTHK+Jq1UpICtV7Q+jRygsKJglfJdcRQgD7KpzzaYF6YbHritfLtJ2kI3vDIWmk5uT2vg4uNOfadx6b8/vLIQNGYw84dQHiAcz";    // use your token
         service.RequesterCredentials.Credentials = new UserIdPasswordType();
         service.RequesterCredentials.Credentials.AppId = appId;
         service.RequesterCredentials.Credentials.DevId = devId;
         service.RequesterCredentials.Credentials.AuthCert = certId;
         // Make the call to GeteBayOfficialTime
         GeteBayOfficialTimeRequestType request = new GeteBayOfficialTimeRequestType();
         request.Version = "405";
         GeteBayOfficialTimeResponseType response = service.GeteBayOfficialTime(request);
         Console.WriteLine("The time at eBay headquarters in San Jose, California, USA, is:");
         Console.WriteLine(response.Timestamp);
         return "ebay time:" + response.Timestamp.ToString();
      }
   }
}