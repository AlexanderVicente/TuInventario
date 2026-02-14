using System.IO;
using UnityEngine;
using static DataBase;

public class ComicJsonManager : MonoBehaviour
{
    public static ComicJsonManager Instance;

    string filePath;

    ComicDatabase database = new ComicDatabase();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            filePath = Path.Combine(Application.persistentDataPath, "Comics.json");
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public ComicDatabase GetDatabase()
    {
        return database;
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(database, true);
        File.WriteAllText(filePath, json);
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            database = JsonUtility.FromJson<ComicDatabase>(json);
        }
        else
        {
            database = new ComicDatabase();
            Save();
        }
    }
}
