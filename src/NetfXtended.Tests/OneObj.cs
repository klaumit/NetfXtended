using System;

namespace NetfXtended.Tests
{
    public class OneObj
    {
        public OneObj(int idx, string text, DateTime time)
        {
            Idx = idx;
            Text = text;
            Time = time;
        }

        public int Idx { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}