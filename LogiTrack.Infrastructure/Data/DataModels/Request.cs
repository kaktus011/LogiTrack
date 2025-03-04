﻿using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Request;

namespace LogisticsSystem.Infrastructure.Data.DataModels
{
    [Comment("Request Entity")]
    public class Request
    {
        [Key]
        [Comment("Request identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Client Company identifier")]
        public int ClientCompanyId { get; set; }

        [Comment("Client Company of the request")]
        [ForeignKey(nameof(ClientCompanyId))]
        public ClientCompany ClientCompany { get; set; } = null!;

        [Required]
        [Comment("Cargo type")]
        [StringLength(CargoTypeMaxLength)]
        public string CargoType { get; set; } = string.Empty; //standard , not standard


        [Comment("Number of non-standart goods")]
        [Range(NumberOfNonStandartGoodsMinValue, NumberOfNonStandartGoodsMaxValue)]
        public int? NumberOfNonStandartGoods { get; set; }

        [Required]
        [Comment("Type of goods")]
        [StringLength(TypeOfGoodsMaxLength)]
        public string TypeOfGoods { get; set; } = string.Empty;

        [Required]
        [Comment("Type of the request")]
        [StringLength(RequestTypeMaxLength)]
        public string Type { get; set; } = string.Empty; //domestic, international

        [Required]
        [Comment("Pickup address identifier")]
        public int PickupAddressId { get; set; }

        [ForeignKey(nameof(PickupAddressId))]
        public Address PickupAddress { get; set; } = null!;

        [Required]
        [Comment("Delivery address identifier")]
        public int DeliveryAddressId { get; set; }

        [ForeignKey(nameof(DeliveryAddressId))]
        public Address DeliveryAddress { get; set; } = null!;

        [Required]
        [Comment("Will the vehicle be shared or no")]
        public bool SharedTruck { get; set; }

        [Required]
        [Comment("Approximate price given by the company")]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal ApproximatePrice { get; set; } //given by the company

        [Comment("Automatically calculated price")]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal CalculatedPrice { get; set; }

        [Required]
        [Comment("Expected delivery date")]
        public DateTime ExpectedDeliveryDate { get; set; }

        [Comment("Status of the request")]
        [StringLength(RequestStatusMaxLength)]
        public string Status { get; set; } = string.Empty; //pending, accepted, rejected

        [Comment("Special instructions")]
        [StringLength(SpecialInstructionsMaxLength)]
        public string SpecialInstructions { get; set; } = string.Empty;

        [Required]
        [Comment("Is the cargo refrigerated")]
        public bool IsRefrigerated { get; set; }

        [Comment("Offer identifier")]
        public int? OfferId { get; set; }

        [Comment("Offer")]
        [ForeignKey(nameof(OfferId))]
        public Offer? Offer { get; set; }

        [Required]
        [Comment("Date of creation")]
        public DateTime CreatedAt { get; set; }

        [Comment("Kilometers")]
        [Required]
        public double Kilometers { get; set; }

        [Comment("Reference number")]
        [Required]

        public string RerefenceNumber { get; set; } = string.Empty;

        public IEnumerable<NonStandardCargo>? NonStandardCargos { get; set; } = new List<NonStandardCargo>();

        [Comment("Standart cargo identifier")]
        public int? StandartCargoId { get; set; }

        [Comment("Standart cargo")]
        [ForeignKey(nameof(StandartCargoId))]
        public StandartCargo? StandartCargo { get; set; }

        [Comment("Total weight of the cargo")]
        public double TotalWeight { get; set; }

        [Comment("Total volume of the cargo")]
        public double TotalVolume { get; set; }
    }
}
