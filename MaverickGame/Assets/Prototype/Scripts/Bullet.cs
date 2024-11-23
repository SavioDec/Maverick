using UnityEngine;

using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float life = 15;
    [SerializeField] private GameObject player;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        Destroy(collision.gameObject);

        SceneManager.LoadScene(3);
        
        
        Destroy(gameObject);
        
        
        
    }
}