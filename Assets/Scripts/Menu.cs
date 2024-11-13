using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public Button buttonPause;
    public Button buttonCancel;
    public Button buttonQuitOption;
    
    public Button buttonMenu;
    public Button buttonOption;
    public Button buttonOption2;
    public Button buttonPlay;
    public Button buttonPlay2;
    public Button buttonMusic;
    public Button buttonSon;
    
    public GameObject menu;
    public GameObject pauseMenu;
    public GameObject optionMenu;

    // Start is called before the first frame update
    void Start()
    {
    	// Affichage des menus
        menu.SetActive(false);
        pauseMenu.SetActive(false);
        optionMenu.SetActive(false);
        
        // Affichage des boutons des pages
        buttonPause.gameObject.SetActive(true);
        buttonCancel.gameObject.SetActive(false);
        buttonQuitOption.gameObject.SetActive(false);
        
        // Boutons des pages
        Button btnPause = buttonPause.GetComponent<Button>();
	btnPause.onClick.AddListener(onClickPause);
	Button btnCancel = buttonCancel.GetComponent<Button>();
	btnCancel.onClick.AddListener(onClickCancel);
	Button btnQuitOption = buttonQuitOption.GetComponent<Button>();
	btnQuitOption.onClick.AddListener(onClickQuitOption);
	Button btnMusic = buttonMusic.GetComponent<Button>();
	btnMusic.onClick.AddListener(onClickMusic);
	Button btnSon = buttonSon.GetComponent<Button>();
	btnSon.onClick.AddListener(onClickSon);
	
	// Bontons des menus
	Button btnMenu = buttonMenu.GetComponent<Button>();
	btnMenu.onClick.AddListener(onClickMenu);
	Button btnOptionMenu = buttonOption.GetComponent<Button>();
	btnOptionMenu.onClick.AddListener(onClickOption);
	Button btnOptionMenu2 = buttonOption2.GetComponent<Button>();
	btnOptionMenu2.onClick.AddListener(onClickOption);
	Button btnPlay = buttonPlay.GetComponent<Button>();
	btnPlay.onClick.AddListener(onClickPlay);
	Button btnPlay2 = buttonPlay2.GetComponent<Button>();
	btnPlay2.onClick.AddListener(onClickPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void onClickPause()
    {
        pauseMenu.SetActive(true);
        menu.SetActive(false);
        optionMenu.SetActive(false);

        buttonPause.gameObject.SetActive(false);
        buttonCancel.gameObject.SetActive(true);
        buttonQuitOption.gameObject.SetActive(false);
    }
    
    void onClickCancel()
    {
        pauseMenu.SetActive(false);
        menu.SetActive(false);
        optionMenu.SetActive(false);

        buttonPause.gameObject.SetActive(true);
        buttonCancel.gameObject.SetActive(false);
        buttonQuitOption.gameObject.SetActive(false);
    }
    
    void onClickMenu()
    {
        pauseMenu.SetActive(false);
        menu.SetActive(true);
        optionMenu.SetActive(false);

        buttonPause.gameObject.SetActive(false);
        buttonCancel.gameObject.SetActive(false);
        buttonQuitOption.gameObject.SetActive(false);
    }
    
    void onClickOption()
    {
    	optionMenu.SetActive(true);
    	
        buttonPause.gameObject.SetActive(false);
        buttonCancel.gameObject.SetActive(false);
        buttonQuitOption.gameObject.SetActive(true);
    }
    
    void onClickQuitOption()
    {
        optionMenu.SetActive(false);
        
        buttonPause.gameObject.SetActive(false);
        buttonCancel.gameObject.SetActive(true);
        buttonQuitOption.gameObject.SetActive(false);
    }
    
    void onClickPlay()
    {
        // Start or Restart
    }
    
    void onClickMusic()
    {
        // 
    }
    
    void onClickSon()
    {
        // 
    }
}
