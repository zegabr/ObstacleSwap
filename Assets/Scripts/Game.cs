using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Game : MonoBehaviour
{
    public static int turno, nPlayers;
    public static Vector3 inicio, castigo, playerPosition, camPosition, initialCamPosition;
    public static Vector3 inicio2;
    private static GameObject cam;
    private static GameObject[] traps;
    private static List<bool> activeTraps;

//----------------template pra adicionar soms
    private AudioSource source;
    //sons aqui, criar uma variavel pra cada efeito sonoro e atualizar via interface unity
    public AudioClip somTitulo;


    void initAudio(){//chamar no start
        source = GetComponent<AudioSource>();
    }

    void playSound(AudioClip soundEffect){//chamar isso qnd quiser tocar sons
        source.PlayOneShot(soundEffect, 1F);
    }
//--------------------------------------------fim do template

    // Start is called before the first frame update
    void Start()
    {
        initAudio();
        playSound(somTitulo);//ele fala "obstacle swaap"
        startGame();
    }

    public static void startGame()
    {
        Debug.Log("Começou o jogo");
        turno = 1;
        nPlayers = 2;
        inicio = new Vector3(-25F, -17.5F, 0);
        inicio2 = new Vector3(-25F, 43.14F, 0);

        castigo = new Vector3(-25F, 43.14F, 0);
        cam = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        initialCamPosition = cam.transform.position;
        setTraps();

        //-------------be aware of gambiarra
        Player aux=GameObject.Find("Player2").GetComponent<Player>();

        aux.switchTurn();
        aux.switchTurn();
        //----------------
        
    }

    public static void nextTurn()
    {
        turno %=nPlayers;
        turno++;
        cam.transform.position = initialCamPosition;
    }

    public static void setPlayerPosition(Vector3 playerPos){
        playerPosition = playerPos;
        moveCamera();
    }

    private static void moveCamera()
    {
        camPosition = cam.transform.position;
        float x = Mathf.Max(-40, playerPosition.x), y = (playerPosition.y + 50  < camPosition.y) ? playerPosition.y + 50 : (playerPosition.y - 3 > camPosition.y) ? playerPosition.y - 3 : camPosition.y;
        cam.transform.position = new Vector3(x, y, camPosition.z);
    }

    private static void setTraps()
    {
        int numOfTraps = GameObject.FindGameObjectsWithTag("activator").Length;
        activeTraps = new List<bool>();
        for(int i = 0; i < numOfTraps; i++)
        {
            activeTraps.Add(false);
        }
        Debug.Log(activeTraps[0]);
    }

    public static bool isTrapActive(int id)
    {
        return activeTraps[id];
    }

    public static void activateTrap(int id)
    {
        activeTraps[id] = true;
    }

    public static void deactivateTrap(int id)
    {
        activeTraps[id] = false;
    }
}
