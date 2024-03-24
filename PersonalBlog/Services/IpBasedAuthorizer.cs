using PersonalBlog.Interface;

namespace PersonalBlog.Services
{
    public class IpBasedAuthorizer : IAuthorize
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public IpBasedAuthorizer(IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }
        public bool IsAuthorized()
        {
            var ipV4 = _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var validIp = _configuration.GetSection("Security").GetValue<string>("ValidIp");
            return string.Compare(ipV4, validIp) == 0;
        }
    }
}
