using System.Collections;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private float _rechargeTime;

    private WaitForSeconds _time;

    public bool CanAttack { get; private set; } = true;

    private void Awake()
    {
        _time = new WaitForSeconds(_rechargeTime);
    }

    public void StartRecharge()
    {
        CanAttack = false;

        StartCoroutine(Recharge());
    }

    private IEnumerator Recharge()
    {
        yield return _time;

        CanAttack = true;
    }
}
