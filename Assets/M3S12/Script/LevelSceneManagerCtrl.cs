using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManagerCtrl : MonoBehaviour
{
  public TextMeshProUGUI monedasText;
  public int puntosAgregar;
  private int conteoMonedas;

  void Start()
  {
    //DontDestroyOnLoad(mainCanvas);
    conteoMonedas = PlayerPrefs.GetInt("monedas");
    conteoMonedas += puntosAgregar;
    monedasText.text = conteoMonedas.ToString();
    PlayerPrefs.SetInt("monedas", conteoMonedas);
  }
  public void LoadMenuScene()
  {
    SceneManager.LoadSceneAsync(0);
  }
}
