namespace Croissantage
{
    public class Session
    {
        private bool open;

        public Session()
        {
            open = true;
        }

        public bool isOpen()
        {
            return open;
        }

        public void Switch()
        {
            open = !open;
        }
    }
}
