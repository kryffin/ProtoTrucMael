public class Resource
{

    public enum ResourceType
    {
        People,
        Energy,
        Food
    }

    // Current amount of the resource
    private float _amount;
    public float Amount
    { get => _amount; }

    public Resource(float amount)
    {
        _amount = amount;
    }

    // Produces x amount of the resource and returns the new amount
    public float Produce(float x)
    {
        _amount += x;
        return _amount;
    }

    // Consumes x amount of the resource and returns the new amount
    public float Consume(float x)
    {
        _amount -= x;
        return _amount;
    }

}
