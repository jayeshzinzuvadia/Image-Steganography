using System;
using System.Net.Http;
using System.Web;

namespace ImageSteganographyApplication
{
    public partial class Decode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
            finalmessage.InnerText = "";
        }
        protected void DecodeSubmitButton_Click(object sender, EventArgs e)
        {
            int imagefilelenth = image_upload.PostedFile.ContentLength;
            byte[] imgarray = new byte[imagefilelenth];
            HttpPostedFile image = image_upload.PostedFile;
            image.InputStream.Read(imgarray, 0, imagefilelenth);

            //Decoding Message
            String msg = "";
            //using (var client = new Steganography.HideAndSeekClient())
            //{
            //    msg = client.seekMessage(key.Text, imgarray, encrypt.Text);
            //}
            using (var client = new HttpClient())
            {
                msg = client.PostAsJsonAsync((string)Application["Api_baseAddress"] + "api/HideAndSeek/seekMessage", new
                {
                    key = key.Text,
                    encryptType = encrypt.Text,
                    coverWithData = imgarray

                }).Result.Content.ReadAsStringAsync().Result;
            }
            if (msg.Equals(""))
            {
                error.Visible = true;
            }
            else
            {
                finalmessage.InnerText = msg;
            }
        }
    }
}