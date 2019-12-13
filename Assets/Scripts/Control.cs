using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{

  public void ComeçarFase1 () {
        // playSound(somClique);
        // Debug.Log("clicou");
        SceneManager.LoadScene("Mapa");

    }
    public void IrMenu () {
        // playSound(somClique);
        // Debug.Log("clicou");
        SceneManager.LoadScene("Menu");

    }

     public void IrInst () {
        //  playSound(somClique);
        // Debug.Log("clicou");
        SceneManager.LoadScene("Instu");

    }

    public static void IrCredito () {
        // playSound(somClique);
        // Debug.Log("clicou");
        SceneManager.LoadScene("Creditos");

    }
}
