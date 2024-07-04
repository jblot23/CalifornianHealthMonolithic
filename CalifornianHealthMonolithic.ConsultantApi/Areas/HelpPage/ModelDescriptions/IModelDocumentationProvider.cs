using System;
using System.Reflection;

namespace CalifornianHealthMonolithic.ConsultantApi.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}