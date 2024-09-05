namespace Core.Services.Scenes
{
    public readonly struct ScenePlace
    {
        public static readonly ScenePlace Splash = new("Splash");
        public static readonly ScenePlace Menu = new("Menu");
        public static readonly ScenePlace Game = new("Game");

        public readonly string Value;

        public ScenePlace(string value)
        {
            Value = value;
        }

        public override string ToString() => Value;
    }
}