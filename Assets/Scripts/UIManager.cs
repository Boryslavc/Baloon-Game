using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private Present present;

    private void Start()
    {
        present.OnSessionWon += LoadGameOverPanel;
        winPanel.SetActive(false);
        lostPanel.SetActive(false);
    }
    private void LoadGameOverPanel(bool playerHasWon)
    {
        if (playerHasWon)
            winPanel.SetActive(true);
        else 
            lostPanel.SetActive(true);
    }
}
