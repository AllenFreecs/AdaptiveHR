using AdaptiveHR.Model;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.SwaggerSamples
{
    public class PDSExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new PDSDTO()
            {
                Id = 0,
                SessionID = "Test session",
                BirthDay = Convert.ToDateTime("08-30-93"),
                CivilStatus = "Single",
                ContactPreviousEmployer = true,
                FirstName = "Allen",
                MiddleName = "Mamato",
                LastName = "Benzon",
                MobileNumber = "09481927707",
                CurrentAddress = "8th Flr., Philppine Company Tower,1554 Mandaluyong City, Metro Manila",
                Email = "testmailer@gmail.com",
                HomeAddress = "Headquarters 1120 N Street Sacramento 916-654-526",
                Gender =  "male",
                ID_Job = 1,
                ID_Education = 1,
                ID_Seminar = 2
            };
        }
    }
}
