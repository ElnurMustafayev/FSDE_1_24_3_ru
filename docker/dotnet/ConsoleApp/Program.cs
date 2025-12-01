bool isTick = true;

while (true)
{
    System.Console.WriteLine(isTick ? "TICK" : "TACK");
    isTick = !isTick;

    Thread.Sleep(1000);
}