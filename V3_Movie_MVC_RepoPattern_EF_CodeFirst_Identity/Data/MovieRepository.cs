﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Models;

namespace V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Data
{
    public class MovieRepository : IRepository
    {
        ApplicationDbContext context = null;
        public MovieRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool AddActor(Actor actor)
        {
            try
            {
                context.Actors.Add(actor);
                int result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddMovie(Movie movie)
        {
            try
            {
                context.Movies.Add(movie);
                int result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteActor(int actorId)
        {
            try
            {
                var actor = context.Actors.Find(actorId);
                if (actor != null)
                {
                    context.Actors.Remove(actor);
                    int result = context.SaveChanges();
                    if (result == 1)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        public bool EditActor(Actor actor)
        {
            try
            {
                context.Entry<Actor>(actor).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
                int result = context.SaveChanges();
                if (result == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool EditMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Actor GetActorById(int actorId)
        {
            try
            {
                return context.Actors.Find(actorId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Actor> GetActors()
        {
            return context.Actors.ToList();
        }

        public IEnumerable<Actor> GetActorsByGender(Gender gender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetActorsByMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int movieId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return context.Movies.ToList();
        }

        public IEnumerable<Movie> GetMoviesByActor(int actorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByGenre(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}