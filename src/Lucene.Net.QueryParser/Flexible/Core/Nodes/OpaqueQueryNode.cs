﻿using Lucene.Net.QueryParsers.Flexible.Core.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucene.Net.QueryParsers.Flexible.Core.Nodes
{
    /// <summary>
    /// A {@link OpaqueQueryNode} is used for specify values that are not supposed to
    /// be parsed by the parser. For example: and XPATH query in the middle of a
    /// query string a b @xpath:'/bookstore/book[1]/title' c d
    /// </summary>
    public class OpaqueQueryNode : QueryNodeImpl
    {
        private string schema = null;

        private string value = null;

        /**
         * @param schema
         *          - schema identifier
         * @param value
         *          - value that was not parsed
         */
        public OpaqueQueryNode(string schema, string value)
        {
            this.SetLeaf(true);

            this.schema = schema;
            this.value = value;

        }


        public override string ToString()
        {
            return "<opaque schema='" + this.schema + "' value='" + this.value + "'/>";
        }


        public override string ToQueryString(IEscapeQuerySyntax escapeSyntaxParser)
        {
            return "@" + this.schema + ":'" + this.value + "'";
        }


        public override IQueryNode CloneTree()
        {
            OpaqueQueryNode clone = (OpaqueQueryNode)base.CloneTree();

            clone.schema = this.schema;
            clone.value = this.value;

            return clone;
        }

        /**
         * @return the schema
         */
        public string GetSchema()
        {
            return this.schema;
        }

        /**
         * @return the value
         */
        public string GetValue()
        {
            return this.value;
        }
    }
}