using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSFX;
    private AudioSource _audioSource;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddCoins();
            _audioSource.PlayOneShot(_coinSFX);
            Destroy(gameObject);
        }
    }
}
