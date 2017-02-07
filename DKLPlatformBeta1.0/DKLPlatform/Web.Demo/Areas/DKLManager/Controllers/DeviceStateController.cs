﻿using DKLManager.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Demo.Common;

namespace Web.Demo.Areas.DKLManager.Controllers
{
    public class DeviceStateController : AdminControllerBase
    {
        //
        // GET: /DKLManager/DeviceState/
        public ActionResult Index(ProjectInfoRequest request)
        {
            var result = this.IDKLManagerService.GetDeviceStateList(request);
            return View(result);
        }
        public ActionResult Create()
        {
            var model = new DeviceStateModel();
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new DeviceStateModel();
            this.TryUpdateModel<DeviceStateModel>(model);
            this.IDKLManagerService.InsertDeviceState(model);
            return this.RefreshParent();
        }


        public ActionResult Edit(int id)
        {
            var model = this.IDKLManagerService.SelectDeviceState(id);
            return View(model);
        }

        //
        // POST: /Account/User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.IDKLManagerService.SelectDeviceState(id);
            this.TryUpdateModel<DeviceStateModel>(model);
            this.IDKLManagerService.UpDateDeviceState(model);

            return this.RefreshParent();
        }

        // POST: /Account/User/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            if (ids != null)
            {
                this.IDKLManagerService.DeleteDeviceState(ids);
            }
            return RedirectToAction("Index");
        }
    }
}