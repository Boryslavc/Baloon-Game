using System.Collections;
using UnityEngine;



public class InBetweenMover : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Transform[] points;
    [SerializeField] private float intervalBeforeChangingDirection;
    [SerializeField] private float transitionDuration;

    private int current = 0;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        transform.position = points[current].position;
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        var wait = new WaitForSeconds(intervalBeforeChangingDirection);

        while (true)
        {       
            int targetPoint = (current + 1) % points.Length;
            Vector3 startPos = transform.position;
            Vector3 endPos = points[targetPoint].position;

            float time = 0;
            while(time < transitionDuration)
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
