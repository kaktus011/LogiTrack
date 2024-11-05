using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.Constants;

namespace LogiTrack.Core.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IRepository repository;

        public DeliveryService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> GetDeliveryByReferenceNumberAsync(string referenceNumber)
        {
            var deliveryId = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.ReferenceNumber == referenceNumber).Select(x => x.Id).FirstOrDefaultAsync();
            return deliveryId;
        }

        public async Task<bool> DeliveryWithIdExistsAsync(int deliveryId)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().AnyAsync(x => x.Id == deliveryId);
        }

        public async Task<DeliveryForDriverViewModel?> GetDeliveryDetailsForDriverAsync(int id)
        {
            var delivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Id == id)
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.StandartCargo)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                 .Include(x => x.Offer)
                 .ThenInclude(x => x.Request)
                 .ThenInclude(x => x.PickupAddress)
                 .Include(x => x.Offer)
                 .ThenInclude(x => x.Request)
                 .ThenInclude(x => x.DeliveryAddress)
                .FirstOrDefaultAsync();
            var model = new DeliveryForDriverViewModel
            {
                Id = delivery?.Id ?? throw new DeliveryNotFoundException(),
                ClientCompanyName = delivery.Offer.Request.ClientCompany.Name,
                CargoType = delivery.Offer.Request.CargoType,
                TypeOfPallet = delivery.Offer.Request.StandartCargo?.TypeOfPallet.ToString() ?? "0",
                NumberOfPallets = delivery.Offer.Request.StandartCargo?.NumberOfPallets.ToString() ?? "0",
                PalletLength = delivery.Offer.Request.StandartCargo?.PalletLength.ToString() ?? "0",
                PalletWidth = delivery.Offer.Request.StandartCargo?.PalletWidth.ToString() ?? "0",
                PalletHeight = delivery.Offer.Request.StandartCargo?.PalletHeight.ToString() ?? "0",
                PalletVolume = delivery.Offer.Request.StandartCargo?.PalletVolume.ToString() ?? "0",
                WeightOfPallets = delivery.Offer.Request.StandartCargo?.WeightOfPallets.ToString() ?? "0",
                PalletsAreStackable = delivery.Offer.Request.StandartCargo?.PalletsAreStackable == true ? "Yes" : "No",
                NumberOfNonStandartGoods = delivery.Offer.Request.NumberOfNonStandartGoods.ToString() ?? "0",
                TypeOfGoods = delivery.Offer.Request.TypeOfGoods,
                PickupAddress = $"{delivery.Offer.Request.PickupAddress.Street}, {delivery.Offer.Request.PickupAddress.City}, {delivery.Offer.Request.PickupAddress.County}",
                DeliveryAddress = $"{delivery.Offer.Request.DeliveryAddress.Street}, {delivery.Offer.Request.DeliveryAddress.City}, {delivery.Offer.Request.DeliveryAddress.County}",
                PickupLatitude = delivery.Offer.Request.PickupAddress.Latitude.ToString(),
                PickupCity = delivery.Offer.Request.PickupAddress.City,
                PickupCountry = delivery.Offer.Request.PickupAddress.County,
                PickupStreet = delivery.Offer.Request.PickupAddress.Street,
                PickupLongitude = delivery.Offer.Request.PickupAddress.Longitude.ToString(),
                DeliveryCity = delivery.Offer.Request.DeliveryAddress.City,
                DeliveryCountry = delivery.Offer.Request.DeliveryAddress.County,
                DeliveryStreet = delivery.Offer.Request.DeliveryAddress.Street,
                DeliveryLatitude = delivery.Offer.Request.DeliveryAddress.Latitude.ToString(),
                DeliveryLongitude = delivery.Offer.Request.DeliveryAddress.Longitude.ToString(),
                SharedTruck = delivery.Offer.Request.SharedTruck == true ? "Yes" : "No",
                ExpectedDeliveryDate = delivery.Offer.Request.ExpectedDeliveryDate.ToString("dd/MM/yyyy"),
                SpecialInstructions = delivery.Offer.Request.SpecialInstructions,
                IsRefrigerated = delivery.Offer.Request.IsRefrigerated == true ? "Yes" : "No",
                ReferenceNumber = delivery.ReferenceNumber,
                RegistrationNumber = delivery.Vehicle.RegistrationNumber,
                VehicleType = delivery.Vehicle.VehicleType,
                DeliveryStep = delivery.DeliveryStep
            };
            model.DeliveryTrackings = await repository.AllReadonly<Infrastructure.Data.DataModels.DeliveryTracking>().Where(x => x.DeliveryId == id)
                .Select(x => new DeliveryTrackingViewModel
                {
                    Timestamp = x.Timestamp.ToString("dd-MM-yyyy"),
                    StatusUpdate = x.StatusUpdate,
                    Address = x.Address,
                })
                .ToListAsync();
            model.NonStandardCargos = await repository.AllReadonly<Infrastructure.Data.DataModels.NonStandardCargo>().Where(x => x.RequestId == delivery.Offer.RequestId)
                .Select(x => new NonStandardCargosViewModel
                {
                    Length = x.Length.ToString(),
                    Width = x.Width.ToString(),
                    Height = x.Height.ToString(),
                    Weight = x.Weight.ToString(),
                    Description = x.Description
                }).ToListAsync();

            return model;
        }

        public async Task<bool> DriverWithUsernameExistsAsync(string username)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().AnyAsync(x => x.User.UserName == username);
        }

        public async Task<bool> DriverHasDeliveryAsync(string username, int id)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
                    .AnyAsync(x => x.Driver.User.UserName == username && x.Id == id);
        }

        public async Task AddStatusForDeliveryAsync(int deliveryId, AddStatusViewModel model, string username, string address)
        {
            var driver = await repository.All<Infrastructure.Data.DataModels.Driver>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var delivery = await repository.All<Infrastructure.Data.DataModels.Delivery>().FirstOrDefaultAsync(x => x.Id == deliveryId && x.DriverId == driver.Id);
            var deliveryTracking = new Infrastructure.Data.DataModels.DeliveryTracking
            {
                DeliveryId = deliveryId,
                DriverId = driver.Id,
                Notes = model.Notes,
                Timestamp = DateTime.Now,
                StatusUpdate = model.StatusUpdate,
                Latitude = model.Latitude.Value,
                Longitude = model.Longitude.Value,
                Address = address
            };
            var calendarEvent = new Infrastructure.Data.DataModels.CalendarEvent
            {
                EventType = model.StatusUpdate,
                Date = DateTime.Now,
                ClientCompanyId = delivery.Offer.Request.ClientCompanyId
            };
            switch (model.StatusUpdate)
            {
                case DeliveryTrackingStatusConstants.Collected:
                    delivery.DeliveryStep = 2;
                    calendarEvent.Title = $"Delivery {delivery.ReferenceNumber} collected";
                    break;
                case DeliveryTrackingStatusConstants.InTransit:
                    delivery.DeliveryStep = 3;
                    break;
                case DeliveryTrackingStatusConstants.Delivered:
                    delivery.DeliveryStep = 4;
                    calendarEvent.Title = $"Delivery {delivery.ReferenceNumber} delivered";
                    break;
            }
            await repository.AddAsync(calendarEvent);
            await repository.AddAsync(deliveryTracking);
            await repository.SaveChangesAsync();
        }
        public async Task<List<DeliveryViewModel>?> GetDeliveriesForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, bool? isNew = null)
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.StandartCargo)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .Where(x => x.Driver.User.UserName == username)
                .ToListAsync();

            if (isNew == true)
            {
                deliveries = deliveries.Where(x => x.DeliveryStep == 1).ToList();
            }
            if (string.IsNullOrEmpty(referenceNumber) == false)
            {
                deliveries = deliveries.Where(x => x.ReferenceNumber == referenceNumber).ToList();
            }
            if (endDate != null)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.ExpectedDeliveryDate <= endDate).ToList();
            }
            if (startDate != null)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.ExpectedDeliveryDate >= startDate).ToList();
            }
            if (string.IsNullOrEmpty(deliveryAddress))
            {
                deliveries = deliveries.Where(x => x.Offer.Request.DeliveryAddress.City.ToLower().Contains(deliveryAddress.ToLower()) || x.Offer.Request.DeliveryAddress.County.ToLower().Contains(deliveryAddress.ToLower()) || x.Offer.Request.DeliveryAddress.Street.ToLower().Contains(deliveryAddress.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(pickupAddress))
            {
                deliveries = deliveries.Where(x => x.Offer.Request.PickupAddress.City.ToLower().Contains(pickupAddress.ToLower()) || x.Offer.Request.PickupAddress.County.ToLower().Contains(pickupAddress.ToLower()) || x.Offer.Request.PickupAddress.Street.ToLower().Contains(pickupAddress.ToLower())).ToList();
            }

            var deliveriesToShow = deliveries.Select(x => new DeliveryViewModel
            {
                Id = x.Id,
                RequestId = x.Offer.RequestId,
                ClientCompanyId = x.Offer.Request.ClientCompanyId,
                ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                CargoType = x.Offer.Request.CargoType,
                TotalCargos = (x.Offer.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Offer.Request.NumberOfNonStandartGoods ?? 0),
                TotalVolume = x.Offer.Request.TotalVolume.ToString(),
                TotalWeight = x.Offer.Request.TotalWeight.ToString(),
                TypeOfGoods = x.Offer.Request.TypeOfGoods,
                PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                SharedTruck = x.Offer.Request.SharedTruck,
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd/MM/yyyy"),
                SpecialInstructions = x.Offer.Request.SpecialInstructions,
                IsRefrigerated = x.Offer.Request.IsRefrigerated,
                ReferenceNumber = x.ReferenceNumber,
                IsNew = x.DeliveryStep == 1 ? true : false
            }).ToList();
            return deliveriesToShow;
        }
        public async Task<List<DeliveryViewModel>?> GetDeliveriesForDriverBySearchtermAsync(string username, string? searchTerm)
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
               .Include(x => x.Vehicle)
               .Include(x => x.Driver)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.ClientCompany)
               .Where(x => x.Driver.User.UserName == username)
               .ToListAsync();

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.ClientCompany.Name.ToLower().Contains(searchTerm.ToLower())
                || x.Offer.Request.DeliveryAddress.City.ToLower().Contains(searchTerm.ToLower())
                || x.Offer.Request.DeliveryAddress.County.ToLower().Contains(searchTerm.ToLower())
                || x.Offer.Request.DeliveryAddress.Street.ToLower().Contains(searchTerm.ToLower())
                || x.Offer.Request.PickupAddress.City.ToLower().Contains(searchTerm.ToLower())
                || x.Offer.Request.PickupAddress.County.ToLower().Contains(searchTerm.ToLower())
                || x.Offer.Request.PickupAddress.Street.ToLower().Contains(searchTerm.ToLower())
                || x.ReferenceNumber.ToLower().Contains(searchTerm.ToLower())
                 ).ToList();
            }
            var deliveriesToShow = deliveries.Select(x => new DeliveryViewModel
            {
                Id = x.Id,
                RequestId = x.Offer.RequestId,
                ClientCompanyId = x.Offer.Request.ClientCompanyId,
                ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                CargoType = x.Offer.Request.CargoType,
                TypeOfPallet = x.Offer.Request.StandartCargo?.TypeOfPallet ?? "0",
                NumberOfPallets = x.Offer.Request.StandartCargo?.NumberOfPallets.ToString() ?? "0",
                PalletLength = x.Offer.Request.StandartCargo?.PalletLength.ToString() ?? "0",
                PalletWidth = x.Offer.Request.StandartCargo?.PalletWidth.ToString() ?? "0",
                PalletHeight = x.Offer.Request.StandartCargo?.PalletHeight.ToString() ?? "0",
                PalletVolume = x.Offer.Request.StandartCargo?.PalletVolume.ToString() ?? "0",
                WeightOfPallets = x.Offer.Request.StandartCargo?.WeightOfPallets.ToString() ?? "0",
                PalletsAreStackable = x.Offer.Request.StandartCargo?.PalletsAreStackable ?? false,
                NumberOfNonStandartGoods = x.Offer.Request.NumberOfNonStandartGoods.ToString(),
                TypeOfGoods = x.Offer.Request.TypeOfGoods,
                PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                SharedTruck = x.Offer.Request.SharedTruck,
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd/MM/yyyy"),
                SpecialInstructions = x.Offer.Request.SpecialInstructions,
                IsRefrigerated = x.Offer.Request.IsRefrigerated,
                ReferenceNumber = x.ReferenceNumber
            }).ToList();
            return deliveriesToShow;
        }

    }
}
