using BUSINESS_CARD_ENTITIES;

namespace BUSINESS_CARD_REPOSITORIES
{
    public interface IBusinessCardRepo
    {
        Task<List<BusinessCard>> SearchAsync(BusinessCardParam param);
        Task<BusinessCard> InsertAsync(BusinessCard newBusinessCard);
        Task<bool> DeleteAsync(int id);
    }
}
