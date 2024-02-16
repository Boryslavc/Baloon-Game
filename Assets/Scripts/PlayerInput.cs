using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private void Update()
    {
        CheckPlayerInput();
    }
    private void CheckPlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = CalculatePosition();
            CreateWindForce(mousePosition);
        }
    }
    // need to return vector 2 so thatwhen unity converts it to vector 3
    // z value equals zero,
    // otherwise windForce is redered outside of the camera frustrum
    private Vector2 CalculatePosition()
    {
        Vector2 position = Input.mousePosition;
        return camera.ScreenToWorldPoint(position);
    }
    private void CreateWindForce(Vector2 position)
    {
        var windForce = ObjectPooler.Instance.GetWindForce();
        windForce.transform.position = position;
        windForce.gameObject.SetActive(true);
    }
}
