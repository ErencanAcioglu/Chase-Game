using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Topun hareket hızı
    public float boundary = 5.0f; // Yüzeyin sınırları

    private Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero; // Hareket yönü
    private bool isMoving = false; // Tuşa basılıp basılmadığını kontrol etmek için

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Klavyedeki tuşlara basıldığında hareket yönünü belirle
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        // Tuşa basıldıysa hareket başlat
        if (moveDirection != Vector3.zero)
        {
            isMoving = true;
        }
        // Tuşa basılmadıysa hareketi durdur
        else
        {
            isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        // Topun hareketi
        if (isMoving)
        {
            rb.velocity = moveDirection * speed;
        }
        else
        {
            rb.velocity = Vector3.zero; // Tuşa basılmadığında hızı sıfırla
        }

        // Topun pozisyonunu sınırla
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -boundary, boundary);
        currentPosition.z = Mathf.Clamp(currentPosition.z, -boundary, boundary);
        transform.position = currentPosition;
    }
}
