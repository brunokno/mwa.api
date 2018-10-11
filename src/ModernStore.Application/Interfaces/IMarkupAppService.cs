using ModernStore.Application.ViewModels;

namespace ModernStore.Application.Interfaces
{
    public interface IMarkupAppService
    {
        MarkupListViewModel GetAll();
        void Register(MarkupListViewModel markupListViewModel); 
    }
}
