using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willow.Core.Domain.Entities;
using Willow.Samples.Core.Domain.People.Events;
using Willow.Samples.Core.Domain.People.ValueObjects;

namespace Willow.Samples.Core.Domain.People.Entities
{
    public class Person : AggregateRoot
    {
        #region Properties
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        #endregion

        public Person(FirstName firstName, LastName lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AddEvent(new PersonCreated(BusinessId.Value, firstName.Value, lastName.Value));
        }
    }
}
