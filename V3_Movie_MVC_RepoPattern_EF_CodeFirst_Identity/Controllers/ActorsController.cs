﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Data;
using V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Models;
using V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.ViewModels;

namespace V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Controllers
{
    public class ActorsController : Controller
    {
        IRepository repository;
        public ActorsController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: Actors
        public ActionResult Index()
        {
            return View(repository.GetActors());
        }

        // GET: Actors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: Actors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor actor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = repository.AddActor(actor);
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    return View();
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: Actors/Edit/5
        public ActionResult Edit(int id)
        {
            var actor = repository.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        [Authorize]
        // POST: Actors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Actor actor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                if (id != actor.Id)
                {
                    return View();
                }
                bool result = repository.EditActor(actor);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: Actors/Delete/5
        public ActionResult Delete(int id)
        {
            var actor = repository.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        [Authorize]
        // POST: Actors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var actor = repository.GetActorById(id);
                if (actor != null)
                {
                    bool result = repository.DeleteActor(actor);
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetActorsByGender()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetActorsByGender(Gender gender)
        {
            var list = repository.GetActorsByGender(gender);
            return View(list);
        }

        public ActionResult GetActorsByMovie()
        {
            var viewModel = new MovieActorsViewModel
            {
                Movies = repository.GetMovies().Select(m =>
                        new SelectListItem(m.Name, m.Id.ToString())).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult GetActorsByMovie(int id)
        {
            var viewModel = new MovieActorsViewModel
            {
                Movies = repository.GetMovies().Select(m =>
                        new SelectListItem(m.Name, m.Id.ToString())).ToList(),
                Actors = repository.GetActorsByMovie(id)
            };
            return View(viewModel);
        }
    }
}