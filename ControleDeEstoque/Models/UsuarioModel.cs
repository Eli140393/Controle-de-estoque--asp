using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleDeEstoque.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {
            var ret = false;
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=DESKTOP-KI43LUD\\SQLEXPRESS; initial Catalog=controleEstoque; User id=sa; Password=eliezer140393;";
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("select count(*) from TB_Login where NM_Login = '{0}' and NM_Senha = '{1}'",login,senha);
                    ret = ((int)comando.ExecuteScalar() > 0);
                }
            }
            return ret;
        }

    }
}