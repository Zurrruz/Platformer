using System.Collections;
using UnityEngine;

public class CooldownAttack : MonoBehaviour
{
    [SerializeField] private float _rechargeTime;

    private WaitForSeconds _time;

    private void Awake()
    {
        _time = new WaitForSeconds(_rechargeTime);
    }

    public bool CanAttack { get; private set; } = true;

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
