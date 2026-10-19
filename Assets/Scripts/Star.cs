using UnityEngine;

public class Star : MonoBehaviour
{

    [SerializeField] private AudioClip _starSFX;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();  
    }

    
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddStars();
            _spriteRenderer.enabled = false;
            _boxCollider.enabled = false;
            _audioSource.PlayOneShot(_starSFX);
            Destroy(gameObject, 1f);
        }
    }
}
