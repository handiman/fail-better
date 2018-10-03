using System.Collections.Generic;

namespace Fail.Better
{
    public sealed class RecordStore : IRecordStore
    {
        private readonly IList<string> _albums = new List<string>();

        void IRecordStore.Add(string albumTitle)
        {
            _albums.Add(albumTitle);
        }

        IEnumerable<string> IRecordStore.GetAlbumTitles()
        {
            return _albums;
        }
    }
}