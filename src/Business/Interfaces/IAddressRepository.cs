using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAddressRepository: IRepository<Address>
    {
        Task<Address> GetAddressByProvider(Guid providerId);
    }
}
