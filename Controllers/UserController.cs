using CRUD_Respository.Repository.Interface;
using CRUD_Respository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRUD_Repository.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser userRepository;

        public UserController(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> GetUsersList()
        {
            var data = await userRepository.GetUsers();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await userRepository.AddUser(user);
                return RedirectToAction(nameof(GetUsersList));
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                await userRepository.UpdateUser(user);
                return RedirectToAction(nameof(GetUsersList));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await userRepository.DeleteUser(id);
            return RedirectToAction(nameof(GetUsersList));
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
    }
}

