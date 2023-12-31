﻿using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.GetBooks;
using BookStore.Application.BookOperations.GetById;
using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using BookStore.Application.GenreOperations.Queries.GetGenres;
using BookStore.Entities;

namespace BookStore.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
        }
    }
}
