using Microsoft.AspNetCore.Mvc;
using Twilio.Jwt.AccessToken;

namespace NETMeetApp.Controllers
{
    [ApiController]
    [Route("video-token")]
    public class VideoTokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult GenerateToken([FromBody] TokenRequest request)
        {
            const string accountSid = "AC9c9703a031500b2e3a4234f6f6d6c0c9";
            const string apiKeySid = "SK4b904a06d6c762f9da299bc24a55fd81";
            const string apiKeySecret = "6kJfrJB4yZuXZUFGSemgrUoBAZRTx2dk";

            var identity = request.Identity;

            var grant = new VideoGrant();
            var grants = new HashSet<IGrant> { grant };

            var token = new Token(
                accountSid,
                apiKeySid,
                apiKeySecret,
                identity,
                grants: grants
            );

            return Ok(new { token = token.ToJwt() });
        }

        public class TokenRequest
        {
            public string Identity { get; set; }
        }
    }
}
