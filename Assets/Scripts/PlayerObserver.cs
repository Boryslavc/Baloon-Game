using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PlayerObserver : MonoBehaviour
{

    [SerializeField] private float[] yPositions;
    [Header("Transition between viewpoints")]
    [SerializeField] private float transitionDuration;
    [SerializeField] private Present present;
    public float levelPreviewDuration { get; private set; } = 3f;

    private int currentYPositionNumber = 0;
    private BoxCollider2D[] boxCollider2Ds;
    private void Start()
    {
        transform.position = new Vector3(0, yPositions[currentYPositionNumber], -10);
        boxCollider2Ds = GetComponents<BoxCollider2D>();
        ChageBottomColliderState(false);
        present.OnSessionWon += ChageBottomColliderState;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Present"))
        {
            MoveUp();
        }
    }
    private void MoveUp()
    {
        if(currentYPositionNumber < yPositions.Length)
        {
            transform.DOMoveY(yPositions[currentYPositionNumber], transitionDuration);
            currentYPositionNumber++;
        }
    }
    public void StartCameraSpanCoroutine()
    {
        StartCoroutine(LevelCameraSpan());
    }
    public IEnumerator LevelCameraSpan()
    {
        Vector3 destination = new Vector3(0, yPositions[yPositions.Length - 1], -10);
        Vector3 current = new Vector3(0, yPositions[0], -10);
        float time = 0;
        float timeInterpolator = time / transitionDuration;
        while (timeInterpolator < 1)
        {
            transform.position = Vector3.Lerp(current, destination, timeInterpolator);
            time += Time.deltaTime;
            timeInterpolator = time / transitionDuration;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        current = new Vector3(0, yPositions[yPositions.Length - 1], -10);
        destination = new Vector3(0, yPositions[0], -10);
        time = 0;
        timeInterpolator = time / transitionDuration;
        while (timeInterpolator < 1)
        {
            transform.position = Vector3.Lerp(current, destination, timeInterpolator);
            time += Time.deltaTime;
            timeInterpolator = time / transitionDuration;
            yield return null;
        }
        ChageBottomColliderState(true);
    }
    private void ChageBottomColliderState(bool shouldBeEnabled)
    {
         boxCollider2Ds[1].enabled = shouldBeEnabled;
    }
}
