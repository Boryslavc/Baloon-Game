using UnityEngine;

public delegate void HappinessAction();
public class ObjectCatcher : MonoBehaviour
{
    //[SerializeField] private GameObject objectToCatch;

    //private bool isCathced = false;

    //public void ReachForAnObject(HappinessAction startHappyStateCallback)
    //{
    //    Vector2 direction = objectToCatch.transform.position - transform.position;
    //    transform.LookAt(objectToCatch.transform,transform.parent.up);

    //    if(isCathced)
    //    {
    //        Catch(startHappyStateCallback);
    //    }
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject == objectToCatch)
    //    {
    //        isCathced=true;
    //    }
    //}
    //private void Catch(HappinessAction startHappyStateCallback)
    //{
    //    startHappyStateCallback();
    //    objectToCatch.transform.parent = this.transform;
    //    startHappyStateCallback();
    //}
}
