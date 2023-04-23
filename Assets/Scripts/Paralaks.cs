using UnityEngine;
using UnityEngine.Tilemaps;

public class Paralaks : MonoBehaviour
{
    public TilemapRenderer tilemapRenderer;
    public float parallaxEffect;

    private float length;
    private float startpos;

    void Start()
    {
        length = tilemapRenderer.bounds.size.x;
        startpos = transform.position.x;
    }

    void Update()
    {
        float temp = (Camera.main.transform.position.x * (1 - parallaxEffect));
        float dist = (Camera.main.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}

