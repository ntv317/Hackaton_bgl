using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bitgesell.Models;

namespace Bitgesell.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetPars(string purse)
        {
            var count = BitgesellApi.GetBlockCount();
            var pars = new List<string>();
            pars.Add(purse);
            var lastTrans = BitgesellApi.LastTx(pars);
            return Json(new { count=count, lastTrans = lastTrans});
        }

        public JsonResult SendTx(string rawTx)
        {
            var pars = new List<string>();
            pars.Add(rawTx);
            return Json(new { isSuccess = BitgesellApi.SendTransaction(pars)});
        }

        public IActionResult TrasactionHistory(string purse)
        {
            var res = BitgesellApi.GetLastTx(null);
            ViewBag.Purse = purse;
            ViewBag.Balance = BitgesellApi.GetBalance(purse);
            res.TransactionResult= res.TransactionResult.Where(x => x.Address == purse).ToList();
            return View(res);
        }




    }
}
