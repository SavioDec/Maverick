using UnityEngine;


public class LookAtPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    [SerializeField] private Transform torreta, player;

    [SerializeField] private float airPlaneHeight = 10.0f;
    
    [SerializeField] private GameObject projectile, gun;

    [SerializeField] private float projectileSpeed = 300.0f;


    [SerializeField] private GameObject muzzleFlash;


    // Update is called once per frame

    void Update()
    {
        if (player != null)
        {
            trackPlane();
            if (player.position.y >= airPlaneHeight)
            {
                shootPlane();
                muzzleFlash.SetActive(true);
            }
            else
            {
                muzzleFlash.SetActive(false);
            }
        }
    }

    void trackPlane()
    {
        torreta.transform.LookAt(player.position);
    }

    void shootPlane()
    {
        Debug.Log("atirando");
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
    }
}