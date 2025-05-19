using UnityEngine;

public class SeedMenu : MonoBehaviour
{
    private SeedPacket[] _seedPackets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _seedPackets = GetComponentsInChildren<SeedPacket>();
        for (int i = 0; i < _seedPackets.Length; i++)
        {
            Debug.Log(_seedPackets[i].Plant);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
