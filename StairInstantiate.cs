using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairInstantiate : MonoBehaviour
{
    private float i;
    public List<Vector3> instant2= new List<Vector3>();
    // 弾のPrefabを指定
    public GameObject Stairs;
    private GameObject GameObject;
    PlayerView cameraMove2;
    Objects Objects;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cameraMove2 = cam.GetComponent<PlayerView>();
        Objects = Stairs.GetComponent<Objects>();
        Debug.Log($"i={i}");
        GameObject = Stairs;
        Instantiate(Stairs, new Vector3(0.0f, -4.0f, 0.0f), transform.rotation);
        instant2.Add(new Vector3(0.0f, -4.0f, 0.0f));
        for (int i = 1; i < 100; i++)
        {
            float y = -3.0f + Random.Range(-5.0f, 3.0f);
            instant2.Add(new Vector3(0.0f, y, 40.0f * i));
            Debug.Log($"y={y}");
            Vector3 positionworld3 = instant2[Mathf.FloorToInt(i)];
            Debug.Log($"positionworld3={positionworld3}");
            Vector4 positionworld4 = positionworld3;
            Debug.Log($"positionworld4={positionworld4}");
            positionworld4.w = cameraMove2.playrposworldframe4.w - (cameraMove2.playrposworldframe3 - positionworld3).magnitude;
            Debug.Log($"positionworld4.w={positionworld4.w}");
            Vector4 positionrest4 = cameraMove2.Lplayer * positionworld4;
            Vector3 positionrest3 = positionrest4;
            Debug.Log($"positionrest3={positionrest3}");
            Instantiate(GameObject, positionworld3, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}