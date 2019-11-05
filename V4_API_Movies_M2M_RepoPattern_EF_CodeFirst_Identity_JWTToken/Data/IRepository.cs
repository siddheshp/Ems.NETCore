using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using V4_API_Movies_M2M_RepoPattern_EF_CodeFirst_Identity_JWTToken.Dtos;
using V4_API_Movies_M2M_RepoPattern_EF_CodeFirst_Identity_JWTToken.Models;

namespace V4_API_Movies_M2M_RepoPattern_EF_CodeFirst_Identity_JWTToken.Data
{
    public interface IRepository
    {
        IEnumerable<Movie> GetMovies();
        bool AddActor(Actor actor);
        IEnumerable<Actor> GetActors();
        Actor GetActor(int id);
        bool UpdateActor(Actor actor);
        bool DeleteActor(Actor actor);
        Movie GetMovie(int id);
        bool AddMovie(MovieDto movie);
        bool UpdateMovie(MovieDto movie);
        bool DeleteMovie(Movie movie);
    }
}
