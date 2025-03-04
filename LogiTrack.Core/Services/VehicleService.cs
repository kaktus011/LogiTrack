﻿using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.FuelPrice;
using LogiTrack.Core.ViewModels.Vehicle;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }
      
        public async Task<bool> VehicleWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<Vehicle>().AnyAsync(v => v.Id == id);
        }

        public async Task<int> GetVehicleIdByRegistrationNumberAsync(string registrationNumber)
        {
            return await repository.AllReadonly<Vehicle>().Where(x => x.RegistrationNumber.Trim().ToLower() == registrationNumber.Trim().ToLower()).Select(x => x.Id).FirstOrDefaultAsync();
        }        

        public async Task<VehicleDetailsViewModel?> GetVehicleDetailsAsync(int id)
        {
            var deliveries = await repository.AllReadonly<Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.DeliveryAddress).Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.PickupAddress).Include(x => x.Invoice).Where(x => x.VehicleId == id).ToListAsync();
            var deliveriesCnt = deliveries.Count();
            var model = await repository.AllReadonly<Vehicle>().Where(x => x.Id == id)
                .Select(x => new VehicleDetailsViewModel
                {
                    Id = x.Id,
                    RegistrationNumber = x.RegistrationNumber,                    
                    EmisionFactor = x.EmissionFactor.ToString(),
                    VehicleType = x.VehicleType,
                    MaxWeightCapacity = x.MaxWeightCapacity.ToString(),
                    Length = x.Length.ToString(),
                    Width = x.Width.ToString(),
                    Height = x.Height.ToString(),
                    Volume = x.Volume.ToString(),
                    IsRefrigerated = x.IsRefrigerated,
                    VehicleStatus = x.VehicleStatus,
                    EuroPalletCapacity = x.EuroPalletCapacity.ToString(),
                    IndustrialPalletCapacity = x.IndustrialPalletCapacity.ToString(),
                    ArePalletsStackable = x.ArePalletsStackable,
                    FuelConsumptionPer100Km = x.FuelConsumptionPer100Km.ToString(),
                    DaysTillMaintenance = DateTime.Now.Subtract(x.LastYearMaintenance).Days,
                    LastYearMaintenance = x.LastYearMaintenance.ToString("dd-MM-yyy"),
                    KilometersDriven = x.KilometersDriven.ToString(),
                    KilometersLeftToChangeParts = (x.KilometersToChangeParts - x.KilometersDriven),
                    PurchasePrice = x.PurchasePrice.ToString(),
                    ContantsExpenses = x.ContantsExpenses.ToString(),
                    
                }).FirstOrDefaultAsync();
            var pricesPerSize = await repository.AllReadonly<PricesPerSize>().FirstOrDefaultAsync(x => x.VehicleId == id);
            model.QuotientForDomesticNotSharedTruck = pricesPerSize.QuotientForDomesticNotSharedTruck.ToString();
            model.QuotientForDomesticSharedTruck = pricesPerSize.QuotientForDomesticSharedTruck.ToString();
            model.QuotientForInternationalNotSharedTruck = pricesPerSize.QuotientForInternationalNotSharedTruck.ToString();
            model.QuotientForInternationalSharedTruck = pricesPerSize.QuotientForInternationalSharedTruck.ToString();
            model.DeliveriesLastMonth = deliveries.Where(x => x.Offer.Request.CreatedAt.Month > DateTime.Now.Month - 1 && x.Offer.Request.CreatedAt.Month < DateTime.Now.Month).Count();
            model.NotOnTimeDeliveries = deliveries.Where(x => x.ActualDeliveryDate > x.Offer.Request.ExpectedDeliveryDate).Count();
            model.EmissionFactorFrAllDeliveries = deliveries.Sum(x => x.CarbonEmission);
            model.AdditionalCost = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.CashRegister>().Where(x => x.Delivery.VehicleId == id).SumAsync(x => x.Amount);

            if (deliveriesCnt == 0)
            {
                model.AverageKilometers = 0;
                model.AverageAdditionalCost = 0;
            }
            else
            {
                model.AverageAdditionalCost = model.AdditionalCost / deliveriesCnt;
                model.AverageKilometers = deliveries.Sum(x => x.Offer.Request.Kilometers) / deliveriesCnt;
            }

            model.Deliveries = deliveries.Select(x => new DeliveryForClientsDeliveriesViewModel
            {
                Id = x.Id,
                ReferenceNumber = x.ReferenceNumber,
                DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                FinalPrice = x.Offer.FinalPrice.ToString(),
                IsDelivered = x.DeliveryStep == 4 ? true : false,
                TotalWeight = x.Offer.Request.TotalWeight.ToString(),
                TotalVolume = x.Offer.Request.TotalVolume.ToString(),
                TotalItems = x.Offer.Request.StandartCargo == null ? x.Offer.Request.NumberOfNonStandartGoods.ToString() : x.Offer.Request.StandartCargo.NumberOfPallets.ToString(),
                ActualDeliveryDate = x.ActualDeliveryDate.GetValueOrDefault().ToString("dd-MM-yyyy")
            }).ToList();
            return model;
        }

        public async Task<List<VehicleDetailsViewModel>> GetVehiclesAsync(bool refrigerated, string? registrationNumber = null, string? vehicleType = null, double? minWeightCapacity = null, double? maxWeightCapacity = null, double? minVolume = null, double? maxVolume = null, bool forMaintentance = false)
        {
            var query = repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().AsQueryable();
            if (refrigerated)
            {
				query = query.Where(x => x.IsRefrigerated == true);
            }
            if (string.IsNullOrEmpty(registrationNumber) == false)
            {
				query = query.Where(x => x.RegistrationNumber.ToLower().Contains(registrationNumber.ToLower()));
            }
            if (string.IsNullOrEmpty(vehicleType) == false)
            {
				query = query.Where(x => x.VehicleType.ToLower().Contains(vehicleType.ToLower()));
            }
            if(forMaintentance)
            {
				query = query.Where(x => x.LastYearMaintenance.AddMonths(1) >= DateTime.Now || x.KilometersLeftToChangeParts >= 500);
            }
            if (minWeightCapacity != null)
            {
				query = query.Where(x => x.MaxWeightCapacity >= minWeightCapacity);
            }
            if (maxWeightCapacity != null)
            {
				query = query.Where(x => x.MaxWeightCapacity <= maxWeightCapacity);
            }
            if (minVolume != null)
            {
				query = query.Where(x => x.Volume >= minVolume);
            }
            if (maxVolume != null)
            {
				query = query.Where(x => x.Volume <= maxVolume);
            }

            var vehicles = await query.ToListAsync();

			return vehicles.Select(x => new VehicleDetailsViewModel
            {
                Id = x.Id,
                RegistrationNumber = x.RegistrationNumber,
                VehicleType = x.VehicleType,
                MaxWeightCapacity = x.MaxWeightCapacity.ToString(),
                Length = x.Length.ToString(),
                Width = x.Width.ToString(),
                Height = x.Height.ToString(),
                Volume = x.Volume.ToString(),
                IsRefrigerated = x.IsRefrigerated,
                VehicleStatus = x.VehicleStatus,
                EmisionFactor = x.EmissionFactor.ToString(),
                FuelConsumptionPer100Km = x.FuelConsumptionPer100Km.ToString(),
            }).ToList();
        }

        public async Task<List<VehicleDetailsViewModel>> GetVehiclesBySearchTermAsync(string? searchTerm)
        {
            var query = repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().AsQueryable();
            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                var searchTermToLower = searchTerm.ToLower();
				query = query.Where(x => x.RegistrationNumber.ToLower().Contains(searchTermToLower)
                               || x.VehicleType.ToLower().Contains(searchTermToLower)
                               || x.MaxWeightCapacity.ToString().Contains(searchTermToLower)
                               || x.Volume.ToString().Contains(searchTermToLower)
                               || x.VehicleStatus.ToLower().Contains(searchTermToLower)
                               || x.ContantsExpenses == decimal.Parse(searchTerm)
                               || x.FuelConsumptionPer100Km == double.Parse(searchTerm)
                               || x.EmissionFactor == double.Parse(searchTerm)
                               || x.Length.ToString().Contains(searchTerm)
                               || x.Width.ToString().Contains(searchTerm)
                               || x.Height.ToString().Contains(searchTerm));

                var vehicles = await query.ToListAsync();

                return vehicles.Select(x => new VehicleDetailsViewModel
                {
                    Id = x.Id,
                    RegistrationNumber = x.RegistrationNumber,
                    VehicleType = x.VehicleType,
                    MaxWeightCapacity = x.MaxWeightCapacity.ToString(),
                    Length = x.Length.ToString(),
                    Width = x.Width.ToString(),
                    Height = x.Height.ToString(),
                    Volume = x.Volume.ToString(),
                    IsRefrigerated = x.IsRefrigerated,
                    VehicleStatus = x.VehicleStatus,
                    EmisionFactor = x.EmissionFactor.ToString(),
                    FuelConsumptionPer100Km = x.FuelConsumptionPer100Km.ToString(),
                }).ToList();
            }
            return new List<VehicleDetailsViewModel>();
        }

        public async Task<bool> VehicleWithRegistrationNumberExistsAsync(int id)
        {
            return await repository.AllReadonly<Vehicle>().AnyAsync(x => x.Id == id);
        }

        public async Task AddVehicleAsync(AddVehicleViewModel model)
        {
            var vehicle = new Vehicle
            {
                RegistrationNumber = model.RegistrationNumber,
                VehicleType = model.VehicleType,
                Length = model.Length,
                Width = model.Width,
                Height = model.Height,
                Volume = model.Length * model.Width * model.Height,
                EuroPalletCapacity = model.EuroPalletCapacity,
                IndustrialPalletCapacity = model.IndustrialPalletCapacity,
                ArePalletsStackable = model.ArePalletsStackable,
                MaxWeightCapacity = model.MaxWeightCapacity,
                VehicleStatus = VehicleStatusConstants.Available,
                EmissionFactor = model.EmissionFactor,
                FuelConsumptionPer100Km = model.FuelConsumptionPer100Km,
                LastYearMaintenance = model.LastYearMaintenance,
                KilometersDriven = model.KilometersDriven,
                KilometersToChangeParts = model.KilometersToChangeParts,
                KilometersLeftToChangeParts = 0,
                PurchasePrice = model.PurchasePrice,
                ContantsExpenses = model.ContantsExpenses,
                IsRefrigerated = model.IsRefrigerated,
            };

            await repository.AddAsync(vehicle);
            await repository.SaveChangesAsync();
            var pricesPerSize = new PricesPerSize
            {
                VehicleId = vehicle.Id,
                QuotientForDomesticNotSharedTruck = model.QuotientForDomesticNotSharedTruck,
                QuotientForDomesticSharedTruck = model.QuotientForDomesticSharedTruck,
                QuotientForInternationalNotSharedTruck = model.QuotientForInternationalNotSharedTruck,
                QuotientForInternationalSharedTruck = model.QuotientForInternationalSharedTruck,
            };
            await repository.AddAsync(pricesPerSize);
            await repository.SaveChangesAsync();
        }

        public async Task<AddVehicleViewModel?> GetVehicleForEditAsync(int id)
        {
            return await repository.AllReadonly<Vehicle>().Where(x => x.Id == id).Select(x => new AddVehicleViewModel
            {
                RegistrationNumber = x.RegistrationNumber,
                VehicleType = x.VehicleType,
                Length = x.Length,
                Width = x.Width,
                Height = x.Height,
                EuroPalletCapacity = x.EuroPalletCapacity,
                IndustrialPalletCapacity = x.IndustrialPalletCapacity,
                ArePalletsStackable = x.ArePalletsStackable,
                MaxWeightCapacity = x.MaxWeightCapacity,
                EmissionFactor = x.EmissionFactor,
                FuelConsumptionPer100Km = x.FuelConsumptionPer100Km,
                LastYearMaintenance = x.LastYearMaintenance,
                KilometersDriven = x.KilometersDriven,
                KilometersToChangeParts = x.KilometersToChangeParts,
                PurchasePrice = x.PurchasePrice,
                ContantsExpenses = x.ContantsExpenses
            }).SingleOrDefaultAsync();
        }

        public async Task EditVehicleAsync(int id, AddVehicleViewModel model)
        {
            var vehicle = await repository.All<Vehicle>().FirstOrDefaultAsync(x => x.Id == id);
            vehicle.RegistrationNumber = model.RegistrationNumber;
            vehicle.VehicleType = model.VehicleType;
            vehicle.Length = model.Length;
            vehicle.Width = model.Width;
            vehicle.Height = model.Height;
            vehicle.Volume = model.Length * model.Width * model.Height;
            vehicle.EuroPalletCapacity = model.EuroPalletCapacity;
            vehicle.IndustrialPalletCapacity = model.IndustrialPalletCapacity;
            vehicle.ArePalletsStackable = model.ArePalletsStackable;
            vehicle.MaxWeightCapacity = model.MaxWeightCapacity;
            vehicle.EmissionFactor = model.EmissionFactor;
            vehicle.FuelConsumptionPer100Km = model.FuelConsumptionPer100Km;
            vehicle.LastYearMaintenance = model.LastYearMaintenance;
            vehicle.KilometersDriven = model.KilometersDriven;
            vehicle.KilometersToChangeParts = model.KilometersToChangeParts;
            vehicle.PurchasePrice = model.PurchasePrice;
            vehicle.ContantsExpenses = model.ContantsExpenses;
            vehicle.IsRefrigerated = model.VehicleType == VehicleTypesConstants.Refrigerated ? true : false;

            await repository.SaveChangesAsync();
        }

        public async Task<ChangeQuotientsForVehicleViewModel?> GetQuotientsForVehicleAsync(int id)
        {
            return await repository.AllReadonly<PricesPerSize>().Where(x => x.VehicleId == id).Select(x => new ChangeQuotientsForVehicleViewModel
            {
                QuotientForDomesticNotSharedTruck = x.QuotientForDomesticNotSharedTruck,
                QuotientForDomesticSharedTruck = x.QuotientForDomesticSharedTruck,
                QuotientForInternationalNotSharedTruck = x.QuotientForInternationalNotSharedTruck,
                QuotientForInternationalSharedTruck = x.QuotientForInternationalSharedTruck,
            }).FirstOrDefaultAsync();
        }

        public async Task ChageQuotientsForVehicleAsync(int id, ChangeQuotientsForVehicleViewModel model)
        {
            var pricesPerSize = await repository.All<PricesPerSize>().FirstOrDefaultAsync(x => x.VehicleId == id);
            pricesPerSize.QuotientForDomesticNotSharedTruck = model.QuotientForDomesticNotSharedTruck;
            pricesPerSize.QuotientForDomesticSharedTruck = model.QuotientForDomesticSharedTruck;
            pricesPerSize.QuotientForInternationalNotSharedTruck = model.QuotientForInternationalNotSharedTruck;
            pricesPerSize.QuotientForInternationalSharedTruck = model.QuotientForInternationalSharedTruck;
            await repository.SaveChangesAsync();
        }      
    }
}
