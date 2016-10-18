using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace Helpers
{
    
    public class OptionSetHelper
    {
        public int getIndexOfLabel(string entityName, string field, string labelText, IOrganizationService context)
        {

            int index = -1;
            RetrieveAttributeRequest attributeRequest = new RetrieveAttributeRequest
            {
                EntityLogicalName = entityName,
                LogicalName = field,
                RetrieveAsIfPublished = true
            };
            RetrieveAttributeResponse attributeResponse = (RetrieveAttributeResponse)context.Execute(attributeRequest);
            EnumAttributeMetadata attributeMetadata = (EnumAttributeMetadata)attributeResponse.AttributeMetadata;

            foreach (OptionMetadata om in attributeMetadata.OptionSet.Options)
            {

                if (om.Label.UserLocalizedLabel.Label.ToString() == labelText)
                {
                    if (om.Value != null)
                    {
                        index = om.Value.Value;
                    }
                }
            }

            return index;


        }
        public string getLabelFromField(Entity entity, string field, IOrganizationService context)
        {
            var fieldValue = ((OptionSetValue)entity.Attributes[field]).Value.ToString();
            string fieldLabel = "";
            //need to get Option Set display label based on its value.  This requires getting attribute metadata
            RetrieveAttributeRequest attributeRequest = new RetrieveAttributeRequest
            {
                EntityLogicalName = entity.LogicalName,
                LogicalName = field,
                RetrieveAsIfPublished = true
            };

            RetrieveAttributeResponse attributeResponse = (RetrieveAttributeResponse)context.Execute(attributeRequest);
            EnumAttributeMetadata attributeMetadata = (EnumAttributeMetadata)attributeResponse.AttributeMetadata;

            foreach (OptionMetadata om in attributeMetadata.OptionSet.Options)
            {
                if (om.Value == ((OptionSetValue)entity.Attributes[field]).Value)
                {
                    fieldLabel = om.Label.UserLocalizedLabel.Label.ToString();
                }
            }

            return fieldLabel;
        }
    }
}