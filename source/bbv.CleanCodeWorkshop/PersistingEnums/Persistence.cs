namespace Bbv.CleanCodeWorkshop.PersistingEnums
{
    using System.Collections.Generic;

    public class Persistence
    {
        private readonly Dictionary<string, Person> store;

        public Persistence()
        {
            this.store = new Dictionary<string, Person>();
        }

        public void Save(Person person)
        {
            this.store[person.Name] = person;
        }

        public Person Load(string name)
        {
            return this.store[name];
        }
    }
}