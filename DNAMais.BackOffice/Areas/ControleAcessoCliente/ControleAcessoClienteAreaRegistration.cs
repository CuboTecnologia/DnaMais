using System.Web.Mvc;

namespace DNAMais.BackOffice.Areas.ControleAcessoCliente
{
    public class ControleAcessoClienteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ControleAcessoCliente";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ControleAcessoCliente_default",
                "ControleAcessoCliente/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
