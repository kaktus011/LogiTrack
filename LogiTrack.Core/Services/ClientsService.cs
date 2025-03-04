﻿using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Invoice;
using LogiTrack.Core.ViewModels.Offer;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IRepository repository;

        public ClientsService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> CompanyWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().AnyAsync(x => x.Id == id);
        }

        public async Task<CompanyDetailsViewModel?> GetCompanyDetailsAsync(string username)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>()
                 .Include(x => x.Address)
                 .Where(x => x.User.UserName == username)
                 .Select(x => new CompanyDetailsViewModel
                 {
                     Name = x.Name,
                     RegistrationNumber = x.RegistrationNumber,
                     Industry = x.Industry,
                     Street = x.Address.Street,
                     City = x.Address.City,
                     PostalCode = x.Address.PostalCode,
                     Country = x.Address.County,
                     CreatedAt = x.CreatedAt.ToString("dd-MM-yyyy"),                     
                 })
                 .SingleOrDefaultAsync();
        }

        public async Task<List<PendingRegistrationsViewModel>?> GetPendingRegistrationsAsync()
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>()
                .Where(x => x.RegistrationStatus == StatusConstants.Pending)
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new PendingRegistrationsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    RegistrationNumber = x.RegistrationNumber,
                    PhoneNumber = x.User.PhoneNumber,
                    CreatedAt = x.CreatedAt.ToString("dd-MM-yyyy"),
                    Email = x.User.Email
                })
                .ToListAsync();
        }
       
        public async Task RejectPendingRegistrationForCompanyWithIdAsync(int id)
        {
            var company = await repository.All<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.Id == id);
            company.RegistrationStatus = StatusConstants.Rejected;
            await repository.SaveChangesAsync();
        }        

        public async Task<ContactDetailsViewModel?> GetCompanyContactDetailsAsync(string username)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>()
                 .Where(x => x.User.UserName == username)
                 .Select(x => new ContactDetailsViewModel
                 {
                     Id = x.Id,
                     Username = x.User.UserName,
                     ContactPerson = x.ContactPerson,
                     AlternativePhoneNumber = x.AlternativePhoneNumber,
                     PhoneNumber = x.User.PhoneNumber,
                     Email = x.User.Email
                 })
                 .SingleOrDefaultAsync();
        }       

        public async Task<NewCompanyDetailsForLogisticsViewModel?> GetNewCompanyDetailsForLogisticsAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>()
                .Include(x => x.Address)
                .Where(x => x.Id == id)
                .Select(x => new NewCompanyDetailsForLogisticsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    RegistrationNumber = x.RegistrationNumber,
                    Email = x.User.Email,
                    AlternativePhoneNumber = x.AlternativePhoneNumber,
                    ContactPerson = x.ContactPerson,
                    PhoneNumber = x.User.PhoneNumber,
                    Industry = x.Industry,
                    Street = x.Address.Street,
                    City = x.Address.City,
                    PostalCode = x.Address.PostalCode,
                    Country = x.Address.County,
                    CreatedAt = x.CreatedAt.ToString("dd-MM-yyyy"),
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<ClientsForClientregisterViewModel>> GetClientsForClientsRegisterAsync(bool? active, string? name = null, string? email = null, string? registrationNumber = null, string? phoneNumber = null)
        {
            var query = repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().Where(x => x.RegistrationStatus == StatusConstants.Approved)
                .Include(x => x.Address).Include(x => x.User).AsQueryable();

            if (active == true)
            {
                var deliveriesForClientsIds = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().OrderByDescending(x => x.Offer.FinalPrice).Select(x => x.Offer.Request.ClientCompanyId).Take(10).ToListAsync();
                query = query.Where(x => deliveriesForClientsIds.Contains(x.Id));
            }
            if(string.IsNullOrEmpty(phoneNumber) == false)
            {
                query = query.Where(x => x.User.PhoneNumber.Contains(phoneNumber));
            }
            if (string.IsNullOrEmpty(name) == false)
            {
                query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }
            if (string.IsNullOrEmpty(email) == false)
            {
                query = query.Where(x => x.User.Email.ToLower().Contains(email.ToLower()));
            }
            if (string.IsNullOrEmpty(registrationNumber) == false)
            {
                query = query.Where(x => x.RegistrationNumber.ToLower() == (registrationNumber.ToLower()));
            }
            
            var clients = await query.ToListAsync();

            return clients.Select(x => new ClientsForClientregisterViewModel
            {
                Id = x.Id,
                Name = x.Name,
                RegisterNumber = x.RegistrationNumber,
                Address = $"{x.Address.Street}, {x.Address.City}, {x.Address.County}",
                Email = x.User.Email != null ? x.User.Email : string.Empty,
                Phone = x.User != null ? x.User.PhoneNumber : string.Empty
            }).ToList();
        }

        public async Task<List<ClientsForClientregisterViewModel>> GetClientsForClientsRegisterBySearchTermAsync(string? searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                var clients = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().Include(x => x.Address).Include(x => x.User).ToListAsync();
                clients = clients.Where(x => x.RegistrationNumber.ToLower().Contains(searchTerm.ToLower())
                || x.Name.ToLower().Contains(searchTerm.ToLower())
                || x.Address.City.ToLower().Contains(searchTerm.ToLower())
                || x.Address.County.ToLower().Contains(searchTerm.ToLower())
                || x.Address.Street.ToLower().Contains(searchTerm.ToLower())
                || x.Address.PostalCode.ToLower().Contains(searchTerm.ToLower())
                || x.AlternativePhoneNumber.Contains(searchTerm)
                || x.User.Email.ToLower().Contains(searchTerm.ToLower())
                || x.User.PhoneNumber.ToLower().Contains(searchTerm.ToLower())
                || x.User.UserName.ToLower().Contains(searchTerm.ToLower())).ToList();

                return clients.Select(x => new ClientsForClientregisterViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    RegisterNumber = x.RegistrationNumber,
                    Address = $"{x.Address.Street}, {x.Address.City}, {x.Address.County}",
                    Email = x.User.Email,
                    Phone = x.User != null ? x.User.PhoneNumber : string.Empty
                }).ToList();
            }
            return new List<ClientsForClientregisterViewModel>();
        }

        public async Task<ClientDetailsViewModel?> GetClientDetailsAsync(int id)
        {
            var company = await repository.AllReadonly<ClientCompany>()
                .Include(x => x.Address)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (company == null)
            {
                throw new InvalidOperationException($"Client company with ID {id} not found.");
            }

            var user = await repository.AllReadonly<IdentityUser>()
                .FirstOrDefaultAsync(x => x.Id == company.UserId);

            if (user == null)
            {
                throw new InvalidOperationException($"User associated with the client company not found.");
            }

            var model = new ClientDetailsViewModel
            {
                Id = company.Id,
                Name = company.Name,
                RegistrationNumber = company.RegistrationNumber,
                Industry = company.Industry,
                Street = company.Address?.Street ?? "N/A",
                City = company.Address?.City ?? "N/A",
                PostalCode = company.Address?.PostalCode ?? "N/A",
                Country = company.Address?.County ?? "N/A",
                ContactPerson = company.ContactPerson ?? "N/A",
                PhoneNumber = user.PhoneNumber ?? "N/A",
                AlternativePhoneNumber = company.AlternativePhoneNumber ?? "N/A",
                Email = user.Email ?? "N/A",
                Username = user.UserName ?? "N/A",
                TotalDeliveries = await repository.AllReadonly<Delivery>()
                    .Where(x => x.Offer.Request.ClientCompanyId == company.Id)
                    .CountAsync(),
                TotalProfit = await repository.AllReadonly<Delivery>()
                    .Where(x => x.Offer.Request.ClientCompanyId == company.Id)
                    .SumAsync(x => (decimal?)x.Profit) ?? 0,
                TotalRequests = await repository.AllReadonly<Request>()
                    .Where(x => x.ClientCompanyId == company.Id)
                    .CountAsync(),
                TotalSatisfactionDeliveries = await repository.AllReadonly<Rating>()
                    .Where(x => x.Delivery.Offer.Request.ClientCompanyId == company.Id)
                    .CountAsync(),
                CreatedAt = company.CreatedAt.ToString("dd-MM-yyyy"),
                DeliveriesLastMonth = await repository.AllReadonly<Delivery>()
                    .Where(x => x.Offer.Request.ClientCompanyId == company.Id &&
                                x.Offer.Request.CreatedAt.Month == DateTime.Now.AddMonths(-1).Month)
                    .CountAsync(),
                NotOnTimeDeliveries = await repository.AllReadonly<Delivery>()
                    .Where(x => x.Offer.Request.ClientCompanyId == company.Id &&
                                x.ActualDeliveryDate.HasValue &&
                                x.ActualDeliveryDate > x.Offer.Request.ExpectedDeliveryDate)
                    .CountAsync(),
                NotPaidDeliveries = await repository.AllReadonly<Delivery>()
                    .Where(x => x.Offer.Request.ClientCompanyId == company.Id &&
                                x.Invoice != null &&
                                x.Invoice.IsPaid == false)
                    .CountAsync(),
            };

            model.Deliveries = await repository.AllReadonly<Delivery>()
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .Where(x => x.Offer.Request.ClientCompanyId == company.Id)
                .Select(x => new DeliveryForClientsDeliveriesViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.ReferenceNumber,
                    DeliveryAddress = x.Offer.Request.DeliveryAddress != null
                        ? $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}"
                        : "N/A",
                    PickupAddress = x.Offer.Request.PickupAddress != null
                        ? $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}"
                        : "N/A",
                    ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    FinalPrice = x.Offer.FinalPrice.ToString("F2") ?? "0",
                    IsDelivered = x.DeliveryStep == 4,
                    TotalWeight = x.Offer.Request.TotalWeight.ToString(),
                    TotalVolume = x.Offer.Request.TotalVolume.ToString(),
                    TotalItems = x.Offer.Request.StandartCargo != null
                        ? x.Offer.Request.StandartCargo.NumberOfPallets.ToString()
                        : x.Offer.Request.NumberOfNonStandartGoods.ToString() ?? "0",
                    ActualDeliveryDate = x.ActualDeliveryDate.Value.ToString("dd-MM-yyyy") ?? "N/A",
                })
                .ToListAsync();

            return model;
        }

        public async Task<int> GetCompanyIdByRegistrationNumberAsync(string registrationNumber)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().Where(x => x.RegistrationNumber == registrationNumber).Select(x => x.Id).FirstOrDefaultAsync();
        }
    }   
}