namespace VooltChallenge.Api;

public static class ApiEndpoints
{
    private const string _apiBase = "api";
    
    public static class Ads
    {
        private const string _base = $"{_apiBase}/ads";

        public const string CreateOrUpdate = _base;
        public const string GetAll = _base;
    }
}
