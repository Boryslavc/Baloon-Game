using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField] private float ForceMultiplier;
    [SerializeField] private Vector2 Direction;

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.attachedRigidbody.AddForce(Direction * ForceMultiplier,ForceMode2D.Force);
    }
}
