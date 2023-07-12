

using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI;

namespace Avalonia_ItemsControl_Issue.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ReadOnlyObservableCollection<string> _elements;

    private readonly SourceCache<string, string> _elementsSourceCache = new SourceCache<string, string>(x => x);
    
    public MainViewModel()
    {
        _elementsSourceCache.Connect()
            .ObserveOn(RxApp.MainThreadScheduler)
            .Bind(out _elements)
            .Subscribe();
        
        BuildInterface();
    }

    public ReadOnlyObservableCollection<string> Elements => _elements;

    public void AddElement()
    {
        _elementsSourceCache.AddOrUpdate($"Element {Elements.Count + 1}");
    }

    public void RemoveLastElement()
    {
        if (Elements.Count > 0)
        {
            _elementsSourceCache.RemoveKey(Elements[^1]);
        }
    }

    public void ResetElements()
    {
        _ = Task.Run(SomeAsyncMethod);
    }

    private void BuildInterface()
    {
        _elementsSourceCache.Clear();

        for (int i = 0; i < 3; i++)
        {
            _elementsSourceCache.AddOrUpdate($"Element {i + 1}");
        }
    }

    private async Task SomeAsyncMethod()
    {
        // simulating the time it take to close and restart a daemon app and then reconnecting
        await Task.Delay(500);

        _ = Task.Run(BuildInterface);
    }
}
