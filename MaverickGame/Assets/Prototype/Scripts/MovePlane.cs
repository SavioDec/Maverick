using UnityEngine;

public class MovePlane : MonoBehaviour
{
    [SerializeField] private float flySpeed = 10.0f;
    [SerializeField] private float yawAmount = 120.00f;
    private float yaw;




    // Update is called once per frame
    void Update()
    {
        PlayerPlaneController();
    }

    private void PlayerPlaneController(){
        transform.position += transform.forward * flySpeed *Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        yaw += horizontalInput * yawAmount *Time.deltaTime;

        float pitch = Mathf.Lerp(a: 0, b: 120, t:Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(a: 0, b: 80, t:Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);


        //application movement
        transform.localRotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch + Vector3.forward  * roll);

    }
}
