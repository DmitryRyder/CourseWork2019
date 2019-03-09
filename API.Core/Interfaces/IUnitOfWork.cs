using System;
using System.Collections.Generic;
using System.Text;
using Common.Models;

namespace API.Core.Interfaces
{
    public interface IUnitOfWork
    {
        void Dispose();
        void Save();
    }
}
