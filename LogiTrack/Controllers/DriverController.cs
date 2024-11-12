using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Accountant;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Core.Services;

namespace LogiTrack.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IDriverService _driverService;
        private readonly GeocodingService _geocodingService;

        public DriverController(IDeliveryService deliveryService, IDriverService driverService, GeocodingService geocodingService)
        {
            this._deliveryService = deliveryService;
            this._driverService = driverService;
            this._geocodingService = geocodingService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            //var username = User.GetUsername();
            var username = "driver1@example.com";
            if (await _driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            var model = await _driverService.GetDriverDashboardAsync(username);
            return View(model);
        }

        [HttpGet]
        public IActionResult SearchDelivery()
        {
            var model = new SearchDeliveryByReferenceNumberViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchDelivery(SearchDeliveryByReferenceNumberViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            //var username = User.GetUsername();
            var username = "driver1@example.com";
            if (await _driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }

            var deliveryId = await _deliveryService.GetDeliveryByReferenceNumberAsync(model.ReferenceNumber);
            if (deliveryId != default)
            {
                TempData["NotFound"] = DeliveryNotFoundErrorMessage;
                return View(model);
            }

            if (await _driverService.DriverHasDeliveryAsync("driver1@example.com", deliveryId) == false)
            {
                TempData["NotAuthorize"] = DriverDoesNotHaveDeliveryErrorMessage;
                return View(model);
            }

            return RedirectToAction(nameof(DeliveryDetails), new { id = deliveryId });
        }

        [HttpGet]
        public async Task<IActionResult> DeliveryDetails(int id)
        {
            if (await _deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return NotFound(DeliveryNotFoundErrorMessage);
            }

            //var username = User.GetUsername();
            var username = "driver1@example.com";
            if (await _driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }

            if (await _driverService.DriverHasDeliveryAsync(username, id) == false)
            {
                return Unauthorized(DriverDoesNotHaveDeliveryErrorMessage);
            }

            var model = await _deliveryService.GetDeliveryDetailsForDriverAsync(id);
            return View(model);
        }
      
        [HttpGet]
        public async Task<IActionResult> AddStatus(int id)
        {
            if (await _deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return BadRequest(DeliveryNotFoundErrorMessage);
            }

            //var username = User.GetUsername();
            var username = "driver1@example.com";
            if (await _driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }

            if (await _deliveryService.DriverHasDeliveryAsync(username, id) == false)
            {
                return Unauthorized(DriverDoesNotHaveDeliveryErrorMessage);
            }

            var model = new AddStatusViewModel
            {
                DeliveryId = id
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStatus(int id, AddStatusViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            if(model.Latitude == null || model.Longitude == null)
            {
                return View(model);
            }

            var address = await _geocodingService.GetAddress(model.Latitude.Value, model.Longitude.Value);
            if (address == null)
            {
                ModelState.AddModelError(string.Empty, InvalidCoordinatesErrorMessage);
                return View(model);
            }
            //var username = User.GetUsername();
            var username = "driver1@example.com";
            await _deliveryService.AddStatusForDeliveryAsync(id, model, username, address);
            return RedirectToAction(nameof(DeliveryDetails), new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> SearchDeliveries([FromQuery] SearchDeliveryForDriverViewModel query)
        {
            var username = "driver1@example.com";
            if (await _driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            var model = await _deliveryService.GetDeliveriesForDriverAsync(username, query.ReferenceNumber, query.EndDate, query.StartDate, query.DeliveryAddress, query.PickupAddress, query.IsNew);
            query.Deliveries = model;
            model = await _deliveryService.GetDeliveriesForDriverBySearchtermAsync(username, query.SearchTerm);
            query.Deliveries = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> DriverDetails()
        {
            var username = "driver1@example.com";
            if (await _driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            var model = await _driverService.GetDriverDetailsAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LicenseDetails()
        {
            var username = "driver1@example.com";
            if (await _driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            var model = await _driverService.GetDriversLicenseAsync(username);
            if(model.LicenseExpiryDate < DateTime.Now.AddDays(-30))
            {
                TempData["LicenseExpired"] = LicenseExpirationErrorMessage;
            }
            return View(model);
        }

        public IActionResult AllDeliveries()
        {
            throw new NotImplementedException();
        }
    }
}