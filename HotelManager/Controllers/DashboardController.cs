using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: /Dashboard/Index - Redirects based on user role
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Admin");
            }
            return RedirectToAction("Customer");
        }

        // GET: /Dashboard/Customer - Customer dashboard showing available rooms and history
        [Authorize(Roles = "User")]
        public IActionResult Customer()
        {
            return View();
        }

        // GET: /Dashboard/AvailableRooms - Shows available rooms for customers
        [Authorize(Roles = "User")]
        public IActionResult AvailableRooms()
        {
            // TODO: Get available rooms from database
            // For now, passing empty list since models are not created yet
            return View();
        }

        // GET: /Dashboard/MyBookings - Shows booking history for customers
        [Authorize(Roles = "User")]
        public IActionResult MyBookings()
        {
            // TODO: Get user's booking history from database
            // For now, passing empty list since models are not created yet
            return View();
        }

        // GET: /Dashboard/Admin - Admin dashboard for managing customers and rooms
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        // GET: /Dashboard/ManageCustomers - Manage customers (Admin only)
        [Authorize(Roles = "Admin")]
        public IActionResult ManageCustomers()
        {
            // TODO: Get all customers from database
            return View();
        }

        // GET: /Dashboard/Rooms - List all rooms (Admin only)
        [Authorize(Roles = "Admin")]
        public IActionResult Rooms()
        {
            // TODO: Get all rooms from database
            return View();
        }

        // GET: /Dashboard/CreateRoom - Create new room (Admin only)
        [Authorize(Roles = "Admin")]
        public IActionResult CreateRoom()
        {
            return View();
        }

        // POST: /Dashboard/CreateRoom - Create new room (Admin only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRoom(IFormCollection form)
        {
            // TODO: Create new room in database
            // Model binding will be handled when Room model is created
            TempData["Success"] = "Room created successfully!";
            return RedirectToAction("Rooms");
        }

        // GET: /Dashboard/EditRoom/{id} - Edit room (Admin only)
        [Authorize(Roles = "Admin")]
        public IActionResult EditRoom(int id)
        {
            // TODO: Get room by id from database
            // For now, passing id to view
            ViewBag.RoomId = id;
            return View();
        }

        // POST: /Dashboard/EditRoom/{id} - Edit room (Admin only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult EditRoom(int id, IFormCollection form)
        {
            // TODO: Update room in database
            TempData["Success"] = "Room updated successfully!";
            return RedirectToAction("Rooms");
        }

        // GET: /Dashboard/DeleteRoom/{id} - Delete room (Admin only)
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteRoom(int id)
        {
            // TODO: Delete room from database
            TempData["Success"] = "Room deleted successfully!";
            return RedirectToAction("Rooms");
        }

        // POST: /Dashboard/DeleteCustomer/{id} - Delete customer (Admin only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomer(string id)
        {
            // TODO: Delete customer from database
            TempData["Success"] = "Customer deleted successfully!";
            return RedirectToAction("ManageCustomers");
        }
    }
}
