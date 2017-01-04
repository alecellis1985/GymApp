using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Models;
using GymApp.Services;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GymApp.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IConfigurationRoot _config;
        private GymContext _context;

        public AppController(IMailService mailService, IConfigurationRoot config, GymContext context)
        {
            _mailService = mailService;
            _config = config;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {

            if (model.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("Email", "We do not support AOL addresses");
            }
            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From the gym", model.Message);

                ModelState.Clear();
                ViewBag.UserMessage = "Message Sent";
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

    }
}
