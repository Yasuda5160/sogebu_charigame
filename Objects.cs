using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public Vector4 objposworldframe4;
    public Vector3 objposworldframe3;
    public Vector3 objvelworldframe3;
    public Vector4 objvelworldframe4;
    public Vector3 objaccelworldframe3;
    private Vector4 objaccelworldframe4;
    public Vector4 playrposworldframe4;
    public Vector3 playrposworldframe3;


    public Matrix4x4 Lplayer;
    public Matrix4x4 Lobject;
    private Matrix4x4 metrictensor;

    Camera player;
    public GameObject metric;

    PlayerView PlayerView;
    GeneralRelmetric GeneralRelmetric;
    // Start is called before the first frame update
    void Start()
    {
        //importing ArrowDirection for Electromagnetic Effects
        player = Camera.main;
        PlayerView = player.GetComponent<PlayerView>();
        GeneralRelmetric = metric.GetComponent<GeneralRelmetric>();
        //
        playrposworldframe4 = PlayerView.playrposworldframe4;
        playrposworldframe3 = playrposworldframe4;
        //
        objposworldframe3 = this.transform.position;
        objposworldframe4 = objposworldframe3;
        objposworldframe4.w = -(playrposworldframe3 - objposworldframe3).magnitude;
        //objvelworldframe3 = 
        objvelworldframe4 = objvelworldframe3;
        objvelworldframe4.w = 1.0f;
        //objaccelworldframe3 = 
        objaccelworldframe4 = objaccelworldframe3;
        objaccelworldframe4.w = 0.0f;
        //
        Lplayer = PlayerView.Lplayer;
        Lobject = PlayerView.LTrans(objvelworldframe3);
        //
        this.transform.position = Lplayer * objposworldframe4;
    }

    // Update is called once per frame
    void Update()
    {
        Lplayer = PlayerView.Lplayer;
        objvelworldframe3 += objaccelworldframe3 * Time.deltaTime;
        objvelworldframe4 = objvelworldframe3;
        objvelworldframe4.w = Mathf.Sqrt(1f + objvelworldframe3.sqrMagnitude);
        objposworldframe4 += objvelworldframe4 * Time.deltaTime;
        Lobject = PlayerView.LTrans(objvelworldframe3);
        this.transform.position = Lplayer * objposworldframe4;
    }
}
