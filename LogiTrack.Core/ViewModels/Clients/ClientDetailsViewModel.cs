﻿using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class ClientDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string AlternativePhoneNumber { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public int DeliveriesLastMonth { get; set; }
        public int NotOnTimeDeliveries { get; set; }
        public int NotPaidDeliveries { get; set; }
        public int TotalDeliveries { get; set; }
        public decimal TotalProfit { get; set; }
        public decimal TotalSatisfactionDeliveries { get; set; }
        public decimal TotalRequests { get; set; }
        public double AverageResponseTimeForRequests { get; set; }
        public double AverageWeightForRequests { get; set; }
        public double AverageVolumeForRequests { get; set; }
        public double AveragePriceForRequests { get; set; }
        public int OverdueInvoices { get; set; }
        public List<DeliveryForClientsDeliveriesViewModel> Deliveries { get; set; } = new List<DeliveryForClientsDeliveriesViewModel>();
    }
}
