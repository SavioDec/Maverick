using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float airPlaneHeight = 60.0f;

    [SerializeField] private float cooldownTime = 1.0f; // Tempo de cooldown entre disparos
    private float lastShotTime = -Mathf.Infinity; // Armazena o tempo do último disparo

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform){
        float playerPosition = playerTransform.position.y;
        // Verifica se o jogador está acima da altura do avião e se o cooldown passou
        if (playerPosition >= airPlaneHeight && Time.time >= lastShotTime + cooldownTime)
        {
            // Instancia a bala
            var bullet = Instantiate(BulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Calcula a direção do jogador em relação ao ponto de spawn da bala
            Vector3 shootDirection = (playerTransform.position - bulletSpawnPoint.position).normalized;

            // Aplica a direção ao Rigidbody da bala para garantir que ela siga o movimento
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.linearVelocity = shootDirection * bulletSpeed; // Movimento da bala

            // Atualiza o tempo do último disparo
            lastShotTime = Time.time;
        }
        }
    }
}