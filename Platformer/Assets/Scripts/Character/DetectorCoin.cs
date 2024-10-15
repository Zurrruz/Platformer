using UnityEngine;

public class DetectorCoin : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
            coin.Delete();
    }
}
