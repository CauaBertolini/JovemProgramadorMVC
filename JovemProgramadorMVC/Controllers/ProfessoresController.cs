﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMVC.Controllers
{
    public class ProfessoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
