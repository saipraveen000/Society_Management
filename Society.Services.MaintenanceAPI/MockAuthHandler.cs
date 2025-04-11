using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

/*amespace Society.Services.MaintenanceAPI
{
    public class MockAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public MockAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
       ILoggerFactory logger,
       UrlEncoder encoder,
       ISystemClock clock) : base(options, logger, encoder, clock) { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "testUser"),
            new Claim(ClaimTypes.Role, "Resident") // Change to Admin for testing
        };

            var identity = new ClaimsIdentity(claims, "Mock");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "MockScheme");

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}*/
