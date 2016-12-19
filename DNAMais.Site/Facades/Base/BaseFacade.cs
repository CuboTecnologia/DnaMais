using DNAMais.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DNAMais.Site.Facades.Base
{
    public class BaseFacade
    {
        protected ModelStateDictionary modelState;

        public BaseFacade(ModelStateDictionary modelState)
        {
            this.modelState = modelState;
        }

        protected void FillModelState(ResultValidation result)
        {
            if (!result.Ok)
            {
                modelState.AddModelError(
                    "",
                    result.Message);

                foreach (ResultValidationField campo in result.Fields)
                {
                    modelState.AddModelError(
                        campo.Field,
                        campo.Message);
                }
            }
        }
    }
}