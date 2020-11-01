using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallengeUsers.Helpers
{
   public static class GlobalHelper
    {
        private static long id = 1;
        public static long GenerateID()
        {
            return id++;
        }
    }
}
