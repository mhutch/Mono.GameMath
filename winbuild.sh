export PATH="/c/Windows/Microsoft.NET/Framework/v4.0.30319:$PATH"

CONFIGS="Safe SafeX86 Unsafe Simd Xna"

for c in $CONFIGS; do
	echo Building $c
	MSBuild.exe Mono.GameMath.sln -p:Configuration=$c $* || exit 1
done
