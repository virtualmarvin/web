namespace Marvin.Web
{
    // Exposes properties for currently authenticated user

    #region Interface

    public interface ICurrentUser
    {
        int Id { get; }
        string? FirstName { get; }
        string? LastName { get; }
        string? Name { get; }
        string? Alias { get; }
        string? Email { get; }
        string? FirstLetter { get; }

        bool IsAuthenticated { get; }
        bool IsAdmin { get; }
        bool IsUser { get; }
    }

    #endregion

    public class CurrentUser : ICurrentUser
    {
        #region Dependency Injection

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Services

        public bool IsAuthenticated { get => IsAdmin || IsUser; }
        public bool IsAdmin { get => _httpContextAccessor.HttpContext!.User.IsInRole("Admin"); }
        public bool IsUser { get => _httpContextAccessor.HttpContext!.User.IsInRole("User"); }

        public int Id { get => GetClaim(ClaimTypes.UserId)?.GetId() ?? 0; }
        public string? FirstName { get => GetClaim(ClaimTypes.FirstName); }
        public string? LastName { get => GetClaim(ClaimTypes.LastName); }
        public string? Name { get => FirstName + " " + LastName; }
        public string? Alias { get => GetClaim(ClaimTypes.Alias); }
        public string? Email { get => GetClaim(ClaimTypes.Email); }
        public string? FirstLetter { get => FirstName?.Substring(0, 1); }

        #endregion

        #region Helpers

        private string? GetClaim(string name)
        {
            var claims = _httpContextAccessor.HttpContext?.User.Claims.Where(c => c.Type == name);
            if (claims != null && claims.Any())
                return claims.First().Value;

            return null;
        }

        #endregion
    }
}