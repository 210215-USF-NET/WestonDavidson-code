using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToHBL;
using ToHMVC.Models;

namespace ToHMVC.Controllers
{
    public class HeroController : Controller
    {
        private readonly IHeroBL _heroBL;
        private readonly IMapper _mapper;

        public HeroController(IHeroBL heroBL, IMapper mapper)
        {
            _heroBL = heroBL;
            _mapper = mapper;
        }
        //the methods in our controllers are called actions - they respond to client requests
        //you can have specific actions respond to specific client requests
        //you can also have actions that respond to different client requests
        //you just have to map the request type to the action properly
        //actionresults can return many different things, but for now we'll just return views since we're tightly coupling our server and frontend logic
        //this tightly coupling is a BAD idea, but we're doing it for now???
        // GET: HeroController
        public ActionResult Index()
        {
            //tying a view to a model is a strongly typed view
            //you have different kinds of views:
            //strongly typed - tied to a model
            //weakly typed - not tied to a model. gets data via viewbag, viewdata, temptdata, etc.
            //dynamic - pass a model, don't tie it to a view, let the view figure it out, 
                //(do some further research into this)

            //let's create a strongly typed view:
            return View(_heroBL.GetHeroes().Select(hero => _mapper.cast2HeroIndexVM(hero)).ToList());
        }
        //view discovery is basically how asp.net mvc finds the appropriate views
        //details corresponds to the actionmapper we set up in our html
        // GET: HeroController/Details?name={heroName}
        public ActionResult Details(string name)
        {
            return View(_mapper.cast2HeroCRVM(_heroBL.GetHeroByName(name)));
        }


        // GET: HeroController/Create
        public ActionResult Create()
        {
            return View("CreateHero");
        }

        // POST: HeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //stores our form property/values in a key/value way
        //we will use property binding to bind to a model?
        public ActionResult Create(HeroCRVM newHero)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _heroBL.AddHero(_mapper.cast2Hero(newHero));
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        //will have to build the hero DL method for editing and also the view and the actions related to it
        // GET: HeroController/Edit/5
        public ActionResult Edit(string name)
        {
            return View("EditHero", _mapper.cast2HeroEditVM(_heroBL.GetHeroByName(name)));
        }

        // POST: HeroController/Edit/{hero2BUpdated.HeroName}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HeroEditVM hero2BUpdated)
        {//Model State isvalid literally means model data is valid
            if (ModelState.IsValid)
            {
                try
                {
                    _heroBL.UpdateHero(_mapper.cast2HeroEditVM(hero2BUpdated));


                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }


            }
            return View();





        }

        // GET: HeroController/Delete/5
        public ActionResult Delete(string name)
        {
            _heroBL.DeleteHero(_heroBL.GetHeroByName(name));
            return RedirectToAction(nameof(Index));
        }

        // POST: HeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
