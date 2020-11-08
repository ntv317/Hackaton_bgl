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

            string json= "{\"jsonrpc\": \"1.0\", \"id\":\"curltest\", " +
                "\"method\": \"sendrawtransaction\",\"params\":[\"" +
                $"{rawTx[0]}" +
                "\"] }";
            ExecuteRequest<object>(null, MetodType.sendrawtransaction, json);
            return true;
        }

        public static double GetBalance(string purse)
        {
            string json = "{\"jsonrpc\": \"1.0\", \"id\":\"curltest\", \"method\":\"listunspent\",\"params\":[1, 9999999] }";
            var res = ExecuteRequest<GetBalance>(null, MetodType.sendrawtransaction, json);
            if (res?.Result.Count() > 0)
            {
                var balance = res.Result.Where(x => x.Address == purse).Sum(x => x.Amount);
                return balance;
            }
            return 0;
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
        public static string LastTx(List<string> purse)
        {
            var res = ExecuteRequest<TransactionList>(purse, MetodType.listtransactions);
            if (res.TransactionResult.Count > 0)
            {
                return res.TransactionResult.OrderByDescending(x=>x.Blocktime).FirstOrDefault().Txid;
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
                string json = "";
                if (parSt == null)
                {
                    var parameterRequest = new Request
                    {
                        Parameters = par,
                        Method = type.ToString()

                    };
                    json = JsonConvert.SerializeObject(parameterRequest);

                }
                else
                {
                    json = parSt;
                }
                   
                
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
