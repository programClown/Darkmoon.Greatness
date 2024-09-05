using System.Collections.ObjectModel;

namespace Darkmoon.Greatness.Models.Logging;

public interface ILogDataStore
{
    ObservableCollection<LogModel> Entries { get; }

    void AddEntry(LogModel logModel);
}