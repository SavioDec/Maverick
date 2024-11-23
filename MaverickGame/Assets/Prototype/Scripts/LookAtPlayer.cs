using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    [SerializeField] private Transform torreta, player;
    
    // [SerializeField] private GameObject BulletPrefab;
    // [SerializeField] private Transform bulletSpawnPoint;
    // [SerializeField] private float bulletSpeed;
    

    
    // Update is called once per frame

    void Update()
    {

        if(player != null){
           trackPlane();
            
        }
    }

    void trackPlane(){
        torreta.transform.LookAt(player.position);
        
    }
    
    // void shootPlane()
    // {
    //     Debug.Log("atirando");
    //     var bullet = Instantiate(BulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    //     bullet.GetComponent<Rigidbody>().linearVelocity = bullet.transform.forward * bulletSpeed;
    //     
    // }

    
    
}
