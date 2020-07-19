using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public Camera cam;
    public float parallaxEffect;

    private void Start ()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update ()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
            
        if (temp > startpos + length)
            startpos += length;
        else if (temp < startpos - length)
            startpos -= length;

    }
}
