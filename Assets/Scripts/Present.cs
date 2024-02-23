using System;
using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField] private Vector3 startForceDirection;
    [SerializeField] private float forceMultiplier;
    [SerializeField] private ParticleSystem poppedEfect;
    [SerializeField] public GameObject baloon;

    public event Action<bool> OnSessionWon;

    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void StartMoving()
    {
        rigidbody.AddForce(startForceDirection * forceMultiplier);
    }
    private void Update()
    {
        if (transform.position.y < -50f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("SharpObject"))
        {
            DestroyBaloon();
        }
        else if(collision.gameObject.CompareTag("Girl"))
        {
            OnSessionWon?.Invoke(true);
        }
    }

    private void DestroyBaloon()
    {
        OnSessionWon?.Invoke(false);
        baloon.SetActive(false);
        rigidbody.gravityScale = 2;
        poppedEfect.Play();
    }
}
