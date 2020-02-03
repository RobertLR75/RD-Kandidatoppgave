using System;
using Repository.Abstractions;

namespace Service.Abstractions
{
    public interface IPersonService
    {
        IPerson Get(int id);
    }
}
