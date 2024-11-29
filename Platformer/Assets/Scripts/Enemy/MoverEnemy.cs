using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private SpriteRenderer _sprite;

    private Vector3 _turn = new Vector3(0, 180, 0);

    public void Move(Transform target)
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        Rotate(target);
    }

    private void Rotate(Transform target)
    {
        if (target.position.x > transform.position.x)
            _sprite.flipX = false;
        else
            _sprite.flipX = true;
    }
}