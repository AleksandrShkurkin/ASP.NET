public class CalcController
{
    private readonly CalcService calcService;

    public CalcController(CalcService calcService)
    {
        this.calcService = calcService;
    }

    public string[] ExecuteOperations(int a, int b)
    {
        var results = new string[4];

        results[0] = $"Add: {a} + {b} = {calcService.Add(a, b)}";
        results[1] = $"Subtract: {a} - {b} = {calcService.Subtract(a, b)}";
        results[2] = $"Multiply: {a} * {b} = {calcService.Multiply(a, b)}";
        results[3] = $"Divide: {a} / {b} = {calcService.Divide(a, b)}";

        return results;
    }
}