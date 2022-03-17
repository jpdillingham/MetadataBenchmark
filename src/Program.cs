using System.Diagnostics;

var directory = @"\\wse\music\processed\Melvins";
var files = Directory.GetFiles(directory, "*.mp3", SearchOption.AllDirectories);
Console.WriteLine($"Enumerated {files.Length} files.  Starting benchmark...");

Benchmark("TagLib", () => ProcessWithTagLib(files));
Benchmark("ATL", () => ProcessWithATL(files));

void Benchmark(string name, Action action)
{
    var sw = new Stopwatch();
    sw.Start();
    action();
    sw.Stop();
    Console.WriteLine($"{name} completed in {sw.ElapsedMilliseconds}ms");
}

void ProcessWithTagLib(string[] files)
{
    foreach (var file in files)
    {
        var tfile = TagLib.File.Create(file);
        //Console.WriteLine($"{file}: {tfile.Properties.Duration}, {tfile.Properties.AudioBitrate}");
    }
}

void ProcessWithATL(string[] files)
{
    foreach (var file in files)
    {
        var theTrack = new ATL.Track(file);
        //Console.WriteLine($"{file}: {theTrack.Duration}, {theTrack.Bitrate}");
    }
}