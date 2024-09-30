using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ContolesController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject returnButton;
    [SerializeField] private GameObject tecladoButton;
    [SerializeField] private GameObject arcadeButton;
    [SerializeField] private GameObject controlesTeclado;
    [SerializeField] private GameObject controlesArcade;
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(returnButton);

    }
    public void ReturnButton()
    {
        SceneManager.LoadScene(0);
    }
    public void TecladoButton()
    {
        controlesArcade.SetActive(false);
        controlesTeclado.SetActive(true);
        EventSystem.current.SetSelectedGameObject(arcadeButton);
    }

    public void ArcadeButton()
    {
        controlesArcade.SetActive(true);
        controlesTeclado.SetActive(false);
        EventSystem.current.SetSelectedGameObject(tecladoButton);
    }


}
