// Created BY ICICI Lombard tech Team.
// This is the copyright of ICICI Lombard .

using DataAccessLayer;
using OTP.DataAccessLayer.Interface;

namespace OTP.DataAccessLayer.Implementation;
public class UnitOfWork : IUnitOfWork
{
    private readonly NpgSqlDBContext _db;

    public UnitOfWork(NpgSqlDBContext db)
    {
        _db = db;
        OTPRepository = new OTPRepository(_db);
    }

    public IOTPRepository OTPRepository { get; private set; }

    public async Task save()
    {
        await _db.SaveChangesAsync().ConfigureAwait(true);
    }
}
