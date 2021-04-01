using System;
using System.ServiceModel;

namespace Image_Steganography_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHideAndSeek" in both code and config file together.
    [ServiceContract]
    public interface IHideAndSeek
    {
        [OperationContract]
        byte[] hideMessage(String msg, String key, byte[] cover, String encryptType);

        [OperationContract]
        String seekMessage(String key, byte[] coverWithData, String encryptType);
    }
}
