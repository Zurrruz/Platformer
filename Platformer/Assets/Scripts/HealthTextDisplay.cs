using TMPro;
using UnityEngine;

public class HealthTextDisplay : HealthBar
{
    [SerializeField] private TMP_Text _maxValue;
    [SerializeField] private TMP_Text _currentValue;

    private void Start()
    {
        Show();
    }

    public override void Show()
    {
        _currentValue.text = health.CurrentValue.ToString();
        _maxValue.text = "/ " + health.MaxValue.ToString();
    }
}
