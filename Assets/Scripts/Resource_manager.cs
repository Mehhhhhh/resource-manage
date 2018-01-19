using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading;
using System;

public class Resource_manager : MonoBehaviour
{
    private int counter;                 //number of images
    private string folderpath;            
    private string[] URL;              // array of URLs 
    private Dictionary<string, int> UniqueURL;          // all the unique urls and the numbers of their corresponding image
    private const int NumberOfUrls = 4;              //number of the given URLs 
    const int NUMBEROFTHREADS = 5;



    // Use this for initialization
    void Start()
    {
        //initialization
        UniqueURL = new Dictionary<string, int>();
        counter = 0;
        //do something here to initialise the array of all URLs of images.
        URL = new string[NumberOfUrls];
        URL[0] = "https://openclipart.org/image/300px/svg_to_png/14546/tonyk-Gnu-Knight.png&disposition=attachment";
        URL[1] = "https://static.wixstatic.com/media/2cd43b_9e40d284910240479b94e37f071f702a~mv2.png/v1/fill/w_196,h_177,al_c,usm_0.66_1.00_0.01/2cd43b_9e40d284910240479b94e37f071f702a~mv2.png";
        URL[2] = "http://www.pngmart.com/files/4/Nature-PNG-Free-Download.png";
        URL[3] = "http://www.pngmart.com/files/4/Nature-PNG-Free-Download.png";
        folderpath = Application.persistentDataPath + "/texture";
      

    }


    /*
     * Download images from the list of given URLs, if the URL is already existed, then load the coresponding image instead of downloading.
     */
    void DownloadImages()
    {
        foreach (string current_url in URL)
        {
            if (!Is_exist(current_url))
            {
                StartCoroutine(DownloadSingleImage(current_url));


            }
            else {
                LoadImage(UniqueURL[current_url]);
            }
        }
    }


    /*
     * download the image with given Url, then save the texture on the device
     */
    IEnumerator DownloadSingleImage(string url) {
        counter++;
        UniqueURL.Add(url, counter);
        string filePath  = folderpath + url;          
        WWW www = new WWW(url);
        yield return www;
        SaveTexture(www, url);
    }

    /*
     * save texture to file after downloading
     */
    void SaveTexture(WWW www, string name) {
            Texture2D texture2D = www.texture;     
            byte[] bytes = texture2D.EncodeToPNG();
            string filePath = folderpath + UniqueURL[name];           //configure path of texture.
            Debug.Log(filePath);
            FileStream filestream = new FileStream(filePath, FileMode.Create);
            filestream.Write(bytes, 0, bytes.Length);
            filestream.Close();
    }


    /*
     * load the selected image and set it as the texture of a generated gameobject, can be seen from game view.
     */
    void LoadImage(int n) {
        if (File.Exists(folderpath + n.ToString()))
        {
            byte[] bytes = File.ReadAllBytes(folderpath + n.ToString());
            Texture2D tex = new Texture2D(1, 1);
            tex.LoadImage(bytes);

            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3(n, n, 0);
            sphere.GetComponent<Renderer>().material.mainTexture = tex;
            Debug.Log("loaded");
        }
        else { }
        Debug.Log("not saved yet");

       
    }

    /*
     * buttons to do the downloading and loading operations.
     */ 
    void OnGUI()
    {
        if (GUI.Button(new Rect(240, 150, 150, 25), "LoadTexture"))
        {
            for (int i = 1; i <= counter; i++)
            {
                LoadImage(i);
                Debug.Log("loading" + i);
            }

        }

        if (GUI.Button(new Rect(240, 100, 150, 25), "Start download textures"))
        {

            DownloadImages();
            Debug.Log("download");

        }
    }

    /*
     * function used to detect if an Url has already been used to download image
     */ 
    private bool Is_exist(string url) {
        if (UniqueURL.ContainsKey(url))
        {
            return true;
        }
        else {
            return false;
           }
    }




}
