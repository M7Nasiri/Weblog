using App.Domain.Entities;
using App.Domain.ViewModels.CommentAgg;
using App.Domain.ViewModels.PostAgg;
using App.Domain.ViewModels.UserAgg;
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
            CreateMap<User, GetUserViewModel>().ReverseMap();
            CreateMap<User, LoginUserViewModel>().ReverseMap();
            CreateMap<User, RegisterUserViewModel>().ReverseMap();
            CreateMap<User, UpdatePasswordUserViewModel>().ReverseMap();
            CreateMap<User, UpdateUserByAdminViewModel>().ReverseMap();
            CreateMap<User, CreateUserByAdmin>().ReverseMap();
            CreateMap<User, DeleteUserByAdmin>().ReverseMap();
            
            CreateMap<GetUserViewModel, DeleteUserByAdmin>().ReverseMap();
            CreateMap<GetUserViewModel, UpdateUserByAdminViewModel>().ReverseMap();

            CreateMap<User, UserInfoForAdmin>()
                .ForMember(dest => dest.WriterPostCount, opt => opt.MapFrom(src => src.WrittenPosts.Count))
                .ForMember(dest => dest.VerifierPostCount, opt => opt.MapFrom(src => src.VerifiednPosts.Count));

            CreateMap<Comment, CreateCommentViewModel>().ReverseMap();
            CreateMap<Comment, GetCommentViewModel>().ReverseMap();
            CreateMap<Comment, ApprovedCommentViewModel>().ReverseMap();
            CreateMap<Comment, ShowCommentInPostDetails>().ReverseMap();
            CreateMap<GetCommentViewModel, ApprovedCommentViewModel>().ReverseMap();
            CreateMap<Comment, GetCommentViewModel>()
                .ForMember(dest => dest.PostText, opt => opt.MapFrom(src => src.Post.Summary))
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post.Title));

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
