﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Application.Dtos.Tickets
{
    public record UpdateTicketDto(int Id, string Title, string Description, string Status);

}