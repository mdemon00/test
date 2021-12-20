using System.Drawing;
using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;

namespace DevSkill.DevTrack.ClientEngine.Adapters
{
    public class ScreenCaptureAdapter : IScreenCaptureAdapter
    {
        private readonly IScreenSizeAdapter _screenSizeAdapter;

        public ScreenCaptureAdapter(IScreenSizeAdapter screenSizeAdapter)
        {
            _screenSizeAdapter = screenSizeAdapter;
        }

        public byte[] CaptureScreen()
        {
            var screenSize = _screenSizeAdapter.GetScreenSize();

            using var bitmap = new Bitmap(screenSize.width, screenSize.height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(0, 0, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
            }

            var cloneImage = (Bitmap) bitmap.Clone();

            var converter = new ImageConverter();
            return (byte[]) converter.ConvertTo(cloneImage, typeof(byte[]));
        }
    }
}