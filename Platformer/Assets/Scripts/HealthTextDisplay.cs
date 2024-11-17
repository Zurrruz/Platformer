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

    private void OnEnable()
    {
        _healthCharacter.Changed += Show;
    }

    private void OnDisable()
    {
        _healthCharacter.Changed -= Show;
    }

    public override void Show()
    {
        _currentValue.text = _healthCharacter.CurrentValue.ToString();
        _maxValue.text = "/ " + _healthCharacter.MaxValue.ToString();
    }
}
