using Xunit;

namespace HR_Management.Application.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, sum(2, 2));
        }
        [Fact]
        public void Test2()
        {
            Assert.Equal(6,sum(2, 4));
        }

        public int sum(int x, int y)
        {
            return x + y;
        }
    }
}