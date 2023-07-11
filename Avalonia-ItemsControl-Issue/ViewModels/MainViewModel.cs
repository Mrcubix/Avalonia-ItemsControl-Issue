

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReactiveUI;

namespace Avalonia_ItemsControl_Issue.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ObservableCollection<string> _elements;

    public MainViewModel()
    {
        Elements = new ObservableCollection<string>();

        BuildInterface();
    }

    public ObservableCollection<string> Elements
    {
        get => _elements;
        set => this.RaiseAndSetIfChanged(ref _elements, value);
    }

    public void AddElement()
    {
        Elements.Add($"Element {Elements.Count + 1}");
    }

    public void RemoveLastElement()
    {
        if (Elements.Count > 0)
        {
            Elements.RemoveAt(Elements.Count - 1);
        }
    }

    public void ResetElements()
    {
        _ = Task.Run(SomeAsyncMethod);
    }

    private void BuildInterface()
    {
        Elements.Clear();

        for (int i = 0; i < 3; i++)
        {
            Elements.Add($"Element {i + 1}");
        }
    }

    private async Task SomeAsyncMethod()
    {
        // simulating the time it take to close and restart a daemon app and then reconnecting
        await Task.Delay(5000);

        _ = Task.Run(BuildInterface);
    }
}
