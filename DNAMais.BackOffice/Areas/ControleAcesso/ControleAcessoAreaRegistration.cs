using System.Web.Mvc;

namespace DNAMais.BackOffice.Areas.ControleAcesso
{
    public class ControleAcessoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ControleAcesso";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ControleAcesso_default",
                "ControleAcesso/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
