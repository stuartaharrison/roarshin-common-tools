using Microsoft.AspNetCore.Mvc;
using Roarshin.CommonTools.ProfileIconProviders;

namespace Roarshin.CommonTools.WebTests.Controllers {

    [ApiController, Route("api/[controller]")]
    public class GravatarProfileIconProviderController : ControllerBase {

        private readonly IProfileIconProvider _profileIconProvider;

        [HttpGet, Route("{email}")]
        public IActionResult GetIconUrl(string email) {
            return Ok(_profileIconProvider.GetIconUrl(email));
        }

        public GravatarProfileIconProviderController() {
            _profileIconProvider = new GravatarProfileIconProvider();
        }
    }
}
