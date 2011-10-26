using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Roslyn.Compilers.CSharp;
using SemanticMerge;
using System.Reflection;

namespace SemanticMergeTest
{
    [TestClass]
    public class MergeTest
    {
        [TestMethod]
        public void MergeEquivalentDocuments()
        {
            var assemblies = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            var tree = SyntaxTree.ParseCompilationUnit(new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("SemanticMergeTest.ToMergeAddNewMethod.Parent.cs")).ReadToEnd());

            var result = new Merge(tree, tree, tree).GetResult();

            Assert.AreEqual(tree, result);
        }

        [TestMethod]
        public void MergeAddNewMethod()
        {
            var parent = SyntaxTree.ParseCompilationUnit(new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("SemanticMergeTest.ToMergeAddNewMethod.Parent.cs")).ReadToEnd());
            var leftCode = SyntaxTree.ParseCompilationUnit(new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("SemanticMergeTest.ToMergeAddNewMethod.Left.cs")).ReadToEnd());
            var rightCode = SyntaxTree.ParseCompilationUnit(new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("SemanticMergeTest.ToMergeAddNewMethod.Right.cs")).ReadToEnd());

            var result = new Merge(parent, leftCode, rightCode).GetResult();
            var expectedResult = SyntaxTree.ParseCompilationUnit(new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("SemanticMergeTest.ToMergeAddNewMethod.Result.cs")).ReadToEnd());

            Assert.IsTrue(result.IsEquivalentTo(expectedResult));
        }
    }
}
