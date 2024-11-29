using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class MovePlane : MonoBehaviour
{
    [Header("Plane Status")]
    [Tooltip("o quanto o acelerador sobe ou desce")]
    [SerializeField] private float throttleIncrement = 0.6f;
    [Tooltip("Maximo de aceleração quanto o acelerador esta em 100%")]
    [SerializeField] private float maxThrottle = 200f;
    [Tooltip("o quao responsivo o avião é ao rolar, inclinar ou rotacionar")]
    [SerializeField]private float responsiviness = 10f;

    [SerializeField] private float lift = 135f;

    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;

    private float responseModifier {
        get{
            return (rb.mass / 10f) * responsiviness;
        }
    }

    Rigidbody rb;
    [SerializeField] TextMeshProUGUI hud;
    [SerializeField] TextMeshProUGUI instructions;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInput(){
        //valores rotacionais dos eixos
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        //valor do acelerador de 0 a 100
        if(Input.GetKey(KeyCode.Space)){
            throttle += throttleIncrement;
        }else if(Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    private void Update(){
        HandleInput();
        UpdateHud();
        InstructionsHud();
    }

    private void FixedUpdate(){
        rb.AddForce(transform.forward * maxThrottle * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(-transform.forward * roll * responseModifier);
        
        rb.AddForce(Vector3.up * rb.linearVelocity.magnitude * lift);
        
    }

    private void InstructionsHud()
    {
        instructions.text = "as torretas começarão atirar ao ultrapassar 60 metros ";
        if (rb.position.y > 1)
        {
            instructions.text = "";
        }
    }
    private void UpdateHud(){
        hud.text = "Acelerador: " + throttle.ToString("F0") + "%\n";
        hud.text += "Velocidade: " + (rb.linearVelocity.magnitude * 3.6f).ToString("F0") + "Km/h\n";
        hud.text += "Altitude: " + rb.position.y.ToString("F0") + "m";
    }

}
