using AutoMapper;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Store.ViewModels;

namespace Fbiz.PraticalTest.Store.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Comment, CommentViewModel>();
        }
    }
}