using System.Linq;
using NUnit.Framework;

namespace Fail.Better.BetterAlternativesToAssertTrue
{
    [TestFixture]
    public sealed class WhenComparingNumbers
    {
        private readonly int _totalNumberOfRecords;

        public WhenComparingNumbers()
        {
            IRecordStore recordStore = new RecordStore();
            recordStore.Add("Purple Rain");
            _totalNumberOfRecords = recordStore.GetAlbumTitles().Count();
        }

        [Test]
        public void TotalNumberOfRecords_Example_1()
        {
            Assert.True(_totalNumberOfRecords == 2);
        }

        [Test]
        public void TotalNumberOfRecords_Example_2()
        {
            Assert.That(_totalNumberOfRecords, Is.EqualTo(2));
        }
    }
}
