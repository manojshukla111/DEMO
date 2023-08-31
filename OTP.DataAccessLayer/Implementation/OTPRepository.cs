using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using OTP.DataAccessLayer.Interface;
using OTP.Model.Entity;

namespace OTP.DataAccessLayer.Implementation
{
    internal class OTPRepository : Repository<OTPMaster>, IOTPRepository
    {
        private readonly NpgSqlDBContext _db;

        public OTPRepository(NpgSqlDBContext db) : base(db)
        {
            _db = db;
        }
    }

}





