using System.Windows.Media;

namespace StationGUI
{
    public class ItemCount
    {
        public Brush Color { get; private set; }
        public int Value { get; private set; }
        public ItemCount(Brush color, int value)
        {
            Color = color;
            Value = value;
        }

    }
}