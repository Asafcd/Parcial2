using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemigoManager : MonoBehaviour
{
    public GameObject Enemigo;
    public int spawnTime;
    public Transform spawnPoint;
    public int currentspawnTime;
    private int previousSpawnTime; 
    public int temporarySpawnTime;
    private Coroutine timeCoroutine;

    private VidaJugador _vidajugador;

    private void Awake()
    {
        //currentspawnTime = spawnTime;
        //_vidajugador = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Invocando Spawn con tiempo inicial: " + spawnTime);
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    public void Spawn()
    {
       // if (_vidajugador.vidaActual <= 0) return;
       // Instantiate(Enemigo, spawnPoint.position, spawnPoint.rotation);
       PhotonNetwork.Instantiate("Enemigo",spawnPoint.position,spawnPoint.rotation);
    }

   
    void Update()
    {
        Debug.Log("Este es el tiempo actual " + currentspawnTime);

        if (Input.GetKeyDown(KeyCode.P))
        {
            spawnTime -= 5;
        }

    }

    public void UpdateTime(int fastTime)
    {
        if (timeCoroutine != null)
        {
            StopCoroutine(timeCoroutine);
        }
        previousSpawnTime = currentspawnTime; 
        currentspawnTime = fastTime;
        timeCoroutine = StartCoroutine(ResetTimeAfterDelay());
    }

    IEnumerator ResetTimeAfterDelay()
    {
        yield return new WaitForSeconds(temporarySpawnTime);
        currentspawnTime = previousSpawnTime;
    }
}

