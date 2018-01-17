using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class resource_manager : MonoBehaviour {

    private WWW www;                     //request


    private string[] URL;   // array of URLs of the image



    // Use this for initialization
    void Start()
    {
        //do something here to initialise the array of all URLs of images.



        StartCoroutine(Download());

    }



    IEnumerator Download()
    {
        Texture2D texture2D;         //downloaded images
        string filePath;             //path of downloaded images
        foreach (string current_url in URL) {
            //download
            www = new WWW(current_url);
            yield return www;

            //save texture to file after downloading
            texture2D = www.texture;
            byte[] bytes = texture2D.EncodeToPNG();
            filePath = Application.dataPath + "/resources/" + current_url;           //configure path of texture.
            File.WriteAllBytes(filePath, bytes);
        }
    }

}
