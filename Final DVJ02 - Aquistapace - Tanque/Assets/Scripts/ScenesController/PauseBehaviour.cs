using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject controlsScreen;

    bool pauseState;

    private void Awake()
    {
        DisablePause();
    }

    void Update()
    {
        InputPause();
    }

    void InputPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && player.GetComponent<PlayerStats>().pState == PlayerStats.State.Playing)
        {
            pauseState = !pauseState;

            if(pauseState == true)
            {
                ActivatePause();
            }
            else
            {
                DisablePause();
            }
        }
    }

    public void ActivatePause()
    {
        pauseScreen.SetActive(true);

        Time.timeScale = 0f;
    }

    public void DisablePause()
    {
        pauseScreen.SetActive(false);

        Time.timeScale = 1f;
    }

    public void RestartAndDisablePause(string scene)
    {
        pauseScreen.SetActive(false);

        Time.timeScale = 1f;

        SceneManager.LoadScene(scene);
    }
}