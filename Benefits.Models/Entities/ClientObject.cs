﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benefits.Models.Entities;

namespace Benefits.DAL.Entities
{
    public class ClientObject : BaseEntity
    {
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int? GymId { get; set; }
        public int? RestaurantId { get; set; }
    }
}