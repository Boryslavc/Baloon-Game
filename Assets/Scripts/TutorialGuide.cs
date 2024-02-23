using UnityEngine;

public class TutorialGuide : MonoBehaviour
{
    [SerializeField] private float[] tipPoints;
    [SerializeField] private Transform objectToGuide;
    [Header("Tip images")]
    [SerializeField] private GameObject[] tipsUI;

    private int nextTipNumber = 0;
    private bool isApproachingNewTip =>
        Mathf.Abs(objectToGuide.position.y - tipPoints[nextTipNumber]) < 0.2f;

    private void Start()
    {
        foreach (var tip in tipsUI)
            tip.SetActive(false);
    }
    private void Update()
    {
        MonitorLevelProgression();
    }

    private void MonitorLevelProgression()
    {
        if(nextTipNumber <  tipPoints.Length)
        {
            if (objectToGuide != null && isApproachingNewTip)
            {
                Time.timeScale = 0;
                tipsUI[nextTipNumber].SetActive(true);
            }
        }
    }

    public void DisableTip()
    {
        tipsUI[nextTipNumber].SetActive(false);
        nextTipNumber++;
        Time.timeScale = 1;
    }
}
