using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthBar
{
    private Coroutine _coroutine;

    private float _speedSlider = 3f;

    public override void Show()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Change());
    }

    private IEnumerator Change()
    {
        float target = Health.CurrentValue / Health.MaxValue;
        float startValue = Slider.value;
        float step = 0;

        while (Slider.value != target)
        {
            Slider.value = Mathf.Lerp(startValue, target , step);

            yield return null;

            step += _speedSlider * Time.deltaTime;
        }
    }
}