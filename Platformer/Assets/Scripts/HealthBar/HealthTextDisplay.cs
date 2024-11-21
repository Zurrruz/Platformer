using TMPro;
using UnityEngine;

public class HealthTextDisplay : HealthDisplay
{
    [SerializeField] private TMP_Text _maxValue;
    [SerializeField] private TMP_Text _currentValue;

    private void Start()
    {
        _maxValue.text = "/ " + Health.MaxValue.ToString();

        Show();
    }

    public override void Show()
    {
        _currentValue.text = Health.CurrentValue.ToString();        
    }
}
