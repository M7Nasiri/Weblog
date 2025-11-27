using App.Domain.Entities;
using App.Domain.ViewModels.Comment;
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
            CreateMap<AppUser, CreateUserByAdmin>().ReverseMap();
            CreateMap<AppUser, DeleteUserByAdmin>().ReverseMap();
            
            CreateMap<GetUserViewModel, DeleteUserByAdmin>().ReverseMap();
            CreateMap<GetUserViewModel, UpdateUserByAdminViewModel>().ReverseMap();

            CreateMap<AppUser, UserInfoForAdmin>()
                .ForMember(dest => dest.WriterPostCount, opt => opt.MapFrom(src => src.WrittenPosts.Count))
                .ForMember(dest => dest.VerifierPostCount, opt => opt.MapFrom(src => src.VerifiednPosts.Count));

            CreateMap<CommentAgg, CreateCommentViewModel>().ReverseMap();
            CreateMap<CommentAgg, GetCommentViewModel>().ReverseMap();
            CreateMap<CommentAgg, ApprovedCommentViewModel>().ReverseMap();
            CreateMap<CommentAgg, ShowCommentInPostDetails>().ReverseMap();
            CreateMap<GetCommentViewModel, ApprovedCommentViewModel>().ReverseMap();
            CreateMap<CommentAgg, GetCommentViewModel>()
                .ForMember(dest => dest.PostText, opt => opt.MapFrom(src => src.Post.Summary))
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post.Title));

            CreateMap<PostAgg, CreatePostViewModel>().ReverseMap();
            CreateMap<PostAgg, DeletePostViewModel>().ReverseMap();
            CreateMap<PostAgg, UpdatePostViewModel>().ReverseMap();


            CreateMap<PostAgg, GetPostViewModel>().ReverseMap();

            CreateMap<PostAgg, GetPostViewModel>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Cateogry.Title))
            .ForMember(dest => dest.WriterUserName, opt => opt.MapFrom(src => src.Writer.UserName))
            .ForMember(dest => dest.VerifierUserName, opt => opt.MapFrom(src => src.Verifier != null ? src.Verifier.UserName : null));
            //.ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Description.Length > 200 ? src.Description.Substring(0, 200) : src.Description));

            CreateMap<PostAgg, PostDetailsViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Cateogry.Title))
                .ForMember(dest => dest.WriterUserName, opt => opt.MapFrom(src => src.Writer.UserName));
        }
    }
}
