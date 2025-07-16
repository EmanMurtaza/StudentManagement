// File: Controllers/ContactsController.cs
using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Add()
        {
            return View(); // returns Views/Contacts/Add.cshtml
        }
    }
}
