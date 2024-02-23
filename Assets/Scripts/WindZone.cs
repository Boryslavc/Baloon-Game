using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField] private float forceMultiplier;
    [SerializeField] private Vector2 direction;

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.attachedRigidbody.AddForce(direction * forceMultiplier,ForceMode2D.Force);
    }
}
