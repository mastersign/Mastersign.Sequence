pushd "%~dp0\Mastersign.Sequence"
nuget pack .\Mastersign.Sequence.csproj -properties Configuration=Release
popd
