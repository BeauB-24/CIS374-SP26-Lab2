using System;
using DSA.DataStructures.Trees;

namespace Lab1
{
	public class HeightKeyValueMapBenchmarks
	{
		public HeightKeyValueMapBenchmarks(int n, bool isInOrder)
		{
            IsInOrder = isInOrder;
            N = n;

		}

        public enum KeyValueMapType { Dictionary, BST, AVL, RedBlack }

        public List<KeyValuePair<int, int>>? keyValuePairs;
        public List<KeyValuePair<int, int>>? keyValuePairsShuffled;

        
        public readonly bool IsInOrder = false;
        public readonly int N;
        public readonly int NumberOfTimes = 100;

        public void Setup()
        {
            keyValuePairs = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < N; i++)
            {
                keyValuePairs.Add(new KeyValuePair<int, int>(i, i * 10));
            }

            if (!IsInOrder)
            {
                keyValuePairs.Shuffle();
            }
        }

        // This has the SOL seal of approval.
        public double HeightOfBST()
        {
            int totalHeights = 0;
            for(int i=0; i < NumberOfTimes; i++)
            {
                Setup();
                var bst = new BinarySearchTreeMap<int, int>();
                foreach(var kvp in keyValuePairs)
                {
                    bst.Add(kvp.Key, kvp.Value);
                }
                //Console.WriteLine(bst.Height);
                totalHeights += bst.Height;
            }

            return (double)totalHeights / NumberOfTimes;
        }

        public double HeightOfAVLTree()
        {
            int totalHeights = 0;
            for (int i = 0; i < NumberOfTimes; i++)
            {
                Setup();
                var avlTree = new AVLTreeMap<int, int>();
                foreach (var kvp in keyValuePairs)
                {
                    avlTree.Add(kvp.Key, kvp.Value);
                }
                //Console.WriteLine(avlTree.Height);    
                totalHeights += avlTree.Height;
            }

            return (double)totalHeights / NumberOfTimes;
        }


        public double HeightOfRedBlackTree()
        {
            int totalHeights = 0;
            for (int i = 0; i < NumberOfTimes; i++)
            {
                Setup();
                var redblackTree = new RedBlackTreeMap<int, int>();
                foreach (var kvp in keyValuePairs)
                {
                    redblackTree.Add(kvp.Key, kvp.Value);
                }
                //Console.WriteLine(redblackTree.Height);
                totalHeights += redblackTree.Height;
            }

            return (double)totalHeights / NumberOfTimes;
        }

    }
}

