namespace Bbv.CleanCodeWorkshop.PersistingEnums
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class PersistenceTest
    {
        private Persistence testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new Persistence();
        }

        [Test]
        public void StoresAPerson()
        {
            const string Name = "Clean Coder";
            var person = new Person { Name = Name, Title = Titles.Sir };

            this.testee.Save(person);
            Person loadedPerson = this.testee.Load(Name);

            loadedPerson.ShouldHave().AllProperties().EqualTo(new Person { Name = person.Name, Title = person.Title });
        }
    }
}