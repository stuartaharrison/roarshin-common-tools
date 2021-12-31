using Microsoft.AspNetCore.Mvc;

namespace Roarshin.CommonTools.WebTests.Controllers {

    [ApiController, Route("api/[controller]")]
    public class CustomProfileIconProviderController : ControllerBase {

        private readonly IProfileIconProvider _profileIconProvider;

        [HttpGet, Route("{text}")]
        public IActionResult GetIconUrl(string text) {
            return Ok(_profileIconProvider.GetIconUrl(text));
        }

        public CustomProfileIconProviderController(IProfileIconProvider profileIconProvider) {
            _profileIconProvider = profileIconProvider;
        }
    }
}
