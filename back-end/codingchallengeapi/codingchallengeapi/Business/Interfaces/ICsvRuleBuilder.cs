using codingchallengeapi.Data.Models;
using System.Collections.Generic;
using System.IO;

namespace codingchallengeapi.Business.Interfaces
{
   public interface ICSVRuleBuilder
    {
        IList<VehicleSalesData> VehicleSalesDataRule(Stream stream);
    }
}
