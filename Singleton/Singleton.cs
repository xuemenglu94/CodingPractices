namespace Singleton
{
    public class President
    {
        protected President()
        {
        }

        private static President _instance = new President();
        
        public string Name { get; set; }

        public static President Instance
        {
            get { return _instance; }
        }

        public static void SetName(string name)
        {
            _instance.Name = name;
        }
    }
}
