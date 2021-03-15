using System;
using System.Collections.Generic;
using System.Text;
using Bronistol.Core.Services.BookingService;
using Bronistol.Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bronistol.Tests.Contexts
{
    public class BookingServiceContext
    {
        public IBookingService BookingService { get; set; }
        public BronistolContext Context { get; set; }

        public BookingServiceContext()
        {
            Context = new BronistolContext();
            BookingService = new BookingService(Context);
        }
    }
}
