using Donate.Data;
using Donate.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Donate.Services
{
    public class DonateService : IDonateService
    {
        #region Variables, Ctor

        private readonly DonateContext _context;
        public DonateService()
        {
            _context = new DonateContext();
        }
        #endregion

        #region Donate

        public DonorInfo AddDonorInfo(DonorInfo mod)
        {
            try
            {
                if (mod.Id == 0)
                {
                    _context.DonorInfo.Add(mod);
                }
                else
                {
                    _context.Entry(mod).State = EntityState.Modified;
                    _context.Set<DonorInfo>().Attach(mod);
                }
                _context.SaveChanges(); 
            }
            catch (Exception ex)
            {
                mod.HasError = true;
                mod.AddErrorMessage(ex.Message);   
           }
            return mod;
        }

        public bool DeleteDonorInfo(int id)
        {
            bool flag = false;
            try
            {
                var donor = _context.DonorInfo.Find(id);

                if(donor != null)
                {       
                    foreach (DonationDetails item in donor.DonationDetails.ToList())
                    {
                        _context.DonationDetails.Remove(item);
                    }
                    _context.DonorInfo.Remove(donor);
                    _context.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }

        public List<DonorInfo> GetAllDonorsInfo()
        {
            List<DonorInfo> mod = new List<DonorInfo>();
            try
            {
                mod = _context.DonorInfo.Include(a => a.DonationDetails).ToList();
                return mod;
            }
            catch (Exception ex)
            {
                mod = null;
            }
            return mod;
        }

        public DonorInfo GetDonorInfoById(int id)
        {
            DonorInfo mod = new DonorInfo();
            try
            {
                //mod = _context.DonorInfo.Find(id);
                mod = _context.DonorInfo.Include(a => a.DonationDetails).Where(a => a.Id == id).FirstOrDefault();
                _context.Entry(mod).State = EntityState.Detached;
                return mod;
            }
            catch (Exception ex)
            {
                mod = null;
                mod.AddErrorMessage(ex.Message);
            }
            return mod;
        }

        #endregion
        
    }
}
