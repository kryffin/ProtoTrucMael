using System.Collections;
using UnityEngine;

public class Building : MonoBehaviour
{

    public class Costs : IEnumerable
    {

        public class Cost
        {
            private Resource.ResourceType _resource;
            public Resource.ResourceType Resource
            { get => _resource; }

            private float _price;
            public float Price
            { get => _price; }

            public Cost(Resource.ResourceType r, float p)
            {
                _resource = r;
                _price = p;
            }
        }

        private System.Collections.Generic.List<Cost> _costs;

        public Costs(params Cost[] cs)
        {
            _costs = new System.Collections.Generic.List<Cost>();

            foreach (Cost c in cs)
                _costs.Add(c);
        }

        public IEnumerator GetEnumerator()
        {
            return _costs.GetEnumerator();
        }
    }

    protected Costs _constructionCosts;
    public Costs ConstructionCosts { get => _constructionCosts; }

    protected Costs _tickCosts;
    public Costs TickCosts { get => _tickCosts; }

    protected Costs _tickProductions;
    public Costs TickProductions { get => _tickProductions; }

    protected int _capacity;
    public int Capacity { get => _capacity; }

    public Building()
    {
        _constructionCosts = new Costs();
        _tickProductions = new Costs();
        _tickCosts = new Costs();
        _capacity = 0;
    }

    // Consumes the necessary costs in order to construct the building
    public void Construct()
    {
        foreach (Costs.Cost c in _constructionCosts)
            ResourceManager.GetInstance().Consume(c.Resource, c.Price);

        Debug.Log(name + " : Construction");
    }

    // Produces resources and consumes resources
    public void Tick()
    {
        foreach (Costs.Cost c in _tickProductions)
            ResourceManager.GetInstance().Produce(c.Resource, c.Price);

        foreach (Costs.Cost c in _tickCosts)
            ResourceManager.GetInstance().Consume(c.Resource, c.Price);
    }

}
