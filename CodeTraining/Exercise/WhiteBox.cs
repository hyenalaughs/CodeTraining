namespace Leetcode.Exercise
{
    internal class WhiteBox
    {
        public event Changed WhiteBoxChanged;

        public delegate void Changed();

        private List<string> _strings =  new List<string> { "scott", "Leon", "Kennedy", "Ada", 
                                                            "Wong", "Stars", "Super", "Sequeal" };

        public List<string> Strings { 
            get 
            { 
                return _strings;
            } 
            set 
            { 
                _strings = value;
                WhiteBoxChanged?.Invoke();
            } 
        }

        public void StringChanged()
        {
            Console.WriteLine("Был изменен");
        }
    }
}
