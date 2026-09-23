using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private AudioClip _heartSFX;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _spriteRenderer.enabled = false;
            _boxCollider2D.enabled = false;
            _audioSource.PlayOneShot(_heartSFX);
            Destroy(gameObject, 1f);
        }
    }

}
