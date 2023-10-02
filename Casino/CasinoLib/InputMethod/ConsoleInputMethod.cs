namespace CasinoLib.InputMethod
{
    public class ConsoleInputMethod : IInputMethod
    {
        private int _key;
        private string _description;

        public ConsoleInputMethod(int key, string description)
        {
            _key = key;
            _description = description;
        }
        
        public int GetKey()
        {
            return _key;
        }
        
        public string GetDescription()
        {
            return _description;
        }
    }
}
