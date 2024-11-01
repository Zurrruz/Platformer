using UnityEngine;

public class InputParameters : MonoBehaviour
{
    public float Moving { get; private set; }
    public bool IsAttacking {  get; private set; }

    private void Update()
    {
        Moving = Input.GetAxis("Horizontal");
        IsAttacking = Input.GetKeyDown(KeyCode.F);
    }
}
