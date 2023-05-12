using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MenuCtrl : MonoBehaviour
{
  public TextMeshProUGUI monedasText;
  private int conteoMonedas = 0;

  void Start()
  {
    // PlayerPrefs.SetInt("mon",conteoMonedas);
    // PlayerPrefs.GetInt("mon");
    conteoMonedas = PlayerPrefs.GetInt("monedas");
    monedasText.text = conteoMonedas.ToString();

    Alumno adal = new Alumno();
    adal.nombre = "Adalberto Lopez";
    adal.edad = 29;
    adal.altura = 1.75f;
    adal.usaLentes = true;

    //Debug.Log(JsonUtility.ToJson(adal));
    PlayerPrefs.SetString("Alumno", JsonUtility.ToJson(adal));
    //Debug.Log("Contenido del Player Preferences: " + PlayerPrefs.GetString("Alumno"));

    Alumno nuevoAlumno = new Alumno();
    nuevoAlumno = JsonUtility.FromJson<Alumno>(PlayerPrefs.GetString("Alumno"));
    //Debug.Log(nuevoAlumno.nombre);


    //Debug.Log(juan.nombre);
  }

  public Alumno loadAlumnoData()
  {
    Alumno a = new Alumno();
    string path = Application.persistentDataPath + "/alumno.save";
    if (File.Exists(path))
    {
      //LOAD DATA
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);
      a = formatter.Deserialize(stream) as Alumno;
      stream.Close();
    }
    else
    {
      SaveData(a);
    }

    return a;
  }

  public void SaveData(Alumno a)
  {
    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/alumno.save";
    FileStream stream = new FileStream(path, FileMode.Create);
    formatter.Serialize(stream, a);
    stream.Close();
  }
  public void AgregarMonedas()
  {
    conteoMonedas += 10;
  }
  public void LoadCustomScene(int index)
  {
    SceneManager.LoadSceneAsync(index);
  }
}

[System.Serializable]
public class Alumno
{
  public string nombre;
  public int edad;
  public float altura;
  public bool usaLentes;
}
