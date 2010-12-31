Overview
========

Mono.GameMath is a project to develop a highly-performant math library
for games.

There will be three components:
* the math library
* a benchmark suite
* an IL manipulation tool

The Library
===========

The math library API is initially based on the XNA math API, in order to 
make it easy to port code, however it will likely be expanded. Non-math 
algorithms used in games may also be added if contributed.

The library will have the following ifdefed versions:
* "safe" - as a baseline and for sandboxed platforms
* unsafe - for architectures without SIMD support
* unsafe + Mono.Simd

Architecture-specific versions tuned for JIT & SIMD behaviour
may be added later if benchmarks indicate this is necessary.

The Benchmark Suite
===================

The benchmark suite will consist of micro-benchmarks to measure 
individual functions, and macro-benchmarks to test the interaction of 
multiple functions. The purpose of the benchmark suite is to ensure 
that optimizations actually improve the performance, and to be able
to evaluate performance on different runtimes and CPU architectures
where JIT behaviour may differ.

The benchmark runner will be able to run the benchmarks against 
different versions of the library with different optimizations.
It will also be able to compare results against recorded baselines.

The IL Tool
===========

The IL manipulation tool will be used to create differently tuned
versions of the library, and to optimize consuming code, based on
by attributes in the code. It may inline functions, rewrite pass-
by-value function calls to use pass-by-ref overloads (especially
for overloaded operators), and perhaps other optimizations such as 
profile-guided optimization (it would be great if we could use
attributes to annotate things for the JIT to inline or to heavily 
optimize).
