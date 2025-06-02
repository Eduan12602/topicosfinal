using CommunityToolkit.Mvvm.Input;
using practica05.Models;

namespace practica05.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}