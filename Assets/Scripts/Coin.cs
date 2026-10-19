using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSFX;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider2D;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddCoins();
            _spriteRenderer.enabled = false;
            _circleCollider2D.enabled = false;
            _audioSource.PlayOneShot(_coinSFX);
            Destroy(gameObject, 1f);
        }
    }
}
