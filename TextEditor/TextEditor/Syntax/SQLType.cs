using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    class SQLType : IType
    {
        public Language LanguageType()
        {
            return Language.SQL;
        }
    }
}
