using DG.Tweening;
using System;
using UnityEngine;

public class Girl : MonoBehaviour
{
    [SerializeField] private ParticleSystem loveEffect;
    [SerializeField] private Vector3 presentLocation;
    [SerializeField] private float duration;

    //[SerializeField] private ObjectCatcher catcher;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Present"))
        {
            //catcher.ReachForAnObject(Celebrate);
            loveEffect.Play();
            collision.gameObject.transform.DOMove(presentLocation, duration);
        }
    }
}
