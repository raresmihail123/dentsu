namespace dentsu.Controller;

public class SolutionService : ISolutionService
{
    private Solution _solution;


    public SolutionService()
    {
        _solution = new Solution();
    }
    public Solution GetSolution()
    {
        return _solution;
    }

    public void UpdateSolution(Solution solution)
    {
        _solution = solution;
    }
}
