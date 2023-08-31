using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTP.DataAccessLayer.Interface
{
    public interface IUnitOfWork
    {
        IOTPRepository OTPRepository { get; }
        Task save();
    }
}
