using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallengeUsers.Helpers
{
   public static class GlobalHelper
    {    
        public static long GenerateID()
        {
            long id = 1;
            return id++;
        }
    }
}
