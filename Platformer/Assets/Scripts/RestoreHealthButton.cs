using UnityEngine;

public class RestoreHealthButton : MonoBehaviour
{
    [SerializeField] private int _recover;
    [SerializeField] private Health _health;

    public void Recover()
    {
        _health.Restore(_recover);
    }
}
