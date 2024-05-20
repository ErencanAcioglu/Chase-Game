using UnityEngine;

public class EnemyCubeController : MonoBehaviour
{
    public float moveSpeed = 5f; // Küpün hareket hızı
    public float minX = -4.5f; // X eksenindeki minimum konum
    public float maxX = 4.5f; // X eksenindeki maksimum konum
    public float minZ = -4.5f; // Z eksenindeki minimum konum
    public float maxZ = 4.5f; // Z eksenindeki maksimum konum

    private Vector3 targetPosition; // Küpün hareket edeceği hedef konum

    private void Start()
    {
        // İlk hedef konumu belirleme
        SetNewTargetPosition();
    }

    private void Update()
    {
        // Küpün hedef konuma doğru hareket etmesi
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Hedef konuma ulaşıldığında yeni bir hedef konumu belirleme
        if (transform.position == targetPosition)
        {
            SetNewTargetPosition();
        }
    }

    void SetNewTargetPosition()
    {
        // Yeni bir rastgele hedef konumu belirleme
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Eğer küp topa çarparsa oyunu bitir
        if (other.CompareTag("Player"))
        {
            Debug.Log("Oyun bitti! Düşman topu yakaladı.");
            // Oyunu bitirme veya oyun bitti mesajını gösterme kodu buraya gelebilir.
        }
    }
}
