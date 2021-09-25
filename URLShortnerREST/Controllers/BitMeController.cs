using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using URLShortnerREST.Models;

namespace URLShortnerREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BitMeController : ControllerBase
    {

        //Tester guide
        //Navigate to url (change url= to differnt url if you want)
        //https://localhost:44387/BitMe/BitMeShorten?url=https://en.wikipedia.org/wiki/Dependency_inversion_principle

        //Then paste results like so and get redirected to your original site (State is local, no database, so shortened strings will not work between runs)
        //https://localhost:44387/BitMe/RVmzLTGPM0CpPhQyHifnVg

        private readonly ILogger<BitMeController> _logger;
        private static IUrlLibary _urlLibary = new UrlLibary();

        public BitMeController(ILogger<BitMeController> logger)
        {
            _logger = logger;
        }

        [Route("BitMeShorten")]
        [HttpGet]
        public string BitMeShorten([FromQuery]string url)
        {
            return string.Format(@"BitMe/{0}", _urlLibary.StoreURL(url));
        }

        [Route("{key}")]
        [HttpGet]
        public RedirectResult BitMe(string key)
        {
            return RedirectPermanent(_urlLibary.GetURL(key));
        }
    }
}
