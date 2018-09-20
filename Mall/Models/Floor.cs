namespace Mall.Models
{
    public class Floor
    {
        private int _id;
        private string _level;

        public Floor(string level, int id=0)
        {
            _level = level;
            _id = id;
        }

        public string GetLevel()
        {
            return _level;
        }

        public int GetId()
        {
            return _id;
        }
    }
}