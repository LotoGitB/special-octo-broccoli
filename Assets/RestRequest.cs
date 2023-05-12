using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class RestRequest : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(GetWebServiceData());
  }

  IEnumerator GetWebServiceData()
  {
    Debug.Log("Enviando Petición");
    using (UnityWebRequest webRequest = UnityWebRequest.Get("https://newsapi.org/v2/everything?q=tesla&pageSize=2&from=2023-04-12&sortBy=publishedAt&apiKey=1bef2dc105b346eca8188479e8a0c8cb"))
    {
      yield return webRequest.SendWebRequest();

      if (webRequest.result != UnityWebRequest.Result.Success)
      {
        Debug.Log("Error al obtener datos: " + webRequest.error);
      }
      else
      {
        string responseData = webRequest.downloadHandler.text;
        Debug.Log(responseData);
      }
    }
  }

}
