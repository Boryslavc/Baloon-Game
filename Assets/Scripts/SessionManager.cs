using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;

    [SerializeField] private Present Present;
    [SerializeField] private PlayerObserver PlayerObserver;

    private int currentSceneNumber;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(StartSession());
        currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    private IEnumerator StartSession()
    {
        PlayerObserver.StartCameraSpanCoroutine();
        float waitTime = PlayerObserver.levelPreviewDuration;
        yield return new WaitForSeconds(waitTime);
        Present.StartMoving();
    }
    public void LoadNextLevel()
    {
        if(currentSceneNumber < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(currentSceneNumber+1);
    }
    public void RetryLevel()
    {
        SceneManager.LoadScene(currentSceneNumber);
    }
    public void ExitApplication()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
