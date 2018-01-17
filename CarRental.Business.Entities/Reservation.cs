﻿using Core.Common.Contracts;
using CoreCommon.Core;
using System;
using System.Runtime.Serialization;

namespace CarRental.Business.Entities
{
    [DataContract]
    public class Reservation : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        [DataMember]
        public int ReservationId { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int CarId { get; set; }

        [DataMember]
        public DateTime RentalDate { get; set; }

        [DataMember]
        public DateTime ReturnDate { get; set; }

        public int EntityId
        {
            get { return ReservationId; }
            set { ReservationId = value; }
        }

        int IAccountOwnedEntity.OwnerAccountId
        {
            get { return AccountId; }
        }
    }
}
