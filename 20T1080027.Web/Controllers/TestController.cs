using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace _20T1080027.Web.Controllers
{
    [RoutePrefix("thu-nghiem")]
    public class TestController : Controller
    {
        [Route("xin-chao/{name?}/{age?}")]
        public string SayHello(string name, int age = 1)
        {
            return $"hello {name}, {age} tuổi";
        }
    }
}