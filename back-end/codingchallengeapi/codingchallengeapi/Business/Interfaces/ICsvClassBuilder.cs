using codingchallengeapi.Data.Models;

namespace codingchallengeapi.Business.Interfaces
{
    interface ICsvClassBuilder
    {
        VehicleSalesData FromCsv(string csvLine);
    }
}
