using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [SerializeField] private int poolSize;
    [SerializeField] private WindForce windForcePrefab;

    private List<WindForce> windForceList = new List<WindForce>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        InitializeList();
    }

    private void InitializeList()
    {
        for(int i = 0; i < poolSize; i++)
        {
            var windForce = Instantiate(windForcePrefab);
            windForce.gameObject.SetActive(false);
            windForceList.Add(windForce);
        }
    }
    public WindForce GetWindForce()
    {
        for(int i = 0; i < windForceList.Count; i++)
        {
            if(!windForceList[i].gameObject.activeInHierarchy)
            {
                return windForceList[i];
            }
        }
        return null;
    }
}
