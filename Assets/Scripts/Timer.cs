using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    #region Variables

    public GameObject manager1;
    public GameObject manager2;

    public Player player;
    public TMP_Text LoseText;
    public Button restartButton;
    private TMP_Text _timerText;
    
    enum TimerType {Countdown, Stopwatch}
    [SerializeField] private TimerType timerType;

    [SerializeField] private float timeToDisplay = 60.0f;

    private bool _isRunning;

    #endregion
    
    private void Awake() => _timerText = GetComponent<TMP_Text>();
    
    private void Start()
    {
        // Register the button click event to call RestartGame
        restartButton.onClick.AddListener(RestartScene);
    }

    private void OnEnable()
    {
        EventManager.TimerStart += EventManagerOnTimerStart;
        EventManager.TimerStop += EventManagerOnTimerStop;
        EventManager.TimerUpdate += EventManagerOnTimerUpdate;
        LoseText.enabled = false;
        restartButton.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.TimerStart -= EventManagerOnTimerStart;
        EventManager.TimerStop -= EventManagerOnTimerStop;
        EventManager.TimerUpdate -= EventManagerOnTimerUpdate;
    }

    private void EventManagerOnTimerStart() => _isRunning = true;
    private void EventManagerOnTimerStop() => _isRunning = false;
    private void EventManagerOnTimerUpdate(float value) => timeToDisplay += value;
    
    public void RestartScene()
    {
        // Reloads the current active scene
        Time.timeScale = 1;
        Destroy(manager1);
        Destroy(manager2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        

        
    }
    private void Update()
    {

        if (!_isRunning) return;
        if (timerType == TimerType.Countdown && timeToDisplay < 0.0f)
        {
            LevelManager.Instance.PlayerExitZone();
            EventManager.OnTimerStop();
            LoseText.enabled = true;
            restartButton.gameObject.SetActive(true);
            Time.timeScale = 0;

            return;
        }
        
        timeToDisplay += timerType == TimerType.Countdown ? -Time.deltaTime : Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        _timerText.text = timeSpan.ToString(@"mm\:ss\:ff");
    }
    
    // public float timer =  60.0f;
    //
    //
    // [SerializeField] TextMeshProUGUI timerText;
    //
    //
    // private void Start() {
    //     StartCoroutine("Timing");
    // }
    //
    // private void Update()
    // {
    //     timer -= Time.deltaTime;
    //     timerText.text = timer.ToString();
    //
    //     if (timer <= 0.0f)
    //     {
    //         Debug.Log("You lost");
    //     }
    // }
    // IEnumerator Timing() {
    //
    //     while (timer>0) {
    //
    //
    //
    //         yield return new WaitForSeconds(1f);
    //
    //         timer--;
    //
    //         timerText.text = timer.ToString();
    //
    //
    //     }
    //
    //     Debug.Log("You lost");
    //
    //
    // }


}
