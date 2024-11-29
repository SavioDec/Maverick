using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject checkPoint;

    [SerializeField] private Vector3 vectorPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(checkPoint);
        vectorPoint = player.transform.position;
        SceneManager.LoadScene(4);
    }
}
