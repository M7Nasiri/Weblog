using App.Domain.Entities;
using App.Domain.ViewModels.Post;
using App.Domain.ViewModels.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, GetUserViewModel>().ReverseMap();
            CreateMap<AppUser, LoginUserViewModel>().ReverseMap();
            CreateMap<AppUser, RegisterUserViewModel>().ReverseMap();
            CreateMap<AppUser, UpdatePasswordUserViewModel>().ReverseMap();
            CreateMap<AppUser, UpdateUserByAdminViewModel>().ReverseMap();


            CreateMap<Post, CreatePostViewModel>().ReverseMap();
            CreateMap<Post, DeletePostViewModel>().ReverseMap();
            CreateMap<Post, UpdatePostViewModel>().ReverseMap();


            CreateMap<Post, GetPostViewModel>().ReverseMap();

            CreateMap<Post, GetPostViewModel>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Cateogry.Title))
            .ForMember(dest => dest.WriterUserName, opt => opt.MapFrom(src => src.Writer.UserName))
            .ForMember(dest => dest.VerifierUserName, opt => opt.MapFrom(src => src.Verifier != null ? src.Verifier.UserName : null));
            //.ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Description.Length > 200 ? src.Description.Substring(0, 200) : src.Description));

            CreateMap<Post, PostDetailsViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Cateogry.Title))
                .ForMember(dest => dest.WriterUserName, opt => opt.MapFrom(src => src.Writer.UserName));
        }
    }
}
