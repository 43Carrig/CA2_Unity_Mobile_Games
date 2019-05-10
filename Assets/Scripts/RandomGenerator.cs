using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Reference: Random Number Generator - https://www.youtube.com/watch?v=g_KjLe6UmXE

public class RandomGenerator : MonoBehaviour
{
    public GameObject TextBox;
    public int TheNumber;
    
    public void RandomGenerate()
    {
        TheNumber = Random.Range(1, 100000);
        TextBox.GetComponent<Text>().text = "" + TheNumber;
    }

}
