using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers.CSharp;

namespace SemanticMerge
{
    public class Merge
    {
        public readonly SyntaxTree Parent;
        public readonly SyntaxTree Left;
        public readonly SyntaxTree Right;

        public Merge(SyntaxTree parent, SyntaxTree left, SyntaxTree right)
        {
            Parent = parent;
            Left = left;
            Right = right;
        }

        public SyntaxTree GetResult()
        {
            if (Left.IsEquivalentTo(Right))
                return Left;

            throw new NotImplementedException();
        }
    }
}
