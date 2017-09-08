using AutoMapper;
using Fbiz.PraticalTest.Store.ViewModels;
using Fbiz.PraticalTest.Domain.Entities;

namespace Fbiz.PraticalTest.Store.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CategoryViewModel, Category>();
            Mapper.CreateMap<ProductViewModel, Product>();
            Mapper.CreateMap<CommentViewModel, Comment>();
        }
    }
}