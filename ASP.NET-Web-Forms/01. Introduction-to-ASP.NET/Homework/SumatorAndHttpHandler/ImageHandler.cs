using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace SumatorAndHttpHandler
{
    public class ImageHandler : IHttpHandler
    {
        //Usage example: http://localhost:16101/test.img?text=test
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var content = context.Request.QueryString["text"];

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new Exception();
            }

            this.GenerateImage(context.Response, content, 620, 480, Color.Pink, FontFamily.GenericMonospace, 18, Brushes.Black, 0, 0, "image/png", ImageFormat.Png);
        }

        private void GenerateImage(HttpResponse response, string textToInsert, int width, int height, Color backgroundColor,
                   FontFamily fontFamily, float emSize, Brush brush, float x, float y, string contentType, ImageFormat imageFormat)
        {
            using (var bitmap = new Bitmap(width, height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(backgroundColor);
                    graphics.DrawString(textToInsert, new Font(fontFamily, emSize), brush, x, y);
                    response.ContentType = contentType;
                    bitmap.Save(response.OutputStream, imageFormat);
                }
            }
        }
    }
}