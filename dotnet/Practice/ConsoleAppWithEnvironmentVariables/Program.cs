var envVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);

foreach (var item in envVariables)
{
    System.Console.WriteLine(item);
}


// while (true)
// {
//     var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
//     ArgumentNullException.ThrowIfNullOrWhiteSpace(connectionString);
//     System.Console.WriteLine($"connection string: {connectionString}");
//     Thread.Sleep(1000);
// }