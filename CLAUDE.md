# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
# Build
dotnet build

# Run benchmarks (must use Release mode for BenchmarkDotNet)
dotnet run -c Release

# Build without running
dotnet build -c Release
```

> BenchmarkDotNet will warn and refuse to run meaningful benchmarks in Debug mode. Always use `-c Release`.

Benchmark results are written to `BenchmarkDotNet.Artifacts/` in Markdown, HTML, CSV, and AsciiDoc formats.

## Architecture

This is a CIS374 (Data Structures & Algorithms) lab project benchmarking key-value map performance using [BenchmarkDotNet](https://benchmarkdotnet.org/). The namespace is `Lab1` despite the directory being `Lab2`.

**Data structures compared:** `Dictionary<int,int>` (hash map), `BinarySearchTreeMap`, `AVLTreeMap`, `RedBlackTreeMap`

The tree implementations live in [DSA/](DSA/) and are sourced from a custom DSA library (namespace `DSA.DataStructures.Trees`). They are not installed via NuGet — the `.cs` files are included directly in the project.

**Benchmark classes:**
- [InsertKeyValueMapBenchmarks.cs](InsertKeyValueMapBenchmarks.cs) — measures insert time across data structures, parameterized by `N` (100–100,000) and `isInOrder` (sorted vs. shuffled input)
- [LookupKeyValueMapBenchmarks.cs](LookupKeyValueMapBenchmarks.cs) — pre-populates a structure in `GlobalSetup`, then benchmarks random-order lookups
- [RemoveKeyValueMapBenchmarks.cs](RemoveKeyValueMapBenchmark.cs) — same pattern as Lookup but for removal (note: BST/AVL/RedBlack cases in `Remove()` currently perform lookup instead of remove — likely an in-progress lab exercise)
- [HeightKeyValueMapBenchmarks.cs](HeightKeyValueMapBenchmarks.cs) — not a BenchmarkDotNet benchmark; manually averages tree height over 100 random insertions; called directly from `Main` when needed
- [Program.cs](Program.cs) — controls which benchmark runs; switch the `BenchmarkRunner.Run<T>()` call to change what executes

**Utility:**
- [Shuffle.cs](Shuffle.cs) — provides a thread-safe Fisher-Yates `Shuffle<T>()` extension method on `IList<T>`, used by all benchmark setup methods to randomize insertion order

## Switching Which Benchmark Runs

Edit [Program.cs](Program.cs) and uncomment the desired `BenchmarkRunner.Run<>()` call. Only one benchmark class runs per execution.
