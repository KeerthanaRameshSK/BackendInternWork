﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using EntityLayer;

namespace DAL
{
    public interface ITicketstatus
    {
        public TicketstatusModel ShowById(int tckid);
    }
}
