using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNetCore.WebUtilities;

namespace URLShortnerREST.Models
{
    public class UrlLibary : IUrlLibary
    {
        Dictionary<string, string> GUIDToUrlDictionary;

        public UrlLibary()
        {
            GUIDToUrlDictionary = new Dictionary<string, string>();
        }

        /// <summary>
        /// Takes in a long url and returns a unique string to represent that url for this service
        /// </summary>
        /// <param name="url">url to be stored</param>
        /// <returns>The Shortened URL. If the given url is smaller than system limit, returns original url</returns>
        public string StoreURL(string url)
        {
            //Check if url is smaller than system limit 
            //todo remove http.www?
            if (url != null && url.Length > 9+7+24) //http:www. (9) /BitMe/(7) b64(24)
            { 
                if (GUIDToUrlDictionary.ContainsValue(url))
                {
                    return GUIDToUrlDictionary.First(u => u.Value == url).Key;
                }
                else
                {
                    string shortenedKey = WebEncoders.Base64UrlEncode(Guid.NewGuid().ToByteArray());
                        //Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=') //Convert can handle base64 with trailing = removed which gets our url shorter (https://stackoverflow.com/questions/9020409/is-it-ok-to-remove-the-equal-signs-from-a-base64-string)
                    GUIDToUrlDictionary.Add(shortenedKey, url);

                    return shortenedKey;
                }
            }
            else
            {
                return url;
            }
        }

        /// <summary>
        /// Expects a shortened encoded string created by UrlLibary.StoreURL
        /// </summary>
        /// <param name="shortenedKey"> </param>
        /// <returns>The long url stored against the encoded string key</returns>
        public string GetURL(string shortenedKey)
        {
            return GUIDToUrlDictionary[shortenedKey];
        }
    }
}
