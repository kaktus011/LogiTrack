using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepository repository;

        public DriverService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> DriverHasDeliveryAsync(string username, int deliveryId)
        {
            return await repository.AllReadonly<Delivery>().AnyAsync(x => x.Id == deliveryId && x.Driver.User.UserName == username);
        }

        public async Task<bool> DriverWithUsernameExistsAsync(string username)
        {
            return await repository.AllReadonly<Driver>().AnyAsync(x => x.User.UserName == username);
        }
        public async Task<DriverDashboardViewModel?> GetDriverDashboardAsync(string username)
        {
            var driver = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Where(x => x.User.UserName == username).FirstOrDefaultAsync();
            var model = new DriverDashboardViewModel()
            {
                KilometersDriven = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).SumAsync(x => x.Offer.Request.Kilometers),
                KilometersDrivenlastMonth = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.Offer.Request.ExpectedDeliveryDate.Month == DateTime.Now.Month - 1).SumAsync(x => x.Offer.Request.Kilometers),
                NewDeliveriesCount = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DeliveryStep == 1).CountAsync()
            };
            model.LastDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).OrderByDescending(x => x.Offer.OfferDate).Take(5)
                .Select(x => new DeliveryForDriverDashboardViewModel
                {
                    Id = x.Id,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    ReferenceNumber = x.ReferenceNumber
                })
                .ToListAsync();
            model.NewDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.DeliveryStep == 1)
                .Select(x => new DeliveryForDriverDashboardViewModel
                {
                    Id = x.Id,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    ReferenceNumber = x.ReferenceNumber
                }).ToListAsync();
            return model;
        }

        public async Task<DriverDetailsViewModel?> GetDriverDetailsAsync(string username)
        {
            return await repository.AllReadonly<Driver>().Where(x => x.User.UserName == username)
                .Select(x => new DriverDetailsViewModel
                {
                    Name = x.Name,
                    Username = x.User.UserName,
                    Salary = x.Salary.ToString(),
                    Age = x.Age.ToString(),
                    YearOfExperience = x.YearOfExperience.ToString(),
                    MonthsOfExperience = x.MonthsOfExperience.ToString(),
                    Preferrences = x.Preferrences
                }).FirstOrDefaultAsync();
        }
        public async Task<LicenseViewModel?> GetDriversLicenseAsync(string username)
        {
            return await repository.AllReadonly<Driver>().Where(x => x.User.UserName == username)
                .Select(x => new LicenseViewModel
                {
                    LicenseNumber = x.LicenseNumber,
                    LicenseExpiryDate = x.LicenseExpiryDate,
                }).FirstOrDefaultAsync();
        }
    }
}
