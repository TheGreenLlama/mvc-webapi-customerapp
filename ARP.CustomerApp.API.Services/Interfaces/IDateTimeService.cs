using System;

namespace ARP.CustomerApp.API.Services.Interfaces
{
    public interface IDateTimeService
    {
        DateTime CurrentDateTime { get; }
    }
}