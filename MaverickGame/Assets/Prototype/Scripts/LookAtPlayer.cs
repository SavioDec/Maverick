using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    [SerializeField] private Transform torreta, player;
    [SerializeField] private float airPlaneHeight = 10.0f;
    [SerializeField] private GameObject projectile;
    // Update is called once per frame

    void Update()
    {

        if(player != null){
           trackPlane();
            if(player.position.y >= airPlaneHeight){
                shootPlane();
            }
        }
    }

    void trackPlane(){
        torreta.transform.LookAt(player.position);
    }
    
    void shootPlane(){
        Debug.Log("Disparando no Avião");
        Instantiate(projectile);
    }
}
