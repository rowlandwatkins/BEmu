﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEmu.ReferenceDataRequest
{
    internal class ElementReferenceSecurityDataArray : Element
    {
        private readonly List<ElementReferenceSecurityData> _securities;

        internal ElementReferenceSecurityDataArray(Dictionary<string, Dictionary<string, object>> securities)
        {
            this._securities = new List<ElementReferenceSecurityData>();

            foreach (var item in securities)
            {
                ElementReferenceSecurityData secData = new ElementReferenceSecurityData(item.Key, item.Value, this._securities.Count);
                this._securities.Add(secData);
            }
        }

        internal ElementReferenceSecurityDataArray(ElementReferenceSecurityDataArray arg) //copy constructor
        {
            this._securities = new List<ElementReferenceSecurityData>(arg._securities);
        }

        public override int NumElements { get { return 0; } }
        public override int NumValues { get { return this._securities.Count; } }
        public override Name Name { get { return new Name("securityData"); } }
        public override IEnumerable<Element> Elements { get { return this._securities; } }

        public override Element GetValueAsElement(int index)
        {
            return this._securities[index];
        }

        internal override StringBuilder PrettyPrint(int tabIndent)
        {
            string tabs = Types.IndentType.Indent(tabIndent);
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0}{1}[] = {{{2}", tabs, this.Name, Environment.NewLine);
            foreach (var item in this._securities)
            {
                result.Append(item.PrettyPrint(tabIndent + 1));
            }
            result.AppendFormat("{0}}}{1}", tabs, Environment.NewLine);

            return result;
        }

    }
}