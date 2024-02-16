using UnityEngine;

public class WindForce : MonoBehaviour
{
    [SerializeField] private ParticleSystem windEffect;

    private void OnEnable()
    {
        windEffect.Play();
    }
    private void Update()
    {
        if (windEffect.isStopped)
        {
            gameObject.SetActive(false);
        }
    }
}
