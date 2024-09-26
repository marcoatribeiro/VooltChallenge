using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;

namespace VooltChallenge.Ui.Client.Validation;

// Source: https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation?view=aspnetcore-8.0#validator-components
public sealed class CustomValidation: ComponentBase
{
    private ValidationMessageStore? _messageStore;

    [CascadingParameter]
    private EditContext? EditContext { get; set; }

    protected override void OnInitialized()
    {
        if (EditContext is null)
        {
            throw new InvalidOperationException(
                $"{nameof(CustomValidation)} requires a cascading " +
                $"parameter of type {nameof(Microsoft.AspNetCore.Components.Forms.EditContext)}. " +
                $"For example, you can use {nameof(CustomValidation)} " +
                $"inside an {nameof(EditForm)}.");
        }

        _messageStore = new(EditContext);

        EditContext.OnValidationRequested += (s, e) => 
            _messageStore?.Clear();
        EditContext.OnFieldChanged += (s, e) => 
            _messageStore?.Clear(e.FieldIdentifier);
    }

    public void DisplayErrors(Dictionary<string, List<string>> errors)
    {
        if (EditContext is null) return;

        foreach (var err in errors)
        {
            _messageStore?.Add(EditContext.Field(err.Key), err.Value);
        }

        EditContext.NotifyValidationStateChanged();
    }

    public void ClearErrors()
    {
        _messageStore?.Clear();
        EditContext?.NotifyValidationStateChanged();
    }
}
