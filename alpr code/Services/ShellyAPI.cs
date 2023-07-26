using ANPR_General.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANPR_General.Services
{
    public class ShellyAPI
    {
        public async void RelaySwitchAction()
        {

            try
            {
                
                ControlBody cbody = new ControlBody();

                cbody.id = "ec62608822c0";
                cbody.auth_key = "MTk2ZGUwdWlk29F650B3577385997CEAA610D1630217820841817E946C63D4B22C678F2B260FABB3825208E96FEA";
                cbody.channel = 2;
                cbody.turn = "off";

                string url = "https://shelly-68-eu.shelly.cloud/device/relay/control";

                var body = JsonConvert.SerializeObject(cbody);
                var data = new[]
                   {
                        new KeyValuePair<string, string>("id", "ec62608822c0"),
                        new KeyValuePair<string, string>("auth_key", "MTk2ZGUwdWlk29F650B3577385997CEAA610D1630217820841817E946C63D4B22C678F2B260FABB3825208E96FEA"),
                        new KeyValuePair<string, string>("channel", "2"),
                        new KeyValuePair<string, string>("turn", "off")
                    };

                var client = new HttpClient();
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new StringContent(data.ToString(), Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);

                var responseBody = await response.Content.ReadAsStringAsync();
                var _status = JsonConvert.DeserializeObject<RootData>(responseBody);

                //********** If status code is 200 then it should get licesne info
                if (_status.isok)
                {

                }


                //if (_status.statusCode == 200)
                //{
                //    url = "http://alienfence.xyz/GeLicxKey?macAdd=" + dev.MacAddress;



                    //    client = new HttpClient();
                    //    requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

                    //    response = await client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
                    //    responseBody = await response.Content.ReadAsStringAsync();
                    //    var _devCipher = JsonConvert.DeserializeObject<DeviceCipher>(responseBody);

                    //    txtLic_Key.Text = _devCipher.CipherText;
                    //    ActivateLicx();
                    //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }

        }


        public async Task ShellySwitch(int chanelNo, string id, string authkey,string turnStatus)
        {
            try 
            { 
                string endPoint = "https://shelly-68-eu.shelly.cloud/device/relay/control";
                var client = new HttpClient();

                var data = new[]
                {
                    new KeyValuePair<string, string>("id", id),
                    new KeyValuePair<string, string>("auth_key", "MTk2ZGUwdWlk29F650B3577385997CEAA610D1630217820841817E946C63D4B22C678F2B260FABB3825208E96FEA"),
                    new KeyValuePair<string, string>("channel", chanelNo.ToString()),
                    new KeyValuePair<string, string>("turn", turnStatus)
                };
                var response =  client.PostAsync(endPoint, new FormUrlEncodedContent(data)).GetAwaiter().GetResult();
                var contents = await response.Content.ReadAsStringAsync();

                var _status = JsonConvert.DeserializeObject<RootData>(contents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        public async Task ShellySwitchLocal(int chanelNo, string turnStatus,string IP)
        {
            try
            {
                string endPoint = "http://"+ IP + "/rpc/Switch.Set?id="+ chanelNo +"&on=" + turnStatus;
                var client = new HttpClient();

                var contents = await client.GetStringAsync(endPoint);
               
                //var _status = JsonConvert.DeserializeObject<RootData>(contents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }


    }
}
