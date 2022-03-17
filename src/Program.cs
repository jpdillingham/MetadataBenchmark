using System.Diagnostics;

var directories = new[] {
    @"\\path\to\mp3s"
};

var files = new List<string>();

foreach (var dir in directories)
{
    files.AddRange(Directory.GetFiles(dir, "*.mp3", SearchOption.AllDirectories));
}

Console.WriteLine($"Enumerated {files.Count} files.  Starting benchmark...");

for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Run: {i+1}");
    Benchmark("TagLib", () => ProcessWithTagLib(files));
    Benchmark("ATL", () => ProcessWithATL(files));
}

void Benchmark(string name, Action action)
{
    var sw = new Stopwatch();
    sw.Start();
    action();
    sw.Stop();
    Console.WriteLine($"{name} completed in {sw.ElapsedMilliseconds}ms");
}

void ProcessWithTagLib(List<string> files)
{
    foreach (var file in files)
    {
        var tfile = TagLib.File.Create(file);
        //Console.WriteLine($"{file}: {tfile.Properties.Duration}, {tfile.Properties.AudioBitrate}");
    }
}

void ProcessWithATL(List<string> files)
{
    foreach (var file in files)
    {
        var theTrack = new ATL.Track(file);
        //Console.WriteLine($"{file}: {theTrack.Duration}, {theTrack.Bitrate}");
    }
}