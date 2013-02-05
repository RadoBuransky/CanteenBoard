using System.Windows.Forms;
using System.Linq.Expressions;
using System;

namespace CanteenBoard.WinForms.Extensions
{
    public static class TreeViewExtensions
    {
        /// <summary>
        /// Selects the specified tree view.
        /// </summary>
        /// <param name="treeView">The tree view.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static bool Select(this TreeView treeView, Expression<Func<TreeNode, bool>> predicate)
        {
            Func<TreeNode, bool> compiledPredicate = predicate.Compile();
            foreach (TreeNode child in treeView.Nodes)
            {
                TraverseTree(child, tn => { if (compiledPredicate(tn)) treeView.SelectedNode = tn; });
            }

            return treeView.SelectedNode != null;
        }

        /// <summary>
        /// Traverses the tree.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="action">The action.</param>
        private static void TraverseTree(TreeNode node, Action<TreeNode> action)
        {
            foreach (TreeNode child in node.Nodes)
            {
                action(child);
                TraverseTree(child, action);
            }
        }
    }
}
