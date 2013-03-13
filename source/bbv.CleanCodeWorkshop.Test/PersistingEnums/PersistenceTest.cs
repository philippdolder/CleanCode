namespace Bbv.CleanCodeWorkshop.PersistingEnums
{
    using FluentAssertions;
    using NUnit.Framework;

    // TODO: Make sure you can easily add a new 'Title' and don't get into trouble when you rename the title (e.g. Ms to Miss) just in your code without affecting
    // existing records in your database (We know it's In-Memory in this code, but use your imagination here and think of it as being a real persistent database with
    // millions of records)
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
            var person = new Person { Name = Name, Title = Title.Sir };

            this.testee.Save(person);
            Person loadedPerson = this.testee.Load(Name);

            loadedPerson.ShouldHave().AllProperties().EqualTo(new Person { Name = person.Name, Title = person.Title });
        }
    }
}