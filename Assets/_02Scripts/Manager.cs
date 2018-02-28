using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private void Start()
    {
        Config newConfig = ConfigManager.M_Config;
        Debug.Log(newConfig.address);
        Debug.Log(newConfig.ID);
        Debug.Log(newConfig.isMale);
        Debug.Log(newConfig.value);
    }
}
