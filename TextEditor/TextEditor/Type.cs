using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastColoredTextBoxNS;

namespace TextEditor
{
    public class Type
    {
        public IType TypeSyn { get; set; }
        public Language LanguageType()
        {
            return TypeSyn.LanguageType();
        }
    }
}
