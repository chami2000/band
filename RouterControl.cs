using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LTEBandControl
{
    public class RouterControl
    {
        private readonly string routerIp;
        private readonly string username;
        private readonly string password;
        private string sessionId;

        public RouterControl(string routerIp, string username, string password)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
        }

        public async Task<string> GetSessionIdAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var url = $"http://{routerIp}/cgi-bin/lua.cgi";
                var data = new
                {
                    cmd = 100,
                    method = "POST",
                    username,
                    passwd = password
                };
                var content = new StringContent(JObject.FromObject(data).ToString());
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = JObject.Parse(await response.Content.ReadAsStringAsync());
                    if (result["success"].Value<bool>())
                    {
                        sessionId = result["sessionId"].Value<string>();
                        return sessionId;
                    }
                }
            }
            return null;
        }

        public async Task<bool> ChangeLTEBandsAsync(string[] bands)
        {
            if (sessionId == null)
            {
                if (await GetSessionIdAsync() == null)
                {
                    return false;
                }
            }

            using (HttpClient client = new HttpClient())
            {
                var url = $"http://{routerIp}/cgi-bin/lua.cgi";
                var data = new
                {
                    band = bands,
                    method = "POST",
                    cmd = 166,
                    sessionId
                };
                var content = new StringContent(JObject.FromObject(data).ToString());
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = JObject.Parse(await response.Content.ReadAsStringAsync());
                    return result["success"].Value<bool>();
                }
            }
            return false;
        }

        public async Task<string[]> GetCurrentBandsAsync()
        {
            if (sessionId == null)
            {
                if (await GetSessionIdAsync() == null)
                {
                    return null;
                }
            }

            using (HttpClient client = new HttpClient())
            {
                var url = $"http://{routerIp}/cgi-bin/lua.cgi";
                var data = new
                {
                    cmd = 165,
                    method = "GET",
                    sessionId
                };
                var content = new StringContent(JObject.FromObject(data).ToString());
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = JObject.Parse(await response.Content.ReadAsStringAsync());
                    if (result["success"].Value<bool>())
                    {
                        return result["lockband"].ToObject<string[]>();
                    }
                }
            }
            return null;
        }
    }
}
