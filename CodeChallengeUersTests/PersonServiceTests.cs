using AutoFixture;
using CodeChallengeUsers.Domain;
using CodeChallengeUsers.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallengeUsersTests
{
    [TestClass]
    public class PersonServiceTests
    {
        private readonly Fixture _fixture = new Fixture();
        [TestMethod]
        public void GetUniqueEmails_BothList_HaveValues_OneMatch_Found_Success()
        {
            var originalList = _fixture.Build<Person>().CreateMany().ToList();
            originalList.Add(new Person()
               {
                   FirstName = "Abraham",
                   LastName = "Lincoln",
                   Email = "Test@email.com"
               }
               );
            var newList = _fixture.Build<Person>().CreateMany().ToList();
            newList.Add(new Person()
                 {
                     FirstName = "Abraham",
                     LastName = "Lincoln",
                     Email = "NewerTest@email.com"
                 }
               );


            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmail(originalList, newList);
            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.First() == "NewerTest@email.com");
        }

        [TestMethod]
        public void GetUniqueEmails_BothList_HaveValues_NoMatch_Found_Success()
        {
            var originalList = _fixture.Build<Person>().
                 CreateMany();
            var newList = _fixture.Build<Person>().
                CreateMany();

            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmail(originalList, newList);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetUniqueEmails_NewList_Null_HaveValues_Success()
        {
            var newList = _fixture.Build<Person>().
                  CreateMany();
            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmail(null, newList);

            Assert.IsNull(result);

        }

        [TestMethod]
        public void GetUniqueEmails_OriginalList_Null_HaveValues_Success()
        {
            var originalList = _fixture.Build<Person>().
                    CreateMany();
            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmail(originalList, null);

            Assert.IsNull(result);

        }

        [TestMethod]
        public void GetUniqueEmails_NewList_Empty_HaveValues_Success()
        {
            var originalList = _fixture.Build<Person>().
                  CreateMany();
            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmail(originalList, new List<Person>());

            Assert.IsNull(result);

        }

        [TestMethod]
        public void GetUniqueEmails_OriginalList_Empty_HaveValues_Success()
        {
            var newList = _fixture.Build<Person>().
                    CreateMany();
            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmail(new List<Person>(), newList);

            Assert.IsNull(result);

        }

        [TestMethod]
        public void GetMatchingUserNewEmailUsingHashset_BothList_HaveValues_OneMatch_Found_Success()
        {
            var originalList = _fixture.Build<Person>().CreateMany().ToList();
            originalList.Add(new Person()
            {
                FirstName = "Abraham",
                LastName = "Lincoln",
                Email = "Test@email.com"
            }
               );
            var newList = _fixture.Build<Person>().CreateMany().ToList();
            newList.Add(new Person()
            {
                FirstName = "Abraham",
                LastName = "Lincoln",
                Email = "NewerTest@email.com"
            }
               );


            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmail(originalList, newList);
            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.First() == "NewerTest@email.com");
        }

        [TestMethod]
        public void GetMatchingUserNewEmailUsingHashset_BothList_HaveValues_NoMatch_Found_Success()
        {
            var originalList = _fixture.Build<Person>().
                 CreateMany();
            var newList = _fixture.Build<Person>().
                CreateMany();

            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmailUsingHashset(originalList, newList);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetMatchingUserNewEmailUsingHashset_NewList_Null_HaveValues_Success()
        {
            var newList = _fixture.Build<Person>().
                  CreateMany();
            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmailUsingHashset(null, newList);

            Assert.IsNull(result);

        }

        [TestMethod]
        public void GetMatchingUserNewEmailUsingHashset_OriginalList_Null_HaveValues_Success()
        {
            var originalList = _fixture.Build<Person>().
                    CreateMany();
            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmailUsingHashset(originalList, null);

            Assert.IsNull(result);

        }

        [TestMethod]
        public void GetMatchingUserNewEmailUsingHashset_NewList_Empty_HaveValues_Success()
        {
            var originalList = _fixture.Build<Person>().
                  CreateMany();
            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmailUsingHashset(originalList, new List<Person>());

            Assert.IsNull(result);

        }

        [TestMethod]
        public void GetMatchingUserNewEmailUsingHashset_OriginalList_Empty_HaveValues_Success()
        {
            var newList = _fixture.Build<Person>().
                    CreateMany();
            var personService = new PersonService();
            var result = personService.GetMatchingUserNewEmailUsingHashset(new List<Person>(), newList);

            Assert.IsNull(result);

        }
    }
}
