using UnityEngine;

public class SeedPacket : MonoBehaviour
{
    private Plant _plant;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Plant Plant { get => _plant; }

    void Start()
    {
        _plant = GetComponentInChildren<Plant>();
    }
}
