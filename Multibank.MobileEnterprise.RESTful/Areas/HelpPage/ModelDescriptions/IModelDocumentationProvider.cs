using System;
using System.Reflection;

namespace Multibank.MobileEnterprise.RESTful.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}