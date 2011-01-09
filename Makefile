all: safe unsafe simd

safe:
	xbuild /p:Configuration=Safe

unsafe:
	xbuild /p:Configuration=Unsafe

simd:
	xbuild /p:Configuration=Simd

bench-safe:
	mono Benchmark/bin/Safe/Benchmark.exe

bench-unsafe:
	mono Benchmark/bin/Unsafe/Benchmark.exe

bench-simd:
	mono Benchmark/bin/Simd/Benchmark.exe

.PHONY: safe unsafe simd bench-safe bench-unsafe bench-simd
