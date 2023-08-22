using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpot_Sharp.CRM.Associations.Schema
{
    public enum CompanyAssociationType
    {
        CompanyToContact = 280,
        CompanyToPrimaryContact = 2,
        CompanyToDeal = 342,
        CompanyToPrimaryDeal = 6,
        CompanyToTicket = 340,
        CompanyToPrimaryTicket = 25,
        CompanyToCall = 181,
        CompanyToEmail = 185,
        CompanyToMeeting = 187,
        CompanyToNote = 189,
        CompanyToTask = 191,
        CompanyToCommunication = 88,
        CompanyToPostalMail = 460
    }
}
