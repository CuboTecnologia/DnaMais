using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DNAMais.Site
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Todos os Serviços",
                url: "servicos",
                defaults: new { controller = "Services", action = "AllServices" }
            );

            routes.MapRoute(
                name: "Enriquecimento de Dados",
                url: "servicos/enriquecimento-de-dados",
                defaults: new { controller = "Services", action = "DataEnrichment" }
            );

            routes.MapRoute(
                name: "Tratamento e Higienização de Dados",
                url: "servicos/tratamento-e-higienizacao-de-dados",
                defaults: new { controller = "Services", action = "DataTreatment" }
            );

            routes.MapRoute(
                name: "Atribuição de Documentos",
                url: "servicos/atribuicao-de-documentos",
                defaults: new { controller = "Services", action = "AssigningDocs" }
            );

            routes.MapRoute(
                name: "Mailing Qualificado",
                url: "servicos/mailing-qualificado",
                defaults: new { controller = "Services", action = "QualifiedMailing" }
            );

            routes.MapRoute(
                name: "E-mail Marketing",
                url: "servicos/email-marketing",
                defaults: new { controller = "Services", action = "MailMarketing" }
            );

            routes.MapRoute(
                name: "Sms",
                url: "servicos/sms",
                defaults: new { controller = "Services", action = "Sms" }
            );

            routes.MapRoute(
                name: "Pesquisa CPF e CNPJ",
                url: "servicos/pesquisa-cpf-cnpj",
                defaults: new { controller = "Services", action = "Search" }
            );

            routes.MapRoute(
                name: "Modelos Estatísticos",
                url: "servicos/modelos-estatisticos",
                defaults: new { controller = "Services", action = "StatisticalModels" }
            );

            routes.MapRoute(
                name: "Soluções de Prospecção",
                url: "servicos/analise-de-mercado-expansao-de-negocios",
                defaults: new { controller = "Services", action = "ProspectingSolutions" }
            );

            routes.MapRoute(
                name: "Form",
                url: "contato/proposta",
                defaults: new { controller = "Contact", action = "Propose" }
            );

            routes.MapRoute(
                name: "Location",
                url: "contato/localizacao",
                defaults: new { controller = "Contact", action = "Location" }
            );

            routes.MapRoute(
                name: "BlogList",
                url: "blog",
                defaults: new { controller = "Blog", action = "BlogList" }
            );

            routes.MapRoute(
                name: "BlogPost",
                url: "blog/post",
                defaults: new { controller = "Blog", action = "BlogPost" }
            );

            routes.MapRoute(
                name: "About",
                url: "sobre/quem-somos",
                defaults: new { controller = "About", action = "AboutUs" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}