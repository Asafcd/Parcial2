using System.Collections;
using UnityEngine;

public class DañoAumento : MonoBehaviour
{
    public int aumento;
    private int aumentoDaño;
    private Shoot _shoot;
    private GameObject player;
    private bool _kitDamage = false;

    private void Start()
    {
        StartCoroutine(WaitForPlayer());
    }

    private IEnumerator WaitForPlayer()
    {
        // Espera hasta que el jugador esté activo en la escena
        while (_shoot == null)
        {
            yield return null;
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null && playerObject.activeInHierarchy)
            {
                _shoot = playerObject.GetComponent<Shoot>();
            }
        }

        // Una vez que el componente Shoot está disponible, continua con la lógica del script
        if (_shoot != null)
        {
            AumentoDaño();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_kitDamage)
        {
            AumentoDaño();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Realizar acciones adicionales si es necesario
        }
    }

    private void AumentoDaño()
    {
        aumentoDaño = _shoot.damege + aumento;
        _shoot.AumentoD(aumentoDaño);
        _kitDamage = true;
        StartCoroutine(ReactivateAfterDelay());
    }

    private IEnumerator ReactivateAfterDelay()
    {
        yield return new WaitForSeconds(15);
        _kitDamage = false;
    }
}
