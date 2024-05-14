using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public int BrincoNuevo;
    private float BrincoAumentado;
    private bool _kitBrinco = false;

    private PlayerController _player;

    private void Start()
    {
        StartCoroutine(WaitForPlayer());
    }

    private IEnumerator WaitForPlayer()
    {
        while (_player == null)
        {
            yield return null;
            _player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerController>();
        }

        // Una vez que se encuentra el jugador, continúa con la lógica del script
        if (_player != null)
        {
            // Puedes activar otros componentes o realizar acciones adicionales aquí
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_kitBrinco)
        {
            BrincoAlmas();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Realizar acciones adicionales si es necesario
        }
    }

    private void BrincoAlmas()
    {
        BrincoAumentado = _player.forceJump + BrincoNuevo;
        _player.BrincoAumentado(BrincoAumentado);
        _kitBrinco = true;
        StartCoroutine(ReactivateAfterDelay());
    }

    private IEnumerator ReactivateAfterDelay()
    {
        yield return new WaitForSeconds(15);
        _kitBrinco = false;
    }
}
