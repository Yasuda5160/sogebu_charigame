using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doppler : MonoBehaviour
{
    private Matrix4x4 Linv;
    Camera cam;
    PlayerView c;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        c = cam.GetComponent<PlayerView>();
        Linv = c.Lplayer.inverse;
        /*Output of this Lorentz matrix is on debug console*/
        Debug.Log($"lmat = {Linv}");
    }

    // Update is called once per frame
    void Update()
    {
        Linv = c.Lplayer.inverse;
        Shader.SetGlobalMatrix("L", Linv);
        Debug.Log($"lmat = {Linv}");
    }
}