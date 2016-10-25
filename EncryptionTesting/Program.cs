using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionTesting
{
    class Program
    {
        public static void Main(string[] args)
        {
            String ToEncrypt = "BOGGLE";
            String PassPraise = "THE COW GOES MOO";
            String Encrypted = StringCipher.Encrypt(ToEncrypt, PassPraise);
            Console.WriteLine(StringCipher.Decrypt(Encrypted, PassPraise));
        }
    }
}
