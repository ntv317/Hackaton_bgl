using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Bitgesell.Enums;
using Bitgesell.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Bitgesell
{
    public class BitgesellApi
    {

        public static bool SendTransaction (List<string> rawTx)
        {
            var res = ExecuteRequest<SendTransaction>(rawTx, MetodType.sendrawtransaction);
            return res.Error == null;
        }

        public  static TransactionList GetLastTx(List<string> purse)
        {
            var res = ExecuteRequest<TransactionList>(purse, MetodType.listtransactions);
            if (res.TransactionResult.Count > 0)
            {
                return res;
            }
            return null;
        }

        public static long GetBlockCount()
        {
            var res = ExecuteRequest<GetBLockCount>(null, MetodType.getblockcount);

            return res.Result+1;
        }
       
        private static T ExecuteRequest<T>(List<string> par, MetodType type, string parSt = null)
        {
            try
            {
                
                    var parameterRequest = new Request
                    {
                        Parameters = par,
                        Method = type.ToString()

                    };
                    var json = JsonConvert.SerializeObject(parameterRequest);
                
                using (var webClient = new WebClient())
                {
                    webClient.Credentials = new NetworkCredential("bgl_user", "12345678");
                    
                    var response = webClient.UploadString($"http://161.35.123.34:8332/wallet/", "POST", json);
                    return JsonConvert.DeserializeObject<T>(response);
                }
            }
            catch (Exception ex)
            {
                return default;
            }
             
        }
    }
}
