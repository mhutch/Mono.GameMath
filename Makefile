all: safe unsafe simd

safe:
	xbuild /p:Configuration=Safe

unsafe:
	xbuild /p:Configuration=Unsafe

simd:
	xbuild /p:Configuration=Simd

bench-safe:
	mono Benchmark/bin/Debug/Benchmark.exe Safe

bench-unsafe:
	mono Benchmark/bin/Debug/Benchmark.exe Unsafe

bench-simd:
	mono Benchmark/bin/Debug/Benchmark.exe Simd

.PHONY: safe unsafe simd bench-safe bench-unsafe bench-simd
