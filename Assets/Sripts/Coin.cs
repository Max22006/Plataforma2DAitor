using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
    
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddCoins();
            Destroy(gameObject);
        }
    }
}
