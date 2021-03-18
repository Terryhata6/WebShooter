using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
    public LvlPreset[] AllLvlPresets;

    private Spawner _spawner;
    private Counter _counter;
    private UIController _uiController;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
        _counter = FindObjectOfType<Counter>();
        _uiController = FindObjectOfType<UIController>();
    }
    private void Start()
    {
        _spawner.StartSpawner(AllLvlPresets[Random.Range(0, AllLvlPresets.Length)]);
    }
    public void EndGame()
    {
        _uiController.ActivateWinPanel();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
