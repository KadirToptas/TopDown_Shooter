using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private Transform playerPos;
    public float speed;
    private int health = 3;

    // Öldüğünde oluşacak sprite ve ses
    public GameObject enemyDeadPrefab;
    public AudioClip deathSound;
    private AudioSource audioSource;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

        if (health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            health--;
        }
    }

    private void Die()
    {
        Instantiate(enemyDeadPrefab, transform.position, Quaternion.identity);

        // Ölüm sesini çal
        audioSource.PlayOneShot(deathSound);

        Destroy(gameObject);
    }
}


