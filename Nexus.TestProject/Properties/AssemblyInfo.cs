// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
using System.Reflection;
[assembly: Parallelizable(ParallelScope.Fixtures)]
// Change LevelOfParallelism to 4 when doing a checkin, Pipelines needs this to be set to 4
[assembly: LevelOfParallelism(5)] // Comment out while using chrome or use 8 - 10, firefox  is unstable above 5 parallel execution at a time
