using Donate.Domain;
using System.Collections.Generic;

namespace Donate.Services
{
    public interface IDonateService
    {
        #region Donate
        DonorInfo AddDonorInfo(DonorInfo mod);
        bool DeleteDonorInfo(int id);
        List<DonorInfo> GetAllDonorsInfo();
        DonorInfo GetDonorInfoById(int id);
        #endregion

    }
}
