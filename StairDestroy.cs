using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairDestroy : MonoBehaviour
{
    private Vector4 Stairpositionworldframe4;
    private Vector3 Stairpositionworldframe3;

    PlayerView PlayerView;
    StairInstantiate StairInstantiate;

    [SerializeField] public GameObject Stair;

    Objects Objects;
    public GameObject Instant;

    Camera player;
    // Start is called before the first frame update
    void Start()
    {
        PlayerView = player.GetComponent<PlayerView>();
        StairInstantiate = Instant.GetComponent<StairInstantiate>();
        Objects = Stair.GetComponent<Objects>();
    }

    // Update is called once per frame
    void Update()
    {
        float section = (PlayerView.playrposworldframe3.z + 20.0f) / 20.0f;
        Vector3 CurrentStairpositionworldframe3 = StairInstantiate.instant2[Mathf.FloorToInt(section)];
        Stairpositionworldframe3 = Objects.objposworldframe3;
        if (Stairpositionworldframe3.z < CurrentStairpositionworldframe3.z)
        {
            Destroy(Stair);
        }
    }
}