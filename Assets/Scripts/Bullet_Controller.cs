using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    private Vector2 target;
    public float speed;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Belirli bir süre sonra mermiyi yok et
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eğer mermi düşmana veya duvara çarptıysa yok et
        if (collision.CompareTag("Enemy") || collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}

