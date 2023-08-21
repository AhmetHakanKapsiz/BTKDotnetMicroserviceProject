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
        private IMessageService _messageService;
        public YoneticiController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /*public async Task<IActionResult> Index()
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
        }*/

        public async Task<IActionResult> Index()
        {
            List<Message> list = new();
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _messageService.GetMessages<ResponseDto>("");
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Message>>(Convert.ToString(response.Result));
            }
            return View(list);
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
