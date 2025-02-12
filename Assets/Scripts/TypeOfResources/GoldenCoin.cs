using System;

public class GoldenCoin : Resource
{
    public event Action GoldDelivered;

    

    private void OnDisable()
    {
        GoldDelivered?.Invoke();
    }
}
