using VShop.Web.Models;

namespace VShop.Web.Services
{
    public interface IServiceBase<TViewModel> where TViewModel : ViewModelBase
    {
        Task<TViewModel?> Create(TViewModel model, string token);
        Task<TViewModel?> Update(TViewModel model, string token);
        Task<bool> Delete(Guid id, string token);
        Task<TViewModel?> GetById(Guid id, string token);
        Task<IEnumerable<TViewModel?>?> GetAll(string token);
    }
}