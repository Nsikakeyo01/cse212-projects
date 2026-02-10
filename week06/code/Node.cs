using System;
using System.Collections.Generic;

public class Node
{
    public int Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }

    // Insert unique values only
    public void Insert(int value)
    {
        if (value == Value) return; // skip duplicates

        if (value < Value)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // Check if value exists in subtree
    public bool Contains(int value)
    {
        if (value == Value) return true;

        if (value < Value)
            return Left?.Contains(value) ?? false;
        else
            return Right?.Contains(value) ?? false;
    }

    // Traverse backward (largest to smallest)
    public IEnumerable<int> TraverseBackward()
    {
        if (Right != null)
        {
            foreach (var val in Right.TraverseBackward())
                yield return val;
        }

        yield return Value;

        if (Left != null)
        {
            foreach (var val in Left.TraverseBackward())
                yield return val;
        }
    }

    // Traverse forward (smallest to largest)
    public IEnumerable<int> TraverseForward()
    {
        if (Left != null)
        {
            foreach (var val in Left.TraverseForward())
                yield return val;
        }

        yield return Value;

        if (Right != null)
        {
            foreach (var val in Right.TraverseForward())
                yield return val;
        }
    }

    // Get height of subtree
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
