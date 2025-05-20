using UnityEngine;
using UnityEngine.Assertions;

public class SeedPacket : MonoBehaviour
{
    private Plant _plant;

    public void Start()
    {
        _plant = GetComponent<Plant>();
        Assert.IsNotNull(_plant);
    }
}
