using UnityEngine;

public class Clusterblast : MonoBehaviour
{
    [SerializeField] GameObject clusterSpew;
    [SerializeField] float delay;
    [SerializeField] float speed;


    private void Start()
    {
        Invoke(nameof(Poof), delay);
    }

    public void OnDestroy()
    {
        for(int i = 0;i < 18; i++)
        {   
            Instantiate(clusterSpew, transform.position, transform.rotation);
        }
        
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }

    public void Poof()
    {
        Destroy(gameObject);
    }

}
