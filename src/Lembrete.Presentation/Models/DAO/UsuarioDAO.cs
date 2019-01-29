using Lembrete.Presentation.Models.DAO.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Lembrete.Presentation.Models.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {

        private readonly IConfiguration _configuration;

        public UsuarioDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Adicionar(UsuarioViewModel obj)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string SQLAdicionar = "INSERT INTO USUARIOS (NOME, DATADENASCIMENTO, SEXO, EMAIL) " +
                                      "VALUES (@NOME, @DATADENASCIMENTO, @SEXO, @EMAIL)";

                SqlCommand cmdAdicionar = new SqlCommand(SQLAdicionar, con)
                {
                    CommandType = CommandType.Text
                };
                cmdAdicionar.Parameters.AddWithValue("@NOME", obj.Nome);
                cmdAdicionar.Parameters.AddWithValue("@DATADENASCIMENTO", obj.DataDeNascimento);
                cmdAdicionar.Parameters.AddWithValue("@SEXO", obj.Sexo);
                cmdAdicionar.Parameters.AddWithValue("@EMAIL", obj.Email);
                con.Open();
                try
                {
                    cmdAdicionar.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                
            }
        }

        public void Atualizar(UsuarioViewModel obj)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string SQLAtualizar = "UPDATE USUARIOS " +
                                      "SET NOME = @NOME, " +
                                      "DATADENASCIMENTO = @DATADENASCIMENTO, " +
                                      "SEXO = @SEXO " +
                                      "WHERE EMAIL = @EMAIL";

                SqlCommand cmdAtualizar = new SqlCommand(SQLAtualizar, con)
                {
                    CommandType = CommandType.Text
                };

                cmdAtualizar.Parameters.AddWithValue("@NOME", obj.Nome);
                cmdAtualizar.Parameters.AddWithValue("@DATADENASCIMENTO", obj.DataDeNascimento);
                cmdAtualizar.Parameters.AddWithValue("@SEXO", obj.Sexo);

                con.Open();

                try
                {
                    cmdAtualizar.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string SQLObterPorId = "SELECT USUARIOID, NOME, DATADENASCIMENTO, SEXO, EMAIL " +
                                       "FROM USUARIOS " +
                                       "WHERE USUARIOID = @USUARIOID";

                SqlCommand cmdObterPorId = new SqlCommand(SQLObterPorId, con)
                {
                    CommandType = CommandType.Text
                };

                cmdObterPorId.Parameters.AddWithValue("@USUARIOID", id);

                con.Open();

                UsuarioViewModel usuario = new UsuarioViewModel();

                try
                {
                    SqlDataReader rd = cmdObterPorId.ExecuteReader();

                    
                    while(rd.Read())
                    {
                        usuario.UsuarioId = (Guid) rd["USUARIOID"];
                        usuario.Nome = rd["NOME"].ToString();
                        usuario.DataDeNascimento = (DateTime) rd["DATADENASCIMENTO"];
                        usuario.Sexo = rd["SEXO"].ToString();
                        usuario.Email = rd["EMAIL"].ToString();

                    }
                }
                finally
                {
                    con.Close();
                }

                return usuario;
            }
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string SQLRemover = "DELETE USUARIOS WHERE USUARIOID = @USUARIOID";

                SqlCommand cmdRemover = new SqlCommand(SQLRemover, con)
                {
                    CommandType = CommandType.Text
                };

                cmdRemover.Parameters.AddWithValue("@USUARIOID", id);

                con.Open();

                try
                {
                    cmdRemover.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}