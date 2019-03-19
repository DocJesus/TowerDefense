using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool canMove = true;

    public float panSpeed = 30f;
    public float panBorder = 20f;
    public float scrollSpeed = 3f;

    public float minY = 30f;
    public float maxY = 80f;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
            canMove = !canMove;

        if (!canMove)
            return;

        //movement de la camera (up) et si la souris colles les bordures
		if (Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - panBorder)
        {
            //on se déplace par rapport au monde pas à la rotation local
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        //move arrière
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        //move a gauche
        if (Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        //move à droite
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        scroll *= 1000;
        transform.Translate(Vector3.forward * scroll * scrollSpeed * Time.deltaTime);
        if (transform.position.y > maxY)
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        else if (transform.position.y < minY)
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);

    }
}
