using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Resource_manager : MonoBehaviour {
    public GameObject cube;

    private WWW www;                     //request


    private string[] URL;   // array of URLs of the image



    // Use this for initialization
    void Start()
    {
        //do something here to initialise the array of all URLs of images.

        URL = new string[1];
        URL[0] = "https://forum.unity.com/attachments/unity3d-png.177351/";

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
            filePath = Application.dataPath + "/Resources/a";           //configure path of texture.
            FileStream filestream = new FileStream(filePath, FileMode.Create,FileAccess.ReadWrite);
            for (int i = 0; i < bytes.Length; i++)
            {
                filestream.WriteByte(bytes[i]);
            }
        }
        cube.GetComponent<Renderer>().material.mainTexture = Resources.Load("a") as Texture;


        /*
         * www = new WWW(Application.dataPath + "/Resources/a.png");
        yield return www;
        Texture2D tex = new Texture2D(4, 4);
        www.LoadImageIntoTexture(tex);
        cube.GetComponent<Renderer>().material.mainTexture = tex;
        */
    }

}
