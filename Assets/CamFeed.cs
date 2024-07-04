using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamFeed : MonoBehaviour
{
    
    private WebCamTexture webCamTexture;

    void Start()
    {
        // Find the first available camera
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            webCamTexture = new WebCamTexture(devices[0].name);
            GetComponent<Renderer>().material.mainTexture = webCamTexture;
            webCamTexture.Play();
        }
        else
        {
            Debug.LogError("No webcam found");
        }
    }

    public WebCamTexture GetWebCamTexture()
    {
        return webCamTexture;
    }

    void OnDisable()
    {
        if (webCamTexture != null)
        {
            webCamTexture.Stop();
        }
    }
}