using System.Linq;
using NUnit.Framework;

namespace Fail.Better.BetterAlternativesToAssertTrue
{
    [TestFixture]
    public sealed class WhenComparingStrings
    {
        private readonly string _albumTitle;

        public WhenComparingStrings()
        {
            IRecordStore recordStore = new RecordStore();
            recordStore.Add("Purple Rain");
            _albumTitle = recordStore.GetAlbumTitles().Single();
        }

        [Test]
        public void AlbumTitle_Example_1()
        {
            Assert.True(_albumTitle == "Purple Train");
        }

        [Test]
        public void AlbumTitle_Example_2()
        {
            Assert.That(_albumTitle, Is.EqualTo("Purple Train"));
        }
    }
}