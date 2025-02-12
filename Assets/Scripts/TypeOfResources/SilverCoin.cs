using System;

public class SilverCoin : Resource
{
    public event Action SilverDelivered;
   

    private void OnDisable()
    {
        SilverDelivered?.Invoke();
    }
}
