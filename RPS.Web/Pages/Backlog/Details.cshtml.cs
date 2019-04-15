using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPS.Core.Models;
using RPS.Data;
using RPS.Web.Models.Routing;

namespace RPS.Web.Pages.Backlog
{
    public class DetailsModel : PageModel
    {
        private const int CURRENT_USER_ID = 21; //Fake user id for demo

        private readonly IPtUserRepository rpsUserRepo;
        private readonly IPtItemsRepository rpsItemsRepo;
        private readonly IPtTasksRepository rpsTasksRepo;
        private readonly IPtCommentsRepository rpsCommentsRepo;

        public PtItem Item { get; set; }

        [BindProperty(SupportsGet = true)]
        public DetailScreenEnum Screen { get; set; }


        public DetailsModel(
            IPtUserRepository rpsUserData,
            IPtItemsRepository rpsItemsData,
            IPtTasksRepository rpsTasksData,
            IPtCommentsRepository rpsCommentsData)
        {
            rpsUserRepo = rpsUserData;
            rpsItemsRepo = rpsItemsData;
            rpsTasksRepo = rpsTasksData;
            rpsCommentsRepo = rpsCommentsData;
        }

        public IActionResult OnGet(int id)
        {
            Item = rpsItemsRepo.GetItemById(id);
            var users = rpsUserRepo.GetAll();
            var currentUser = users.Single(u => u.Id == CURRENT_USER_ID);

            //ViewData.Add("screen", DetailScreenEnum.Details);
            //ViewBag.users = users;
            //ViewBag.currentUser = currentUser;

            return Page();
        }
    }
}