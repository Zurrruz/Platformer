using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public float Moving { get; private set; }

    private void Update()
    {
        Moving = Input.GetAxis("Horizontal");
    }
}
