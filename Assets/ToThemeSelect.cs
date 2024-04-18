using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToThemeSelect : MonoBehaviour
{
    public void SelectTheme()
    {
        SceneManager.LoadScene("Select Theme");
    }

    public void Classic()
    {
        SceneManager.LoadScene("PacMan_MH");
    }
}
