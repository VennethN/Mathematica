using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class UserData{
    public Dictionary<string, int> mentalModeHighscores;
}

[System.Serializable]
public class UserDataWrapper{
    public UserData data;
}