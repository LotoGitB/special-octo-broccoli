using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest : MonoBehaviour
{
  //Declaración del arreglo
  //Solo soportan un tipo de dato 
  //Son estructuras estáticas
  //Si declaramos un arreglo como público, podemos verlo en el editor
  public int[] numeros = { 5, 10, 15, 20, 25 };
  void Start()
  {
    //Acceder a una posición específica del arreglo
    Debug.Log(numeros[3]);
    //Acceder a una posición fuera del arreglo
    Debug.Log(numeros[30]);
    //Consultar el tamaño del arreglo
    Debug.Log(numeros.Length);
    //Consultar primer elemento del arreglo
    Debug.Log(numeros[0]);
    //Consultar último elemento del arreglo
    Debug.Log(numeros[numeros.Length - 1]);


  }

  // Update is called once per frame
  void Update()
  {

  }
}
