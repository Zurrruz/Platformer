using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirismSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Vampirism _vampirism;

    private float _minSliderValue = 0;
    private float _maxSliderValue = 1;

    private WaitForSeconds Timer;

    private void Awake()
    {
        Timer = new WaitForSeconds(_vampirism.SpellTime);
    }

    private void OnEnable()
    {
        _vampirism.Attaked += StartChangeSlider;
    }

    private void OnDisable()
    {
        _vampirism.Attaked -= StartChangeSlider;
    }

    private void StartChangeSlider(float rechargeTime)
    {
        StartCoroutine(ChangeSlider(_minSliderValue, _vampirism.SpellTime, "на убывание"));
        StartCoroutine(RechargeSlider(rechargeTime));
    }

    private IEnumerator RechargeSlider(float rechargeTime)
    {
        yield return Timer;

        StartCoroutine(ChangeSlider(_maxSliderValue, rechargeTime , "увеличивается"));
    }

    private IEnumerator ChangeSlider(float target, float time, string b)
    {        
        float startValue = _slider.value;
        float step = _maxSliderValue / time;
        float currentStep = 0;

        while (_slider.value != target)
        {
            _slider.value = Mathf.Lerp(startValue, target, currentStep);
            Debug.Log(b);
            yield return null;

            currentStep += step * Time.deltaTime;
        }
    }
}
