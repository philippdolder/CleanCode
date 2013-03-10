namespace Bbv.CleanCodeWorkshop.Overloads
{
    using FluentAssertions;
    using NUnit.Framework;

    // TODO: Remove the overload with the signature 'AddPosition(string articleNumber, int amount, string size)' as it is never used
    // TODO: Refactor the 'Order' class in a way that you have to change the minimum possible amount of code when you remove another overload in the future
    [TestFixture]
    public class OrderTest
    {
        private Order testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new Order();
        }

        [Test]
        public void AddsPositionToOrder()
        {
            const string ArticleNumber = "A12B";
            const int Amount = 2;
            const string Size = "Large";
            const string Color = "White";

            this.testee.AddPosition(ArticleNumber, Amount, Size, Color);

            this.testee.Positions.Should().Contain(x =>
                x.ArticleNumber == ArticleNumber
                && x.Amount == Amount
                && x.Size == Size
                && x.Color == Color);
        }

        [Test]
        public void AddsPositionToOrderWithAmountOfOne_WhenAmountIsNotSpecified()
        {
            const string ArticleNumber = "A12B";

            this.testee.AddPosition(ArticleNumber);

            this.testee.Positions.Should().Contain(x => 
                x.ArticleNumber == ArticleNumber
                && x.Amount == 1);
        }

        [Test]
        public void AddsPositionToOrderWithAmountAndNoSize_WhenSizeIsNotSpecified()
        {
            const string ArticleNumber = "A12B";
            const int Amount = 3;

            this.testee.AddPosition(ArticleNumber, Amount);

            this.testee.Positions.Should().Contain(x =>
                x.ArticleNumber == ArticleNumber
                && x.Amount == Amount
                && x.Size == string.Empty);
        }
    }
}