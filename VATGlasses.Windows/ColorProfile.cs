using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VATGlasses
{
    class ColorProfile
    {
        public readonly Bitmap Close;
        public readonly Bitmap Maximise;
        public readonly Bitmap Minimise;
        public readonly Bitmap Settings;
        public readonly Bitmap Refresh;
        public readonly Bitmap Search;
        public readonly Bitmap Filter;
        public readonly Bitmap Logo;

        public readonly Color Control;
        public readonly Color TransparentControl;
        public readonly Color Text;
        public readonly Color Accent;
        public readonly Color Window;

        public static readonly ColorProfile Light = new ColorProfile(new Bitmap(Image.FromFile(@"images\light\appbar.close.png"), 31, 31), new Bitmap(Image.FromFile(@"images\light\appbar.window.restore.png"), 31, 31), new Bitmap(Image.FromFile(@"images\light\appbar.minus.png"), 31, 31), new Bitmap(Image.FromFile(@"images\light\appbar.settings.png"), 31, 31), new Bitmap(Image.FromFile(@"images\light\appbar.refresh.png"), 31, 31), new Bitmap(Image.FromFile(@"images\light\appbar.magnify.png"), 31, 31), new Bitmap(Image.FromFile(@"images\light\appbar.filter.png"), 31, 31), new Bitmap(Image.FromFile(@"images\light\plane.png"), 16, 16), Color.Transparent, SystemColors.Control, SystemColors.ControlText, Color.DarkGreen, SystemColors.Window);
        public static readonly ColorProfile Dark = new ColorProfile(new Bitmap(Image.FromFile(@"images\dark\appbar.close.png"), 31, 31), new Bitmap(Image.FromFile(@"images\dark\appbar.window.restore.png"), 31, 31), new Bitmap(Image.FromFile(@"images\dark\appbar.minus.png"), 31, 31), new Bitmap(Image.FromFile(@"images\dark\appbar.settings.png"), 31, 31), new Bitmap(Image.FromFile(@"images\dark\appbar.refresh.png"), 31, 31), new Bitmap(Image.FromFile(@"images\dark\appbar.magnify.png"), 31, 31), new Bitmap(Image.FromFile(@"images\dark\appbar.filter.png"), 31, 31), new Bitmap(Image.FromFile(@"images\dark\plane.png"), 16, 16), Color.FromArgb(12, 12, 12), Color.FromArgb(12, 12, 12), Color.FromArgb(237, 237, 237), Color.LightGreen, Color.FromArgb(12, 12, 12));

        private ColorProfile(Bitmap _close, Bitmap _max, Bitmap _min, Bitmap _settings, Bitmap _refresh, Bitmap _search, Bitmap _filter, Bitmap _logo, Color _transparent, Color _control, Color _text, Color _accent, Color _window)
        {
            Close = _close;
            Maximise = _max;
            Minimise = _min;
            Settings = _settings;
            Refresh = _refresh;
            Search = _search;
            Filter = _filter;
            Logo = _logo;

            Control = _control;
            TransparentControl = _transparent;
            Text = _text;
            Accent = _accent;
            Window = _window;
        }
    }
}
