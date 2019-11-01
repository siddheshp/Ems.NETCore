﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Models;

namespace V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Data
{
    public interface IRepository
    {
        IEnumerable<Movie> GetMovies();
        bool AddMovie(Movie movie);
        bool EditMovie(Movie movie);
        bool DeleteMovie(Movie movie);
        Movie GetMovieById(int movieId);
        IEnumerable<Movie> GetMoviesByGenre(Genre genre);
        IEnumerable<Movie> GetMoviesByActor(int actorId);

        IEnumerable<Actor> GetActors();
        bool AddActor(Actor actor);
        bool EditActor(Actor actor);
        bool DeleteActor(Actor actor);
        Actor GetActorById(int actorId);
        IEnumerable<Actor> GetActorsByGender(Gender gender);
        IEnumerable<Actor> GetActorsByMovie(int movieId);
    }
}
