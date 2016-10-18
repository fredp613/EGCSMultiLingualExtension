using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Helpers
{
    public class UserLocaleHelper
    {
        int userLanguageId = 0;
        IOrganizationService _service;
        IPluginExecutionContext _context;

        public UserLocaleHelper(IOrganizationService param_service, IPluginExecutionContext param_context)
        {
            _service = param_service;
            _context = param_context;

        }
        public int getUserLanguage()
        {
            if (_context.SharedVariables.ContainsKey("UserLocaleId"))
            {
                userLanguageId = (int)_context.SharedVariables["UserLocaleId"];
            }
            else
            {
                Entity userLanguage = _service.Retrieve("usersettings", _context.InitiatingUserId, new ColumnSet("uilanguageid"));
                userLanguageId = userLanguage.GetAttributeValue<int>("uilanguageid");
            }
            return userLanguageId;
        }
    }
}
