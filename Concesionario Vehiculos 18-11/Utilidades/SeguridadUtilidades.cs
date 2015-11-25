using System;
using System.Security.Cryptography;
using System.Text;

namespace Concesionario_Vehiculos_18_11.Utilidades
{
    public class SeguridadUtilidades // SE ENCARGA DEL CIFRADO, DESCIFRADO Y HASHEADO
    {
        public static String GetSha1(String texto)
        {
            var sha = SHA1.Create();

            UTF8Encoding encoding= new UTF8Encoding(); // codifica a unicode
            //ASCIIEncoding encoding= new ASCIIEncoding(); otro tipo de codificador, a caracteres ascii (JUEGO PRIMITIVO DE CARACTERES)
            
            byte[] datos; // la clase sha nos devuelve un array de bytes
            
            StringBuilder builder= new StringBuilder();

            datos = sha.ComputeHash(encoding.GetBytes(texto));// genera un conjunto de bytes

            for (int i = 0; i < datos.Length; i++)
            {
                builder.AppendFormat("{0:x2}", datos[i]);
            }

            return builder.ToString();
        }

        public static byte[] GetKey(String txt)
        {
            return new PasswordDeriveBytes(txt, null).GetBytes(32);
        }

        public static String Cifrar(String contenido, String clave) // el cifrado puede ser simetrico o asimetrico
            // el cifrado simetrico lo utilizaremos si tenemos que compartir los datos con otros.
        {
            var encoding= new UTF8Encoding();

            var cripto= new RijndaelManaged();

            byte[] cifrado;
            byte[] retorno;
            byte[] key = GetKey(clave);

            cripto.Key = key;
            cripto.GenerateIV(); // generar IV(Vector de Inicializacion)
            byte[] aEncriptar = encoding.GetBytes(contenido);

            cifrado = cripto.CreateEncryptor().TransformFinalBlock(aEncriptar, 0, aEncriptar.Length);

            retorno= new byte[cripto.IV.Length+cifrado.Length];
            cripto.IV.CopyTo(retorno,0);
            cifrado.CopyTo(retorno,cripto.IV.Length);

            return Convert.ToBase64String(retorno); // cualquier documento lo podemos pasar a base64
        }

        public static String DesCifrar (byte[] contenido, String clave)
        {
            UTF8Encoding encoding= new UTF8Encoding();

            var cripto= new RijndaelManaged();
            var ivTemp= new byte[cripto.IV.Length];

            var key = GetKey(clave);
            var cifrado= new byte[contenido.Length-ivTemp.Length];

            cripto.Key = key;

            Array.Copy(contenido, ivTemp,ivTemp.Length); //array.copy coge un array y lo sobreescribe en otro array (1era sobrecarga del metodo)

            Array.Copy(contenido,ivTemp.Length, cifrado,0, cifrado.Length); // 

            cripto.IV = ivTemp;

            var descrifrado = cripto.CreateDecryptor().TransformFinalBlock(cifrado, 0, cifrado.Length);

            return encoding.GetString(descrifrado);

        }
    }

    
}