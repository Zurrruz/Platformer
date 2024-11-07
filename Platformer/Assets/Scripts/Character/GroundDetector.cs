using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private int _layerGround;

    public bool IsGrounded { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layerGround)
            if (collision.TryGetComponent(out Ground _))
                IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layerGround)
            if (collision.TryGetComponent(out Ground _))
                IsGrounded = false;
    }
}
