using BtkAkademi.Web.Models;
using BtkAkademi.Web.Services;
using BtkAkademi.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademi.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class YoneticiController : Controller
    {
        /*private MessageService messageService;
        public YoneticiController(MessageService messageService)
        {
            this.messageService = messageService;
        }*/
        public async Task<IActionResult> Index()
        {
            List<Message> messageList = new List<Message>();
            //rest apiye talepte bulunacak nesnemiz
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5050/api/messages"))
                {
                    var gelenString = await response.Content.ReadAsStringAsync();
                    messageList = JsonConvert.DeserializeObject<List<Message>>(gelenString);

                }
            }
            return View(messageList);
        }

        public IActionResult Git()
        {
            return View();
        }

        public IActionResult AdminLogout()
        {
            return SignOut("Cookies", "oidc");
        }


    }
}
