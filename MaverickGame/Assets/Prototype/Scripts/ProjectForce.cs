using UnityEngine;

public class ProjectForce : MonoBehaviour
{
    [SerializeField] private float speed = 50.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        BulletSpeed();
    }
    void BulletSpeed()
    {
        GetComponent<Rigidbody>().linearVelocity = new Vector3(speed, GetComponent<Rigidbody>().linearVelocity.y);
    }
}
