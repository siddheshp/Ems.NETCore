﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Data;
using V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Models;

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

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

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
                bool result =repository.EditActor(actor);
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

        // GET: Actors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Actors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}