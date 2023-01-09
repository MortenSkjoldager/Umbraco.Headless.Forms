using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Forms.Core.Providers;
using Umbraco.Forms.Core.Services;

namespace Forms.Headless.Api
{
    public class CustomFormsController : UmbracoApiController
    {
        private readonly IFormService _formService;
        private readonly FieldCollection _fieldCollection;
        private readonly IFieldService _fieldService;

        public CustomFormsController(IFormService formService, FieldCollection fieldCollection)
        {
            _formService = formService;
            _fieldCollection = fieldCollection;
        }

        [HttpPost]
        public ActionResult PostForm(CustomForm form)
        {
            return Ok();
        }

        public CustomForm Get ([FromQuery] string formName)
        {
            var fields = _fieldCollection.ToList();

            if (formName == null)
                throw new NullReferenceException(nameof(formName));

            var form = _formService.Get("Simple form");

            if (form == null)
                throw new NullReferenceException($"Form with name: '{formName}' could not be found.");
            
            var customForm = new CustomForm();
            customForm.Name = formName;

            customForm.FormFields = new List<CustomFormField>();
            
            foreach (var field in form.AllFields)
            {
                var metaField = fields.First(x => x.Id == field.FieldTypeId);
                
                customForm.FormFields.Add(new CustomFormField()
                {
                    Alias = metaField.Alias,
                    FieldAlias = field.Alias,
                    Caption = field.Caption,
                    Title = field.ToolTip,
                    PreValues = field.PreValues?.Select(x => new CustomPreValue()
                    {
                        Caption = x.Caption,
                        Value = x.Value
                    }).ToList(),
                    Value = string.Empty
                });
            }
            
            return customForm;
        }
    }
}
