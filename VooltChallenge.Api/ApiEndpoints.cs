namespace VooltChallenge.Api;

public static class ApiEndpoints
{
    private const string _apiBase = "api";
    
    public static class Ads
    {
        private const string _base = $"{_apiBase}/ads";

        public const string Create = _base;
        //public const string Get = $"{_base}/{{id:int}}";
        public const string GetAll = _base;
        //public const string Update = $"{_base}/{{id:int}}";
        //public const string Delete = $"{_base}/{{id:int}}";
    }
}
