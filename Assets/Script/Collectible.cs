using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public int pointValue = 1;
    [SerializeField] private AudioClip soundEffect;
    [SerializeField] private float volume = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(soundEffect, transform.position, volume);
            ScoreManagement.instance.AddPoint(pointValue);
            Destroy(gameObject);
        }
    }
}
