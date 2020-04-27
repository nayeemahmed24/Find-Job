﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InterviewBoard.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }

        public ViewResult Index() => View(roleManager.Roles);

        public async Task<IActionResult> Create()
        {
            IdentityResult result = await roleManager.CreateAsync(new IdentityRole("Employee"));
            return View();
        }

        // [HttpPost]
        // public async Task<IActionResult> Create([Required]string name)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
        //         if (result.Succeeded)
        //             return RedirectToAction("Index");
        //         else
        //             Errors(result);
        //     }
        //     return View(name);
        // }

        // [HttpPost]
        // public async Task<IActionResult> Delete(string id)
        // {
        //     IdentityRole role = await roleManager.FindByIdAsync(id);
        //     if (role != null)
        //     {
        //         IdentityResult result = await roleManager.DeleteAsync(role);
        //         if (result.Succeeded)
        //             return RedirectToAction("Index");
        //         else
        //             Errors(result);
        //     }
        //     else
        //         ModelState.AddModelError("", "No role found");
        //     return View("Index", roleManager.Roles);
        // }
        //
        // private void Errors(IdentityResult result)
        // {
        //     foreach (IdentityError error in result.Errors)
        //         ModelState.AddModelError("", error.Description);
        // }
        // public IActionResult Index()
        // {
        //     return View();
        // }
    }
}