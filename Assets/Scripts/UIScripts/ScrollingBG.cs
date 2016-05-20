using UnityEngine;

public class ScrollingBG : MonoBehaviour {

    public Vector2 ScrollDirection;
    public float Speed = 1;

    Material mMaterial;

	// Use this for initialization
	void Start ()
    {
        mMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        offset += ScrollDirection * Speed * Time.deltaTime;
        mMaterial.SetTextureOffset("_MainTex", offset);
	}

    private Vector2 offset;
}
