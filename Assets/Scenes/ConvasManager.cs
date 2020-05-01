using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvasManager : MonoBehaviour
{
    public GameObject OldCanvas;

    // Start is called before the first frame update
    void Start()
    {
        OldCanvas.SetActive(false);
    }
}
