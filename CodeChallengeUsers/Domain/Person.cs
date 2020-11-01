using CodeChallengeUsers.Helpers;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallengeUsers.Domain
{
   public class Person
    {
        public long ID  => GlobalHelper.GenerateID();
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
    }

    public sealed class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Map(m => m.FirstName).Name("first");
            Map(m => m.LastName).Name("last");
            Map(m => m.Email).Name("email");
        }
    }
}
