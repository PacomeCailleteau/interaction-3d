using UnityEngine;

public class GenerateCube : MonoBehaviour
{
    public GameObject cube;
    public Timer timer;

    private bool isClicked;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            if (timer.IsStoped())
            {
                if (timer.StartTimer())
                    CreateCube();
            }
            else CreateCube();
        }
    }

    public void Clicked()
    {
        isClicked = true;
    }

    private void CreateCube()
    {
        GameObject obj = Instantiate(cube);
        obj.transform.SetPositionAndRotation(
            transform.position - new Vector3(0, 0.3f, 0),
            Random.rotation);
        isClicked = false;
    }
}
