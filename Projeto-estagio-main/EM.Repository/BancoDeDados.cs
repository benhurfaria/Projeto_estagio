using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace EM.Repository
{
    public static class BancoDeDados
    {
        private static string stringConexao = @"User=sysdba;password=masterkey;Database=C:\Users\Escolar Manager\Desktop\ben\ESCOLA.FDB;DataSource=localhost;Port=3053;Dialect=3;Charset=NONE;Role=;Connection lifetime = 15; Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size = 8192; ServerType=0";
        public static FbConnection Conexao()
        {
            FbConnection conexao = new FbConnection(stringConexao);
            conexao.Open();
            return conexao;
        }
    }
}
