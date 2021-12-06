using UnityEngine;

public class TestBuilding : Building
{

    [Header("Construction cost")]

    public Resource.ResourceType constResType = Resource.ResourceType.People;
    public float constPrice = 1f;

    [Header("Production by tick")]

    public Resource.ResourceType prodResType = Resource.ResourceType.Energy;
    public float prodPrice = 1f;

    [Header("Consumption by tick")]

    public Resource.ResourceType consResType = Resource.ResourceType.Food;
    public float consPrice = 1f;

    [Header("Capacity")]

    public int capacity = 5;

    public TestBuilding()
    {
        _constructionCosts = new Costs(new Costs.Cost(constResType, constPrice));
        _tickProductions = new Costs(new Costs.Cost(prodResType, prodPrice));
        _tickCosts = new Costs(new Costs.Cost(consResType, consPrice));
        _capacity = capacity;
    }

    // DEBUG
    private void OnEnable()
    {
        Construct();
    }

}
