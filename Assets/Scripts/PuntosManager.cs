using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosManager : MonoBehaviour
{
    public TextMeshProUGUI textPuntos;
    public static int puntos;

    // Start is called before the first frame update
    private void  Awake()
    {
        puntos = 0;
    }
    

    // Update is called once per frame
    void Update()
    {
        textPuntos.text = "Score" + puntos;
    }
}
