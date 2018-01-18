using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Resource_manager : MonoBehaviour
{
    public GameObject obj;

    private int counter;
    private string folderpath;
    private string[] URL;   // array of URLs of the images
    private ArrayList UniqueURL ;




    // Use this for initialization
    void Start()
    {
        UniqueURL = new ArrayList();
        counter = 0;
        //do something here to initialise the array of all URLs of images.

        URL = new string[1];
        URL[0] = "https://openclipart.org/image/300px/svg_to_png/14546/tonyk-Gnu-Knight.png&disposition=attachment";
        folderpath = Application.persistentDataPath + "/";
      

    }



    void DownloadImages()
    {
        foreach (string current_url in URL)
        {
            if (!Is_exist(current_url))
            {
                StartCoroutine(DownloadSingleImage(current_url));
               
               
            }
        }
        /*
         * www = new WWW(Application.dataPath + "/Resources/a.png");
        yield return www;
        Texture2D tex = new Texture2D(4, 4);
        www.LoadImageIntoTexture(tex);
        cube.GetComponent<Renderer>().material.mainTexture = tex;
        */
    }


    IEnumerator DownloadSingleImage(string url) {
        string filePath  = folderpath + url;          //path of downloaded images
        WWW www = new WWW(url);
        yield return www;
        counter++;
        UniqueURL.Add(url);
        SaveTexture(www, url);
    }

    //save texture to file after downloading
    void SaveTexture(WWW www, string name) {
            Texture2D texture2D = www.texture;     //downloaded images 
            byte[] bytes = texture2D.EncodeToPNG();
            string filePath = folderpath + "a";           //configure path of texture.
        Debug.Log(filePath);
            FileStream filestream = new FileStream(filePath, FileMode.Create);
            filestream.Write(bytes, 0, bytes.Length);
            filestream.Close();
    }

    void LoadImage(string url) {
        WWW www = new WWW(folderpath+"a");
        Texture2D tex = new Texture2D(4,4);
        www.LoadImageIntoTexture(tex);
        obj.GetComponent<Renderer>().material.mainTexture = tex;
    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(240, 100, 150, 25), "LoadTexture"))
        {

            LoadImage("a");
            Debug.Log("Test");

        }

        if (GUI.Button(new Rect(240, 150, 150, 25), "Download Texture"))
        {

            DownloadImages();
            Debug.Log("Test");

        }
    }

    public int getNumberOfImages() {
        return counter;
    }


    private bool Is_exist(string url) {
        if (UniqueURL.Contains(url))
        {
            return true;
        }
        else {
            return false;
           }
    }

}
