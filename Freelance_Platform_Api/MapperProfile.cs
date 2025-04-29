using AutoMapper;
using DataAccess.Entities;
using Freelance_Platform_Api.Models;
namespace Freelance_Platform_Api
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<CreateUserModel, User>();
            CreateMap<CreateChatModel, Chat>();
            CreateMap<CreateProjectModel, Project>();
            CreateMap<CreateProposalModel, Proposal>();
            CreateMap<CreateReviewModel, Review>();
            CreateMap<CreateTransactionModel, Transaction>();
        }
    }
}
