using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadingSound : MonoBehaviour
{
    [Header("id Obiektu")]
    public int id = 0;
    public int id_scena = 0;
    private AudioClip _audio; 
    private AudioSource audioSource;

    IEnumerator DownloadSound(string soundurl)
    {
        UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(soundurl,AudioType.MPEG); 
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success) {
            Debug.Log(request.error);
        }
        else
            audioSource.clip = DownloadHandlerAudioClip.GetContent(request);
    }
    IEnumerator setSound()
    {
        bool diff = DataKeeper.difficulty;
        Debug.Log(diff);
        string IP = DataKeeper.IP;
        
        string soundurl = "";
        if(diff)
        {
        soundurl = "http://" + IP + "/unity/scene"+ (id_scena) +"/soundsExpert/sound" + (id) + ".mp3";
        }else
        {
        soundurl = "http://" + IP + "/unity/scene"+ (id_scena) +"/soundsBeginner/sound" + (id) + ".mp3";
        }

        yield return StartCoroutine(DownloadSound(soundurl));
        
    }
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(setSound());
    }
}