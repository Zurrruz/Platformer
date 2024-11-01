using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public int Health {  get; private set; }

    private void Awake()
    {
        Health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        Debug.Log("Игрок получил урон");
    }

    public void ChangesHealth(int recoverableHealthPoints)
    {
        Debug.Log(Health);

        if (_maxHealth < Health + recoverableHealthPoints)
            Health = _maxHealth;
        else
            Health += recoverableHealthPoints;

        Debug.Log("восстановил" + Health);
    }
}
