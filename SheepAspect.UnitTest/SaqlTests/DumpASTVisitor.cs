using System;
using Antlr.Runtime.JavaExtensions;
using Antlr.Runtime.Tree;

namespace SheepAspect.UnitTest.SaqlTests
{
    /* ANTLR Translator Generator
     * Project led by Terence Parr at http://www.jGuru.com
     * Software rights: http://www.antlr.org/license.html
     *
     * $Id:$
     */

    //
    // ANTLR C# Code Generator by Micheal Jordan
    //                            Kunle Odutola       : kunle UNDERSCORE odutola AT hotmail DOT com
    //                            Anthony Oguntimehin
    //
    // With many thanks to Eric V. Smith from the ANTLR list.
    //

    /// <summary>
    /// Summary description for DumpASTVisitor.
    /// </summary>
    /** Simple class to dump the contents of an AST to the output */
    public class DumpAstVisitor
    {
        protected int level = 0;


        private void tabs()
        {
            for (int i = 0; i < level; i++)
            {
                Console.Out.Write("   ");
            }
        }


        public void visit(ITree node)
        {
            // Flatten this level of the tree if it has no children
            bool flatten = /*true*/ false;
            ITree node2;
            
            for (node2 = node; node2 != null; node2 = node2.getNextSibling())
            {
                if (node2.GetChild(0) != null)
                {
                    flatten = false;
                    break;
                }

                if (node.Parent == null)
                {
                    break;
                }
            }

            for (node2 = node; node2 != null; node2 = node2.getNextSibling())
            {
                if (!flatten || node2 == node)
                {
                    tabs();
                }
                if (node2.Text == null)
                {
                    Console.Out.Write("nil");
                }
                else
                {
                    Console.Out.Write(node2.Text);
                }

                Console.Out.Write(" [" + node2.Type + "] ");

                if (flatten)
                {
                    Console.Out.Write(" ");
                }
                else
                {
                    Console.Out.WriteLine("");
                }

                if (node2.GetChild(0) != null)
                {
                    level++;
                    visit(node2.GetChild(0));
                    level--;
                }

                if (node.Parent == null)
                {
                    break;
                }
            }

            if (flatten)
            {
                Console.Out.WriteLine("");
            }
        }
    }
}
