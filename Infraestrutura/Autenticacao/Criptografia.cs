using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Infraestrutura.Autenticacao
{
    public static class Criptografia
    {
        /// <summary>     
        /// Vetor de bytes utilizados para a criptografia (Chave Externa)     
        /// </summary>     
        private static byte[] bIV =
        { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18,
        0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        /// <summary>     
        /// Chave de criptografia (Chave Interna)    
        /// Recomendado colocar um valor em base 64 de 
        /// um conjunto de 32 caracteres (8 * 32 = 256bits) 
        /// A chave é: "b8dee21b7e4f4ce2ae0f0d74aba26526"
        /// </summary>     
        private const string chaveCriptografia = "YjhkZWUyMWI3ZTRmNGNlMmFlMGYwZDc0YWJhMjY1MjY=";


        public static string Criptografar(string texto, string chaveParaCriptografar = chaveCriptografia)
        {
            try
            {
                if (!string.IsNullOrEmpty(texto))
                {
                    // Cria instancias de vetores de bytes com as chaves                
                    byte[] chaveBase = Convert.FromBase64String(chaveCriptografia);
                    byte[] textoBase = new UTF8Encoding().GetBytes(texto);

                    // Instancia a classe de criptografia Rijndael
                    Rijndael rijndael = new RijndaelManaged();

                    rijndael.KeySize = ObterTamanhoDaChave(chaveParaCriptografar.Length);

                    // Cria o espaço de memória para guardar o valor criptografado:                
                    MemoryStream mStream = new MemoryStream();
                    // Instancia o encriptador                 
                    CryptoStream encriptador = new CryptoStream(
                        mStream,
                        rijndael.CreateEncryptor(chaveBase, bIV),
                        CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória
                    encriptador.Write(textoBase, 0, textoBase.Length);
                    // Despeja toda a memória.                
                    encriptador.FlushFinalBlock();
                    // Pega o vetor de bytes da memória e gera a string criptografada                
                    return Convert.ToBase64String(mStream.ToArray());
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                // Se algum erro ocorrer, dispara a exceção            
                throw new ApplicationException("Erro ao criptografar", ex);
            }
        }

        public static string Descriptografar(string texto, string chaveParaCriptografar = chaveCriptografia)
        {
            try
            {
                if (!string.IsNullOrEmpty(texto))
                {
                    // Cria instancias de vetores de bytes com as chaves                
                    byte[] chaveBase = Convert.FromBase64String(chaveCriptografia);
                    byte[] textoBase = Convert.FromBase64String(texto);

                    Rijndael rijndael = new RijndaelManaged();


                    rijndael.KeySize = ObterTamanhoDaChave(chaveParaCriptografar.Length);

                    MemoryStream mStream = new MemoryStream();

                    CryptoStream decriptador = new CryptoStream(
                        mStream,
                        rijndael.CreateDecryptor(chaveBase, bIV),
                        CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória   
                    decriptador.Write(textoBase, 0, textoBase.Length);
                    // Despeja toda a memória.                
                    decriptador.FlushFinalBlock();
                    // Instancia a classe de codificação para que a string venha de forma correta         
                    UTF8Encoding utf8 = new UTF8Encoding();
                    // Com o vetor de bytes da memória, gera a string descritografada em UTF8       
                    return utf8.GetString(mStream.ToArray());
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao descriptografar", ex);
            }
        }

        // Define o tamanho da chave "256 = 8 * 32"                
        // Chaves possíves: 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)  
        private static int ObterTamanhoDaChave(int qtdLetrasChaveCriptografia)
        {
            int valor;
            if (qtdLetrasChaveCriptografia <= 16)
                valor = 16;
            else if (qtdLetrasChaveCriptografia <= 24)
                valor = 24;
            else
                valor = 32;
            return valor * 8;
        }
    }
}