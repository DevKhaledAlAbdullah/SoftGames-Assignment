using System;

namespace SoftGames.Events
{
    public static class GameEvents
    {
        public static Action OnGameStart;
        public static Action<string> OnSceneLoaded;
    }
}
