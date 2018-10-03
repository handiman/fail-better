using System.Collections.Generic;

namespace Fail.Better
{
    public interface IRecordStore
    {
        void Add(string albumTitle);
        IEnumerable<string> GetAlbumTitles();
    }
}
