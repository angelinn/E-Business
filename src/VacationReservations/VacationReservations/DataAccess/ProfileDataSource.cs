using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VacationReservations.Common;

namespace VacationReservations.DataAccess
{
    public class ProfileDataSource
    {
        public ProfileDataSource()
        {
        }
        public List<ProfileWrapper> GetData()
        {
            List<ProfileWrapper> data = new List<ProfileWrapper>();
            data.Add(new ProfileWrapper());
            return data;
        }
        public void UpdateData(ProfileWrapper newData)
        {
            newData.UpdateProfile();
        }
    }
}