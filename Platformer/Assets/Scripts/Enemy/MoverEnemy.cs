using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Vector3 _turn = new Vector3(0, 180, 0);

    public void Move(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        Rotate(target);
    }

    private void Rotate(Transform target)
    {
        if (target.position.x > transform.position.x)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.rotation = Quaternion.Euler(_turn);
    }
}