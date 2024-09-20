using System.Drawing;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        { }

        [Test]
        public void AllZeros()
        {
            int[] hedgehogs = { 0, 0, 0 };
            int result = Program.GetCountMeeting(hedgehogs, (int)Color.Blue);
            Assert.AreEqual(result, -1);
        }

        [Test]
        public void SuccessValuesBlue()
        {
            int[] hedgehogs = { 4, 7, 4 };
            int result = Program.GetCountMeeting(hedgehogs, (int)Color.Blue);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void NotSuccessValuesGreen()
        {
            int[] hedgehogs = { 2, 4, 3 };
            int result = Program.GetCountMeeting(hedgehogs, (int)Color.Green);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void SuccessValuesForRed()
        {
            int[] hedgehogs = { 3, 2, 5 };
            int result = Program.GetCountMeeting(hedgehogs, (int)Color.Red);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void MaxNotSuccessValues()
        {
            int[] hedgehogs = { Int32.MaxValue, Int32.MaxValue, Int32.MaxValue };
            int result = Program.GetCountMeeting(hedgehogs, (int)Color.Blue);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void OneValue()
        {
            int[] hedgehogs = { 1, 0, 0 };
            int result = Program.GetCountMeeting(hedgehogs, (int)Color.Red);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void OneColorNull()
        {
            int[] hedgehogs = { 3, 0, 2 };
            int result = Program.GetCountMeeting(hedgehogs, (int)Color.Green);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void SameValues()
        {
            int[] hedgehogs = { 2, 2, 2 };
            int result = Program.GetCountMeeting(hedgehogs, (int)Color.Blue);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void NullArray()
        {
            Assert.DoesNotThrow(() => Program.GetCountMeeting(null, (int)Color.Blue));
        }

        [Test]
        public void SuccessMaxValues()
        {
            int[] hedgehogs = new int[3];
            hedgehogs[0] = 0;
            hedgehogs[1] = Int32.MaxValue / 2;
            hedgehogs[2] = Int32.MaxValue / 2;
            int result = Program.GetCountMeeting(hedgehogs, (int)Color.Red);
            Assert.AreEqual(1073741823, result);
        }

        [Test]
        public void BiggerArray()
        {
            int[] hedgehogs = { 2, 2, 2, 2, 2, 2 };
            int result = Program.GetCountMeeting(hedgehogs, (int)Color.Red);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void SmallerArray()
        {
            int[] hedgehogs = { 2, 2};
            int result = Program.GetCountMeeting(hedgehogs, (int)Color.Red);
            Assert.AreEqual(-1, result);
        }
    }
}