using System.Collections;
using UnityEngine;

public class Velocidad : MonoBehaviour
{
    public int velocidadNueva;
    private float velocidaddAumentada;
    private bool _kitVelocidad = false;

    private PlayerController _player;

    private void Start()
    {
        StartCoroutine(WaitForPlayer());
    }

    private IEnumerator WaitForPlayer()
    {
        // Espera hasta que el jugador esté activo en la escena
        while (_player == null)
        {
            yield return null;
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null && playerObject.activeInHierarchy)
            {
                _player = playerObject.GetComponent<PlayerController>();
            }
        }

        // Una vez que el jugador está disponible, continua con la lógica del script
        if (_player != null)
        {
            VelocidadSupersonica();
        }
    }

    private void VelocidadSupersonica()
    {
        velocidaddAumentada = _player.speed + velocidadNueva;
        _player.VelocidadAumentada(velocidaddAumentada);
        _kitVelocidad = true;
        StartCoroutine(ReactivateAfterDelay());
    }

    private IEnumerator ReactivateAfterDelay()
    {
        yield return new WaitForSeconds(15);
        _kitVelocidad = false;
    }
}
