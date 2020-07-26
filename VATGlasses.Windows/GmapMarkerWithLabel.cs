using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VATGlasses
{
    public class GMapMarkerWithLabel : GMapMarker, ISerializable
    {
        private Font font;
        private GMarkerGoogle innerMarker;

        public string Caption;

        public GMapMarkerWithLabel(PointLatLng p, string caption, GMarkerGoogleType type)
            : base(p)
        {
            font = new Font("Arial", 14);
            innerMarker = new GMarkerGoogle(p, type);

            Caption = caption;
        }

        public GMapMarkerWithLabel(PointLatLng p, string caption, Bitmap bitmap)
            : base(p)
        {
            font = new Font("Arial", 14);
            innerMarker = new GMarkerGoogle(p, bitmap);

            Caption = caption;
        }

        public override void OnRender(Graphics g)
        {
            if (innerMarker != null)
            {
                innerMarker.OnRender(g);
            }

            g.DrawString(Caption, font, Brushes.Black, new PointF(0.0f, innerMarker.Size.Height));
        }

        public override void Dispose()
        {
            if (innerMarker != null)
            {
                innerMarker.Dispose();
                innerMarker = null;
            }

            base.Dispose();
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        protected GMapMarkerWithLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}
