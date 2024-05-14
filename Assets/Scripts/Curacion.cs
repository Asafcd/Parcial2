using System.Collections;
using UnityEngine;

public class Curacion : MonoBehaviour
{
    public int curacion;
    private VidaJugador _vidajugador;
    private GameObject player;
    private bool _KitConsume = false;

    private void Start()
    {
        StartCoroutine(WaitForPlayer());
    }

    private IEnumerator WaitForPlayer()
    {
        // Espera hasta que el jugador esté activo en la escena
        while (_vidajugador == null)
        {
            yield return null;
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null && playerObject.activeInHierarchy)
            {
                _vidajugador = playerObject.GetComponent<VidaJugador>();
            }
        }

        // Una vez que el componente VidaJugador está disponible, continua con la lógica del script
        if (_vidajugador != null)
        {
            // Realiza acciones adicionales si es necesario
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_KitConsume)
        {
            CuracionKit();
        }
    }

    private void CuracionKit()
    {
        if (_vidajugador.vidaActual < _vidajugador.vidaInicial)
        {
            _vidajugador.Medicina(curacion);
            _KitConsume = true;
            StartCoroutine(ReactivateAfterDelay());
        }
    }

    private IEnumerator ReactivateAfterDelay()
    {
        yield return new WaitForSeconds(15);
        _KitConsume = false;
    }
}
