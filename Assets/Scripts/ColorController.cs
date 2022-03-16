using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    private byte[] justHairBytes;
    private GameObject hair;
    private Texture2D texture2D;
    private void Start()
    {
        var directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        Debug.Log("Streaming Assets Path: " + Application.streamingAssetsPath);
        var  allFiles = directoryInfo.GetFiles("*.*");
        Debug.Log( justHairBytes);
        foreach (var fileInfo in allFiles)
        {
            if (fileInfo.Name.Contains("meta"))
            {
                continue;
            }
            justHairBytes = File.ReadAllBytes(fileInfo.FullName);
            texture2D = new Texture2D(1, 1);
        }
    }

    private void SetColor()
    {
        var meshRenderer = hair.GetComponent<SkinnedMeshRenderer>();
        meshRenderer.sharedMaterial.mainTexture = texture2D;
    }
    
    

   
}
