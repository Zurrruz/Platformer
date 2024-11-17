using TMPro;
using UnityEngine;

public class HealthTextDisplay : HealthBar
{
    [SerializeField] private TMP_Text _maxHealth;
    [SerializeField] private TMP_Text _currentHealth;

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
        _currentHealth.text = _healthCharacter.CurrentValue.ToString();
        _maxHealth.text = "/ " + _healthCharacter.MaxValue.ToString();
    }
}
