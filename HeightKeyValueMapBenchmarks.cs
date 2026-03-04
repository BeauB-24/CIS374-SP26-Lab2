using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using DSA.DataStructures.Trees;

namespace Lab1
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public class HeightKeyValueMapBenchmarks
    {
        public enum KeyValueMapType { BST, AVL, RedBlack }

        [Params(100, 1000, 10_000, 100_000)]
        public int N { get; set; }

        [Params(true, false)]
        public bool IsInOrder { get; set; }

        public List<KeyValuePair<int, int>>? keyValuePairs;

        [GlobalSetup]
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

        private int NumberOfTimes = 100;

        [Benchmark]
        public double HeightOfBST()
        {
            int totalHeights = 0;
            for (int i = 0; i < NumberOfTimes; i++)
            {
                Setup();
                var bst = new BinarySearchTreeMap<int, int>();
                foreach (var kvp in keyValuePairs)
                {
                    bst.Add(kvp.Key, kvp.Value);
                }
                totalHeights += bst.Height;
            }
            return (double)totalHeights / NumberOfTimes;
        }

        [Benchmark]
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
                totalHeights += avlTree.Height;
            }
            return (double)totalHeights / NumberOfTimes;
        }

        [Benchmark]
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
                totalHeights += redblackTree.Height;
            }
            return (double)totalHeights / NumberOfTimes;
        }
    }
}