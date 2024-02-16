using System.Collections;
using UnityEngine;
using DG.Tweening;


public class InBetweenMover : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Transform[] points;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float interval;
    [SerializeField] private float duration;

    private int current = 0;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        transform.position = points[current].position;
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        var wait = new WaitForSeconds(interval);

        while (true)
        {       
            int targetPoint = (current + 1) % points.Length;
            Vector3 startPos = transform.position;
            Vector3 endPos = points[targetPoint].position;

            float time = 0;
            while(time < duration)
            {
                transform.position = Vector3.Lerp(startPos,endPos,curve.Evaluate(time));
                time += Time.deltaTime;
                yield return null;
            }
            sprite.flipX = !sprite.flipX;
            yield return wait;
            current = (current + 1)%points.Length;
        }
    }
}
