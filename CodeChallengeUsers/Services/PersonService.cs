using CodeChallengeUsers.Domain;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallengeUsers.Services
{
    public interface IPersonService {

        IEnumerable<Person> GetPeople(string filePath);
        IEnumerable<string> GetMatchingUserNewEmail(IEnumerable<Person> originalList, IEnumerable<Person> newUserList);

    }
    public class PersonService : IPersonService
    {
        public IEnumerable<Person> GetPeople(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<PersonMap>();
                    var records = csv.GetRecords<Person>();
                    return records.ToList();
                }
            }        
        }

        public IEnumerable<string> GetMatchingUserNewEmail(IEnumerable<Person> originalList, IEnumerable<Person> newUserList)
        {
            if (originalList == null || !originalList.Any() || newUserList == null || !newUserList.Any())
            {
                return null;
            }
           return newUserList
                .Where(x => originalList.Any(y => y.FirstName == x.FirstName && y.LastName == x.LastName))
                .Select(x=> x.Email);
        }
    }
}
