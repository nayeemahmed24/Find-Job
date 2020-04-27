using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InterviewBoard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewBoard.Controllers
{
    public class ChatterController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<UserAcc> _userManager;
        public ChatterController(ApplicationDbContext db , UserManager<UserAcc> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Index(string username)
        {
                string senderUserName = User.Identity.Name;
                string recieveUsername = username;


                List<Messege> messeges = new List<Messege>();

                
                messeges = await _db.Messege.Where(d => (d.SenderUsername == senderUserName && d.ReciverUsername == recieveUsername) || (d.SenderUsername == recieveUsername && d.ReciverUsername == senderUserName)).ToListAsync();
                
                ViewBag.Messeges = messeges;
                ViewBag.Role = await ReturnRole();

                ViewBag.Name = await ReturnName();
                ViewBag.username = senderUserName;
                ViewBag.Reciever = getUserName(recieveUsername);
                ViewBag.RExtension = getExtension(recieveUsername);
                
                 Debug.Print(getUserName(recieveUsername));
            return View();
            

        }
       
        public async Task<IActionResult> Create(string chat,string reciever, string ext)
        {
            string senderUserName = User.Identity.Name;
            UserAcc currentUser = await _userManager.FindByNameAsync(senderUserName);
            Messege messege = new Messege();
            messege.SenderUser = currentUser;
            messege.ReciverUsername = reciever + "@" + ext;
            messege.SenderUsername = senderUserName;
            messege.text = chat;
            await _db.Messege.AddAsync(messege);
            await _db.SaveChangesAsync();
            // Debug.Print(chat + " " + reciever + " " + ext);
            return Ok();
        }



        public async Task<string> ReturnRole()
        {
            string userName = User.Identity.Name;
            string Role = "";

            if (userName != null)
            {
                UserAcc currentUser = await _userManager.FindByNameAsync(userName);

                if (await _userManager.IsInRoleAsync(currentUser, "malik"))
                {
                    Role = "malik";
                }
                else
                {
                    Role = "golam";
                }
            }
            return Role;

        }

        public async Task<string> ReturnName()
        {
            string userName = User.Identity.Name;
            string Role = "";

            if (userName != null)
            {
                UserAcc currentUser = await _userManager.FindByNameAsync(userName);
                Role = currentUser.Name;
            }
            return Role;

        }
        private string getUserName(string email)
        {
            string s = "";
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    break;
                }

                s += email[i];
            }

            return s;
        }
        private string getExtension(string email)
        {
            string s = "";
            bool flag = false;
            for (int i = 0; i < email.Length; i++)
            {
                
                if (email[i] == '@')
                {
                    flag = true;
                    continue;
                }
                if (flag == false) continue;

                s += email[i];
            }

            return s;
        }
    }


}