using System;
using System.Collections.Generic;

public static class Trees
{
    // Create balanced tree from sorted array
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedList)
    {
        BinarySearchTree tree = new BinarySearchTree();
        InsertMiddle(tree, sortedList, 0, sortedList.Length - 1);
        return tree;
    }

    // Helper function for balanced tree
    public static void InsertMiddle(BinarySearchTree tree, int[] list, int first, int last)
    {
        if (first > last) return;

        int mid = (first + last) / 2;
        tree.Insert(list[mid]);

        InsertMiddle(tree, list, first, mid - 1);
        InsertMiddle(tree, list, mid + 1, last);
    }
}
