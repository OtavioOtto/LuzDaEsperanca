using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button restartButton;
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
