using System;                           ///////////////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;       //                           Ultilizando ADO.NTE com Provider SQL                       //
using System.Data.SqlClient;
using System.Linq;                      //
using System.Web;

namespace ControleDeEstoque.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {
            var Ret = false;
            // Criando a Conexão Com Banco
            using(var conexao = new SqlConnection())
            {
                // Passando a String de Conexão
                conexao.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Estoque;Data Source=LAPTOP-2R8BRF4I\\SQLEXPRESS01";
                conexao.Open();

                // Criando Um Comando
                using(var comando = new SqlCommand())
                {
                 // Associando a String De Conexão
                comando.Connection = conexao;

                // Definindo o Que Será executado no Banco
                comando.CommandText = string.Format(
                    "SELECT COUNT(*) FROM Usuario WHERE login= '{0}' AND senha = '{1}'", login, senha
                    );

                // Executando a Query e Recebendo o Valor
                Ret = ((int)comando.ExecuteScalar() > 0);
                }

                return Ret;
            }
        }
    }
}