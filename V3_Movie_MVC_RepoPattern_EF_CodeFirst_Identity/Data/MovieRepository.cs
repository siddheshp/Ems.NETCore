﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Models;
using V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.ViewModels;

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

        public bool AddMovie(MovieViewModel movieViewModel)
        {
            try
            {
                context.Movies.Add(movieViewModel.Movie);
                //for every actor selected
                foreach (var actor in movieViewModel.Actors)
                {
                    if (actor.Selected)
                    {
                        var existingActor = context.Actors.Find(
                            Convert.ToInt32(actor.Value));
                        existingActor.Movie = movieViewModel.Movie;
                        context.SaveChanges();
                    }
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteActor(Actor actor)
        {
            try
            {
                context.Actors.Remove(actor);
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

        public bool DeleteMovie(int movieId)
        {
            try
            {
                var movie = context.Movies.Include(m => m.Actors)
                    .ToList().Find(m => m.Id == movieId);
                movie.Actors.Clear();
                context.Movies.Remove(movie);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
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

        public bool EditMovie(MovieViewModel viewModel)
        {
            try
            {
                context.Entry<Movie>(viewModel.Movie).State =
                            EntityState.Modified;
                //for every actor selected
                foreach (var actor in viewModel.Actors)
                {
                    var existingActor = context.Actors.Find(
                               Convert.ToInt32(actor.Value));
                    if (actor.Selected)
                    {
                        existingActor.Movie = viewModel.Movie;
                    }
                    else
                    {
                        existingActor.Movie = null;
                    }
                    context.SaveChanges();
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
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
            try
            {
                return context.Actors.Where(a => a.Gender == gender);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Actor> GetActorsByMovie(int movieId)
        {
            try
            {
                return context.Actors.Where(a => a.Movie.Id == movieId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Movie GetMovieById(int movieId)
        {
            try
            {
                return context.Movies.Find(movieId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Movie> GetMovies()
        {
            return context.Movies.Include(m => m.Actors);
        }

        public IEnumerable<Movie> GetMoviesByActor(int actorId)
        {
            try
            {
                var actor = context.Actors.Find(actorId);
                //return context.Movies.Join(context.Actors,a=>a.Id, m=>m.;
                return context.Movies.ToList().FindAll(
                    m => m.Actors.Where(a => a.Id == actorId).FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Movie> GetMoviesByGenre(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
