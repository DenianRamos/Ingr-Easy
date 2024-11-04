﻿using System.Security.Cryptography;
using System.Text;

namespace IngrEasy.Application.Criptography;

public class PasswordEncrypter
{
    
    private readonly string _additionalKey;

    public PasswordEncrypter(string additionalKey) => _additionalKey = additionalKey;

    public string Encrypt(string password)
    {

        
            
            var newPassword = password + _additionalKey;
        
     var bytes = Encoding.UTF8.GetBytes(newPassword);
     var hashBytes = SHA512.HashData(bytes);
     
     return ConvertByteArrayToString(hashBytes);
    }
    
    
    
    private static string ConvertByteArrayToString(byte[]bytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }
        return sb.ToString();
    }
}