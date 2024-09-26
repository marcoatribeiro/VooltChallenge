namespace VooltChallenge.Shared;

public sealed class ValidationFailureResponse
{
    public required IEnumerable<ValidationResponse> Errors { get; init; }
    
    public Dictionary<string, List<string>> ValidationErrorsAsDictionary =>
        Errors.ToDictionary(
            x => x.PropertyName,
            x => new List<string> { x.Message }
        );
}

public sealed class ValidationResponse
{
    public required string PropertyName { get; init; }
    public required string Message { get; init; }
}
