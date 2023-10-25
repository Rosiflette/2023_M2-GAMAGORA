using System.IO;
using UnityEngine;

public class OFFFileManager : MonoBehaviour
{
    [SerializeField] private Object file;

    public static OFFFileManager Instance { get; private set; }

    private StreamReader content;
    // Start is called before the first frame update
    void Start()
    {
        string path = Path.Join(Application.dataPath, file.name + ".off");
        content = File.OpenText(path);
    }


    public static StreamReader StreamReaderGetContent()
    {
        return Instance.content;
    }
}