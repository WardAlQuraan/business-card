using BUSINESS_CARD_CONTEXT;
using BUSINESS_CARD_CORE;
using BUSINESS_CARD_ENTITIES;

namespace BUSINESS_CARD_REPOSITORIES
{
  public interface IBusinessCardRepo : IBaseRepo<BusinessCard , BusinessCardContext , BusinessCardSearchParam>
  {
  }
}
