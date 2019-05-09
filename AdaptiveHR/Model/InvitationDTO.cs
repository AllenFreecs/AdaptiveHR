using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class InvitationDTO
    {
	   public int Id { get; set; }
       public DateTime? Date { get; set; }
public string LastName { get; set; }
public string FirstName { get; set; }
public string MiddleName { get; set; }
public string Phonenumber { get; set; }
public string Email { get; set; }
public bool SendEmail { get; set; }
public bool SendSMS { get; set; }
public bool Confirmed { get; set; }

    }
}
