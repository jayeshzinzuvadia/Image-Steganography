using ImageSteganographyRestService.Utilities;
using System;
using System.Web.Http;

namespace ImageSteganographyRestService.Controllers
{
    public class HideAndSeekController : ApiController
    {
        ImageUtil util;
        public HideAndSeekController()
        {
            util = new ImageUtil();
        }
        [HttpGet]
        public string hello()
        {
            return "hello";
        }
        [HttpPost]
        public string greet(dynamic data)
        {
            return $"welcome {data.name1} and {data.name2}";
        }

        [HttpPost]
        public byte[] hideMessage(dynamic data)
        {
            string msg = null, key = null, encryptType = null;
            byte[] cover = null;

            try
            {
                msg = data.msg;
                key = data.key;
                encryptType = data.encryptType;
                cover = data.cover;
                Console.WriteLine("Image reached when encoding size in bytes:" + cover.Length.ToString());

                return util.hideMessage(msg, key, cover, (encryptType.Equals("DES")) ? CryptoUtil.Algo.DES : CryptoUtil.Algo.AES);
            }
            catch (Exception)
            {
                throw;

            }

        }
        [HttpPost]
        public string seekMessage(dynamic data)
        {
            string key = null, encryptType = null;
            byte[] coverWithData = null;
            try
            {
                key = data.key;
                encryptType = data.encryptType;
                coverWithData = data.coverWithData;

                Console.WriteLine("Image reached when decoding size in bytes:" + coverWithData.Length.ToString());
                return util.extractMessage(coverWithData, key, (encryptType.Equals("DES")) ? CryptoUtil.Algo.DES : CryptoUtil.Algo.AES);
            }
            catch (Exception)
            {

                return "";
            }


        }

    }
}
