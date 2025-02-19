using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public event Action GoldDelivered;
    public event Action SilverDelivered;

    private void OnDisable()
    {
        if (gameObject.TryGetComponent(out GoldenCoin goldenCoin))
        {
            GoldDelivered?.Invoke();
        }
        else
        {
            SilverDelivered?.Invoke();
        }
    }
}
