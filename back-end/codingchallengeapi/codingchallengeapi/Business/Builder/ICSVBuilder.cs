using System.Collections.Generic;
using System.IO;

namespace codingchallengeapi.Business.Builder
{
    public interface ICSVBuilder<T> where T: class
    {
        IList<T> Build(Stream stream);
    }
}
