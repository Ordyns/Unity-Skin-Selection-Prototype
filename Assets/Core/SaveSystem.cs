using System.IO;
using UnityEngine;

public class SaveSystem<T> where T: IData, new()
{
    private readonly string _fileName = new T().FileName + ".json";
    private readonly string _targetDirectory;
    private readonly string _fullPath;

    public SaveSystem(){
        string editorPath = Application.dataPath;
        _targetDirectory = Application.isEditor ? editorPath : Application.persistentDataPath;
        _fullPath = Path.Combine(_targetDirectory, _fileName);
    }

    public bool LoadData(out T data){
        if (Directory.Exists(_targetDirectory) == false || File.Exists(_fullPath) == false){
            data = new T();
            return false;
        }

        data = JsonUtility.FromJson<T>(File.ReadAllText(_fullPath));
        return data != null;
    }

    public void SaveData(T data){
        if(Directory.Exists(_targetDirectory) == false)
            Directory.CreateDirectory(_targetDirectory);

        File.WriteAllText(_fullPath, JsonUtility.ToJson(data));
    }
}