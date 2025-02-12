using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldAmountText;
    [SerializeField] private TextMeshProUGUI _silverAmountText;
    
    public void UpdateGoldAmountView(int goldAmount)
    {
        _goldAmountText.text = goldAmount.ToString();
    }

    public void UpdateSilverAmountView(int silverAmount)
    {
        _silverAmountText.text = silverAmount.ToString();
    }
}
