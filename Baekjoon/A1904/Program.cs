using System;
using System.Collections.Generic;
using System.Text;

//https://www.acmicpc.net/problem/1904
//자릿수가 N이고 '00, 1' 로 이루어진 2진수의 조합
namespace A1904
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data)
        {
            this.Data = data;
        }
    }

    public class BinaryTree
    {
        public BinaryTreeNode<bool> root { get; set; }

        int depth;
        public int count = 0;
        public BinaryTree(int depth = 0)
        {
            this.depth = depth;
            root = new BinaryTreeNode<bool>(true);
            Init(root, depth);
        }

        public void Init(BinaryTreeNode<bool> parent, int depth, int direction = 1)
        {
            if (depth != 0)
            {
                parent.Left = new BinaryTreeNode<bool>(false);
                parent.Right = new BinaryTreeNode<bool>(true);
                if (direction == 1)
                {
                    Init(parent.Left, depth - 1, 0);
                }
                else
                {
                    Init(parent.Left, depth - 1, 0);
                    Init(parent.Right, depth - 1, 1);
                }
            }
        }

        public void PreOrderTraversal(BinaryTreeNode<bool> node, int depth = 0, int direction = 1)
        {
            if (node == null) return;

            for (int i = 0; i < depth; i++)
            {
                Console.Write($"  ");
            }
            if(this.depth == depth)
            {
                count++;
            }
            Console.WriteLine($"{direction} : {node.Data}");
            
            PreOrderTraversal(node.Left, depth + 1, 0);
            PreOrderTraversal(node.Right, depth + 1, 1);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree(int.Parse(Console.ReadLine()));
            binaryTree.PreOrderTraversal(binaryTree.root);
            Console.WriteLine(binaryTree.count);
        }
    }
}
