using System.Web.Mvc;

namespace DNAMais.BackOffice.Areas.Newsletter
{
    public class NewsletterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Newsletter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Newsletter_default",
                "Newsletter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
