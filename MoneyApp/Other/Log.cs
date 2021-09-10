using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;
using Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoneyApp.Other
{
    public class Log
    {
        public readonly static Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public static void Trace(string objectResult)
        {
            logger.Trace(objectResult);
        }

        public static void Trace(object objectResult)
        {
            logger.Trace(
                JsonConvert.SerializeObject(objectResult)
                );
        }

        public static void Error(object objectResult)
        {
            logger.Error(
                JsonConvert.SerializeObject(objectResult)
                );
        }

        public static void Fatal(object objectResult)
        {
            logger.Fatal(
                JsonConvert.SerializeObject(objectResult)
                );
        }


    }
}
