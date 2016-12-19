using System.Web.Mvc;

namespace DNAMais.BackOffice.Areas.ConfiguracoesProduto
{
    public class ConfiguracoesProdutoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ConfiguracoesProduto";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ConfiguracoesProduto_default",
                "ConfiguracoesProduto/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "DNAMais.BackOffice.Areas.ConfiguracoesProduto.Controllers" }
            );
        }
    }
}
