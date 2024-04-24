using Microsoft.JSInterop;
using Inconfessio.Class;

namespace Inconfessio.Pages;

public partial class Home
{
    public string Confession { get; set; } = String.Empty;
    public string Response { get; set; } = String.Empty;

    ConfessionBoxState state;
    public ConfessionBoxState State
    {
        get => state;
        set
        {
            state = value;
            SetState((int)state);
        }
    }

    protected override void OnInitialized()
    {
        RestartConfession();
    }

    async Task SubmitConfession()
    {
        State = ConfessionBoxState.WaitingResponse;
        Response = await Sentient.AskQuestion(Confession);
        Console.WriteLine(Response);
        Response = Response.Replace(@"\n\n", "<br/>");
        Console.WriteLine(Response);
        State = ConfessionBoxState.ShowResponse;
    }
    
    void RestartConfession()
    {
        Confession = String.Empty;
        Response = String.Empty;
        State = ConfessionBoxState.ShowConfessionBox;
    }

    void SetState(int val)
    {
        Js.InvokeVoidAsync("SetState", val);
    }
}