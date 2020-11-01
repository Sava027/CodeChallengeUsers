using CodeChallengeUsers.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodeChallengeUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
               .AddSingleton<IPersonService, PersonService>()
               .BuildServiceProvider();

            try
            {

                string filepath = Environment.CurrentDirectory;
                var personService = serviceProvider.GetService<IPersonService>();
                var originalList = personService.GetPeople(filepath + @"\examples\users.csv");
                var newList = personService.GetPeople(filepath + @"\examples\newusers.csv");

                var emailList = personService.GetMatchingUserNewEmail(originalList, newList);
                if (emailList == null || !emailList.Any())
                {
                    Console.WriteLine("No users matches found in provided list");
                }

                foreach (var email in emailList)
                {
                    Console.WriteLine("Email:" + email);
                }

            }
            catch (Exception ex)
            {
                Console.Write("Error ocurred:" + ex.Message);

            }
        }

    }
}
