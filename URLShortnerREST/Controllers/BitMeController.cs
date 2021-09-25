using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using URLShortnerREST.Models;

namespace URLShortnerREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BitMeController : ControllerBase
    {

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
            return _urlLibary.StoreURL(url);
        }

        [Route("{url}")]
        [HttpGet]
        public RedirectResult BitMe(string url)
        {
            return RedirectPermanent(_urlLibary.GetURL(url));
        }
    }
}
