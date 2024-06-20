﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.Features.Commands.Category.RemoveCategory
{
    public class RemoveCategoryCommandRequest : IRequest<RemoveCategoryCommandResponse>
    {
        public string Id { get; set; }
    }
}
