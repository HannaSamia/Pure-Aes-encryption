using System;
using System.Linq;
using System.Text;

namespace PureAesEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] h(string Hex)
            {
                return Enumerable.Range(0, Hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(Hex.Substring(x, 2), 16)).ToArray();
            }

            var aes = new Aes();

            Console.WriteLine("########################################################## ECB MODE ####################################################");
            //string ECBtext = "this an ECB test";
            string ECBtext = "this an ECB test";

            Console.WriteLine("The plain text is : " + ECBtext);

            byte[] ECBencrypteddata = aes.ECB(Encoding.Unicode.GetBytes("password"), Encoding.Unicode.GetBytes(ECBtext), true);

            string ECBencryptedstring = Convert.ToBase64String(ECBencrypteddata);

            Console.WriteLine("the Encryped data is : " + ECBencryptedstring);

            byte[] ECBDecrypteddata = aes.ECB(Encoding.Unicode.GetBytes("password"), Convert.FromBase64String(ECBencryptedstring), false);

            Console.WriteLine("The decrypted data is : " + Encoding.Unicode.GetString(ECBDecrypteddata));



            Console.WriteLine("########################################################## CTR MODE ####################################################");

            string CTRtext = "this an CTR test";

            Console.WriteLine("The plain text is : " + CTRtext);

            byte[] CTRencrypteddata = aes.CTR(Encoding.Unicode.GetBytes("password"), new byte[16], Encoding.UTF8.GetBytes(CTRtext));

            string CTRencryptedstring = Convert.ToBase64String(CTRencrypteddata);

            Console.WriteLine("the Encryped data is : " + CTRencryptedstring);

            byte[] CTRDecrypteddata = aes.CTR(Encoding.Unicode.GetBytes("password"), new byte[16], Convert.FromBase64String(CTRencryptedstring));

            Console.WriteLine("The decrypted data is : " + Encoding.UTF8.GetString(CTRDecrypteddata));
        }
    }
}
