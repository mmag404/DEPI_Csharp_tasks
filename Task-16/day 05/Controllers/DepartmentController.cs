using day02.Models;
using day02.ViewModels;
using System;
using Microsoft.AspNetCore.Mvc;
public class DepartmentController : Controller
{
    private DepartmentBL deptBL = new DepartmentBL();
    

    // ==========================
    // ShowAll Lifecycle
    // ==========================
    public IActionResult ShowAll()
    {
        var depts = deptBL.GetAll();

        return View(depts);
    }

    // ==========================
    // ShowDetails Lifecycle
    // ==========================
    public IActionResult ShowDetails(int id)
    {
        var dept = deptBL.GetById(id);

        if (dept == null)
            return NotFound();

        // 
        var vm = new DeptWithExtraInfoViewModel();

        vm.DepartmentId = dept.Id;
        vm.DepartmentName = dept.Name;

        // Department State
        vm.DepartmentState = dept.Students.Count > 50 ? "Main" : "Branch";

        // Students > 25
        vm.StudentsOver25 = dept.Students
                                .Where(s => s.Age > 25)
                                .ToList();

        return View(vm);
    }

    // ==========================
    // Add (GET)
    // ==========================
    public IActionResult Add()
    {
        return View();
    }

    // ==========================
    // Add (POST)
    // ==========================
    [HttpPost]
    public IActionResult Add(Department dept)
    {
        if (!string.IsNullOrEmpty(dept.Name) && !string.IsNullOrEmpty(dept.MgrName))
        {
            deptBL.Add(dept);
            return RedirectToAction("ShowAll");
        }

        return View(dept);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Department dpt = deptBL.GetById(id);
        return View(dpt);
    }

    [HttpPost]
    public IActionResult Edit(Department newdpt)
    {
        if(ModelState.IsValid)
        {
            deptBL.Update(newdpt);
            return RedirectToAction(nameof(ShowAll));
        }
        return View(newdpt);
    }


}