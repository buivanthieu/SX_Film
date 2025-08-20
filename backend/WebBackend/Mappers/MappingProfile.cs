using AutoMapper;
using WebBackend.Dtos.Actors;
using WebBackend.Dtos.Films;
using WebBackend.Dtos.Movies;
using WebBackend.Dtos.Series;
using WebBackend.Models;

namespace WebBackend.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Actor, GetActorDto>()
                .ReverseMap();
            CreateMap<CreateActorDto, Actor>()
                .ReverseMap();
            CreateMap<UpdateActorDto, Actor>()
                .ReverseMap();

            CreateMap<Movie, GetMovieDto>()
                .ReverseMap();
            CreateMap<CreateMovieDto, Movie>();

            CreateMap<Film, GetFilmDto>().ReverseMap();
            CreateMap<CreateFilmDto, Film>();

            CreateMap<Seri, GetSeriDto>()
                .ReverseMap();
            CreateMap<GetSeriWithSeasonsDto, Seri>()
                .ReverseMap();
        }
    } 
    
}
