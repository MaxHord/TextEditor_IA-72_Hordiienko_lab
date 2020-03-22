using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor;
using FastColoredTextBoxNS;

namespace TextEditor
{
    public class JsType : IType
    {
        public Language LanguageType()
        {
            return Language.JS;
        }
    }
}
