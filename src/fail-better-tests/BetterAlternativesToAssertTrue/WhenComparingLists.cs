using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Fail.Better.BetterAlternativesToAssertTrue
{
    [TestFixture]
    public sealed class WhenComparingLists 
    {
        private readonly IReadOnlyList<string> _albumTitles;

        public WhenComparingLists()
        {
            IRecordStore recordStore = new RecordStore();
            recordStore.Add("Purple Rain");
            recordStore.Add("Around The World In A Day");
            recordStore.Add("Parade");
            _albumTitles = recordStore.GetAlbumTitles().ToList().AsReadOnly();
        }

        [Test]
        public void AlbumList_Example_1()
        {
            Assert.True(_albumTitles.Contains("Purple Train"));
        }

        [Test]
        public void AlbumList_Example_2()
        {
            Assert.That(_albumTitles, Does.Contain("Purple Train"));
        }
        
        [Test]
        public void AlbumList_Example_3()
        {
            Assert.That(_albumTitles, Is.EqualTo(new[]
            {
                "Parade",
                "Purple Rain",
                "Around The World In A Day"
            }));
        }

        [Test]
        public void AlbumList_Example_4()
        {
            Assert.That(_albumTitles, Is.EquivalentTo(new[]
            {
                "Purple Train",
                "Around The World Without Pay",
                "Charade"
            }));
        }
    }
}