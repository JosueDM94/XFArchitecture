using System;
namespace XFArchitecture.Core.Contracts.General
{
    public interface ICryptoService
    {
        string CreatePassword(int length);
        string Encrypt(string clearValue, string encryptionKey);
        string Decrypt(string encryptedValue, string encryptionKey);
    }
}
