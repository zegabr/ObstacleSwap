using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{

  public void ComeçarFase1 () {
        SceneManager.LoadScene("Mapa");

    }
    public void IrMenu () {
        SceneManager.LoadScene("Menu");

    }

     public void IrInst () {
        SceneManager.LoadScene("Instu");

    }

    public static void IrCredito () {
        SceneManager.LoadScene("Creditos");

    }
    public void IrCreditoviaMenu () {
        SceneManager.LoadScene("Creditos");

    }
}
