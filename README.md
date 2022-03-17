# MetadataBenchmark
Benchmarking music file metadata libraries

# Results

```
$ dotnet run
Enumerated 2659 files.  Starting benchmark...
Run: 0
TagLib completed in 43512ms
ATL completed in 16009ms
Run: 1
TagLib completed in 34752ms
ATL completed in 14788ms
Run: 2
TagLib completed in 33282ms
ATL completed in 14006ms
Run: 3
TagLib completed in 32794ms
ATL completed in 14207ms
Run: 4
TagLib completed in 31437ms
ATL completed in 15146ms
```

Anticipating that caching may be impacting the results, I reversed the order:

```
$ dotnet run
Enumerated 2659 files.  Starting benchmark...
Run: 0
ATL completed in 14447ms
TagLib completed in 30403ms
Run: 1
ATL completed in 14535ms
TagLib completed in 30928ms
Run: 2
ATL completed in 13801ms
TagLib completed in 31119ms
Run: 3
ATL completed in 15787ms
TagLib completed in 31251ms
Run: 4
ATL completed in 14417ms
TagLib completed in 32119ms
```

Caching does play a part when running against fewer files:

```
$ dotnet run
Enumerated 827 files.  Starting benchmark...
Run: 0
ATL completed in 1768ms
TagLib completed in 2366ms
Run: 1
ATL completed in 251ms
TagLib completed in 234ms
Run: 2
ATL completed in 250ms
TagLib completed in 229ms
Run: 3
ATL completed in 249ms
TagLib completed in 233ms
Run: 4
ATL completed in 249ms
TagLib completed in 226ms
```