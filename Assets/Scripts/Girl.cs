using DG.Tweening;
using UnityEngine;

public class Girl : MonoBehaviour
{
    [SerializeField] private ParticleSystem loveEffect;
    [SerializeField] private Vector3 presentLocation;
    [SerializeField] private float duration;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Present"))
        {
            loveEffect.Play();
            collision.gameObject.transform.DOMove(presentLocation, duration);
        }
    }
}
