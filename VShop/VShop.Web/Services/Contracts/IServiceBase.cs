using VShop.Web.Models;

namespace VShop.Web.Services
{
    public interface IServiceBase<TViewModel> where TViewModel : ViewModelBase
    {
        Task<TViewModel?> Create(TViewModel model);
        Task<TViewModel?> Update(TViewModel model);
        Task<bool> Delete(Guid id);
        Task<TViewModel?> GetById(Guid id);
        Task<IEnumerable<TViewModel?>?> GetAll();
    }
}