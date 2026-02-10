using System;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree
{
    public Node? Root { get; set; }

    public BinarySearchTree()
    {
        Root = null;
    }

    // Insert value
    public void Insert(int value)
    {
        if (Root == null)
            Root = new Node(value);
        else
            Root.Insert(value);
    }

    // Check if tree contains value
    public bool Contains(int value)
    {
        return Root?.Contains(value) ?? false;
    }

    // Traverse backward
    public IEnumerable<int> Reverse()
    {
        if (Root != null)
        {
            foreach (var val in Root.TraverseBackward())
                yield return val;
        }
    }

    // Get tree height
    public int GetHeight()
    {
        return Root?.GetHeight() ?? 0;
    }

    // Convert tree to string for test comparison
    public override string ToString()
    {
        if (Root == null) return "<Bst>{}";
        return "<Bst>{" + string.Join(", ", Root.TraverseForward()) + "}";
    }
}
