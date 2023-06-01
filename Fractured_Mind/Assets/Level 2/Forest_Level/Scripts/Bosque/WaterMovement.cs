using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float speed = 0.01f; // Speed of the animation
    private Material material; // Reference to the material component

    private IEnumerator Start()
    {
        material = GetComponent<Renderer>().material; // Get the material component from the plane

        while (true)
        {
            float offset = material.mainTextureOffset.x;
            offset -= speed;

            if (offset < -1f)
                offset += 1f;

            material.mainTextureOffset = new Vector2(offset, 0f);
            yield return new WaitForSeconds(0.8f);
        }
    }
}
