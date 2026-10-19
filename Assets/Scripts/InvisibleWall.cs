using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           Destroy(collision.gameObject, 1.5f);
           CanvasManager.Instance.ActivateCanvas(CanvasManager.Instance.gameOverCanvas, CanvasManager.Instance._returnButton);
        }
    }
}
