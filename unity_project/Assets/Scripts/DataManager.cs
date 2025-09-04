using UnityEngine;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

/// <summary>
/// Manages loading all game data from JSON files into memory.
/// This class uses the Singleton pattern to ensure only one instance exists.
/// It uses SimpleJSON to parse the top-level dictionary structure of the JSON files
/// and Unity's JsonUtility to deserialize the nested objects.
/// </summary>
public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public Dictionary<string, BoardData> AllBoardData { get; private set; } = new Dictionary<string, BoardData>();
    public Dictionary<string, Chest> AllChestData { get; private set; } = new Dictionary<string, Chest>();
    public Dictionary<string, Companion> AllCompanionData { get; private set; } = new Dictionary<string, Companion>();
    public Dictionary<string, StoreItem> AllStoreData { get; private set; } = new Dictionary<string, StoreItem>();

    void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAllData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Loads all JSON data from the specified data path.
    /// In a real Unity project, these files would be in the "Resources" folder
    /// or loaded via Addressables. For this conversion, we simulate loading from a path.
    /// </summary>
    private void LoadAllData()
    {
        // In a real Unity project, you would use Application.dataPath + "/Data"
        // or load from Resources. We are using a relative path for this environment.
        string dataPath = "unity_project/Assets/Data";

        LoadData<BoardData>(Path.Combine(dataPath, "boards.json"), AllBoardData);
        LoadData<Chest>(Path.Combine(dataPath, "chests.json"), AllChestData);
        LoadData<Companion>(Path.Combine(dataPath, "companions.json"), AllCompanionData);
        LoadData<StoreItem>(Path.Combine(dataPath, "store.json"), AllStoreData);

        Debug.Log("All game data loaded successfully.");
    }

    /// <summary>
    /// Generic method to load a specific type of data from a JSON file.
    /// </summary>
    /// <typeparam name="T">The type of data object to deserialize (e.g., Companion, Chest).</typeparam>
    /// <param name="filePath">The full path to the JSON file.</param>
    /// <param name="dataDictionary">The dictionary to populate with the loaded data.</param>
    private void LoadData<T>(string filePath, IDictionary<string, T> dataDictionary)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError($"Data file not found at: {filePath}");
            return;
        }

        string jsonText = File.ReadAllText(filePath);
        JSONNode parsedJson = JSON.Parse(jsonText);

        if (parsedJson == null || !parsedJson.IsObject)
        {
            Debug.LogError($"Failed to parse JSON or root is not an object in file: {filePath}");
            return;
        }

        foreach (KeyValuePair<string, JSONNode> entry in parsedJson.AsObject)
        {
            string id = entry.Key;
            string itemJson = entry.Value.ToString();

            T item = JsonUtility.FromJson<T>(itemJson);

            // Use reflection to set the ID field if it exists.
            // This makes the method generic for all data types.
            var idField = typeof(T).GetField("id");
            if (idField != null)
            {
                idField.SetValue(item, id);
            }

            // Handle the 'tier' field for Chests specifically.
            var tierField = typeof(T).GetField("tier");
            if (tierField != null && typeof(T) == typeof(Chest))
            {
                tierField.SetValue(item, id);
            }


            dataDictionary.Add(id, item);
        }
    }
}
