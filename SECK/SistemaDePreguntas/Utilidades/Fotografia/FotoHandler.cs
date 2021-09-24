using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

namespace Fotografia
{
    public class FotoHandler
    {
        private Bitmap imagenBitmap_;
        private bool ExistenDispositivos_;
        private FilterInfoCollection DispositivosDeVideo_;
        private VideoCaptureDevice FuenteDeVideo_;
        private bool error_;

        public Bitmap ImagenBitMap
        {
            get { return imagenBitmap_; }
        }
        public bool Error
        {
            get { return error_; }
        }

        public FotoHandler()
        {
            error_ = false;
            ExistenDispositivos_ = false;
            FuenteDeVideo_ = null;
            BuscarDispositivos();

            if (ExistenDispositivos_)
            {
                FuenteDeVideo_ = new VideoCaptureDevice(DispositivosDeVideo_[0].MonikerString);
                FuenteDeVideo_.NewFrame += new NewFrameEventHandler((a,b) => imagenBitmap_ = (Bitmap)b.Frame.Clone());
                FuenteDeVideo_.VideoSourceError += new VideoSourceErrorEventHandler((a, b) => error_ = true);
                FuenteDeVideo_.Start();
            }
            else
            {
                error_ = true;
            }
        }

        private void BuscarDispositivos()
        {
            DispositivosDeVideo_ = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivosDeVideo_.Count == 0)
                ExistenDispositivos_ = false;
            else
            {
                ExistenDispositivos_ = true;
            }
        }

        public void Apagar()
        {
            if (!(FuenteDeVideo_ == null))
                if (FuenteDeVideo_.IsRunning)
                {
                    FuenteDeVideo_.SignalToStop();
                    FuenteDeVideo_ = null;
                }
        }
    }
}
