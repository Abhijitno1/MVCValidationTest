using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCValidationTest.Customizations
{
    public static class XtraHTMLHelpers
    {
        public static MvcHtmlString DecimalBoxFor<TModel>(this HtmlHelper<TModel> html, 
            Expression<Func<TModel, decimal?>> expression, string format, object htmlAttributes)
        {
            var modelName = ExpressionHelper.GetExpressionText(expression);
            //Below is alternate way to retrieve model name
            //modelName = ModelMetadata.FromLambdaExpression(expression, html.ViewData).PropertyName;
            var modelValue = expression.Compile().Invoke(html.ViewData.Model);
            var value = modelValue.HasValue ? modelValue.Value.ToString(format) : modelValue.Value.ToString();
            //ToDo: below testing is pending
            //return html.TextBox(modelName, value, htmlAttributes);
            return new MvcHtmlString("abc");
        }

        public static MvcHtmlString JSActionLink<TModel>(this HtmlHelper<TModel> html, string displayText, string jsFunctionName, object[] funcParams = null)
        {
            var paramsStr = "";
            if (funcParams != null)
            {
                foreach (object parm in funcParams)
                {
                    object param = parm;
                    double d;
                    if (!double.TryParse(param.ToString(), out d))
                        param = "'" + param + "'";

                    if (paramsStr == "")
                        paramsStr += param;
                    else
                        paramsStr += "," + param;
                }
            }
            //var input = string.Format("<input type='button' value='{0}' onclick='{1}({2})' />", displayText, jsFunctionName, paramsStr);
            var input = string.Format("<a href='Javascript:{1}({2});'>{0}</a>", displayText, jsFunctionName, paramsStr);
            return MvcHtmlString.Create(input);
        }

        public static MvcHtmlString ActionButton(this HtmlHelper html, string displayText, string actionName, string controllerName, object routeValues)        
        {
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            var urlHelper = new UrlHelper(new RequestContext(httpContext, new RouteData()));
            var url = urlHelper.Action(actionName, controllerName, routeValues);
            var input = string.Format("<input type='button' value='{0}' onclick='window.location.href=\"{1}\"' />", displayText, url);
            return MvcHtmlString.Create(input);
        }
    }
}