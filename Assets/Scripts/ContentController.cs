using UnityEngine;

public class ContentController : MonoBehaviour {

    public API api;
    public Shader shader;

    void Start()
    {
        string IP = DataKeeper.IP;
        bool diff = DataKeeper.difficulty;
        Debug.Log(diff);
        Debug.Log(IP);
        shader = Shader.Find("Standard");
        LoadContent();

    }
    public void LoadContent() {
        DestroyAllChildren();
        api.GetBundleObject(name, OnContentLoaded, transform);
    }

    void OnContentLoaded(GameObject content) {
        
        this.gameObject.GetComponentInChildren<Renderer>().material.shader = shader;
        Debug.Log("Loaded: " + content.name);

    }

    void DestroyAllChildren() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
}