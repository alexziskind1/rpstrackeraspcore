using Microsoft.AspNetCore.Mvc.RazorPages;
using RPS.Core.Models;
using RPS.Data;
using System.Collections.Generic;
using System.Linq;

namespace RPS.Web.Pages
{
    public class BacklogModel : PageModel
    {
        private const int CURRENT_USER_ID = 21; //Fake user id for demo

        private readonly IPtUserRepository rpsUserRepo;
        private readonly IPtItemsRepository rpsItemsRepo;
        private readonly IPtTasksRepository rpsTasksRepo;
        private readonly IPtCommentsRepository rpsCommentsRepo;

        public List<PtItem> Items { get; set; }

        public BacklogModel(
            IPtUserRepository rpsUserData,
            IPtItemsRepository rpsItemsData,
            IPtTasksRepository rpsTasksData,
            IPtCommentsRepository rpsCommentsData
            )
        {
            rpsUserRepo = rpsUserData;
            rpsItemsRepo = rpsItemsData;
            rpsTasksRepo = rpsTasksData;
            rpsCommentsRepo = rpsCommentsData;
        }

        public void OnGet()
        {
            Items = rpsItemsRepo.GetAll().ToList();
        }
    }
}