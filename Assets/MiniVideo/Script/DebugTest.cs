using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    //Imprimir mensaje de texto
    // Debug.Log("Mensaje de tipo Log informativo");
    // Debug.LogWarning("Mensaje de tipo Log Warning");
    // Debug.LogError("Mensaje de tipo Log Error");

    // //Imprimir valor de variable simple
    // int edad = 29;
    // Debug.Log(edad);
    // //Imprimir datos complejos
    // Instruccion inst = new Instruccion();
    // //Imprime un dato especifico del objeto
    // Debug.Log(inst.titulo);
    // //Imprime el objeto sin exito
    // Debug.Log(inst);
    // //Imprimelo con una conversión a JSON para leerlo adecuadamente
    // Debug.Log(JsonUtility.ToJson(inst));

    //Debug Assert
    //Manda el mensaje a consola, si y solo si, la condición indicada como primer parametro se cumple
    // bool isWalking = false;
    // Debug.Assert(isWalking,"No esta caminando");
    // isWalking = true;
    // Debug.Assert(isWalking,"Si esta caminando");

    // //Debug Break
    // //Este tipo de Debug Realiza una interrupción al código para que deje de ejecutarse
    // Debug.Break();
  }
}

public class Instruccion
{
  public int id;
  public string titulo;
  public string descripcion;
  public int imageArrayIndex;
  public bool disableRotation;

  public Instruccion()
  {
    this.id = 1;
    this.titulo = "Titulo del objeto Instrucción";
    this.descripcion = "Descripción del objeto Instrucción";
    this.imageArrayIndex = 1;
    this.disableRotation = false;
  }
}