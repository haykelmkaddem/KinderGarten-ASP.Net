﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class ExtraController : Controller
    {
        ExtraService extraService = new ExtraService();
        // GET: Extra
        public ActionResult Index()
        {
            return View(extraService.GetAll());
        }

        // GET: Extra/Details/5
        public ActionResult Details(int id)
        {
            Extra extra = extraService.getExtraById(id);
            if (extra != null)
            {
                return View(extra);
            }
            return View();
        }

        // GET: Extra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Extra/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Description,Price")] Extra extra)
        {
            if (extraService.Add(extra))
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Extra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Extra/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Description,Price")] Extra extra)
        {
            try
            {
                if (extraService.Update(id, extra))
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Extra/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Extra/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (extraService.deleteExtraById(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

