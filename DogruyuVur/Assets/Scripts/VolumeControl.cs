using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    private void Start()
    {
        VolumeOn();
    }
    public void VolumeOn()
    {
        PlayerPrefs.SetInt("volume", 1);
    }
    public void VolumeOff()
    {
        PlayerPrefs.SetInt("volume", 0);
    }
}
