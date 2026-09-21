using UnityEngine;

public class Mimik : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 30;
    [SerializeField] private int _health;
    void Awake()
    {
        
    }
    void Start()
    {
        _health = _maxHealth;
    }

    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Death();
        }
    }
    
    void Death()
    {
        Destroy(gameObject);
    }
}
