using Lembrete.Presentation.Models.DAO.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Lembrete.Presentation.Models.DAO
{
    public class LembreteDAO : ILembreteDAO
    {

        private readonly IConfiguration _configuration;

        public LembreteDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Adicionar(LembreteViewModel obj)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string SQLAdicionar = "INSERT INTO LEMBRETES (DATACADASTRO, DATALEMBRETE, LEMBRADO, " +
                                      "DATALEMBRADO, ASSUNTO, DESCRICAO, USUARIO_ID) VALUES (@DATACADASTRO, " +
                                      "@DATALEMBRETE, @LEMBRADO, @DATALEMBRADO, @ASSUNTO, @DESCRICAO, @USUARIO_ID)";

                SqlCommand cmdAdicionar = new SqlCommand(SQLAdicionar, con)
                {
                    CommandType = CommandType.Text
                };
                cmdAdicionar.Parameters.AddWithValue("@DATACADASTRO", obj.DataCadastro);
                cmdAdicionar.Parameters.AddWithValue("@DATALEMBRETE", obj.DataLembrete);
                cmdAdicionar.Parameters.AddWithValue("@LEMBRADO", obj.Lembrado);
                cmdAdicionar.Parameters.AddWithValue("@DATALEMBRADO", obj.DataLembrado);
                cmdAdicionar.Parameters.AddWithValue("@ASSUNTO", obj.Assunto);
                cmdAdicionar.Parameters.AddWithValue("@DESCRICAO", obj.Descricao);
                cmdAdicionar.Parameters.AddWithValue("@USUARIO_ID", obj.Usuario.UsuarioId);
                con.Open();
                try
                {
                    cmdAdicionar.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }

            };
        }

        public void Atualizar(LembreteViewModel obj)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string SQLAtualizar = "UPDATE LEMBRETES " +
                                      "SET DATALEMBRETE = @DATALEMBRETE," +
                                      "LEMBRADO = @LEMBRADO, " +
                                      "DATALEMBRADO = @DATALEMBRADO, " +
                                      "ASSUNTO = @ASSUNTO, " +
                                      "DESCRICAO = @DESCRICAO" +
                                      "WHERE LEMBRETEID = @LEMBRETEID";

                SqlCommand cmdAdicionar = new SqlCommand(SQLAtualizar, con)
                {
                    CommandType = CommandType.Text
                };
                cmdAdicionar.Parameters.AddWithValue("@DATALEMBRETE", obj.DataLembrete);
                cmdAdicionar.Parameters.AddWithValue("@LEMBRADO", obj.Lembrado);
                cmdAdicionar.Parameters.AddWithValue("@DATALEMBRADO", obj.DataLembrado);
                cmdAdicionar.Parameters.AddWithValue("@ASSUNTO", obj.Assunto);
                cmdAdicionar.Parameters.AddWithValue("@DESCRICAO", obj.Descricao);
                cmdAdicionar.Parameters.AddWithValue("@LEMBRETEID", obj.LembreteId);
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

        public LembreteViewModel ObterPorId(Guid id)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string SQLObterPorId = "SELECT LEMBRETE_ID, DATACADASTRO, DATALEMBRETE, LEMBRADO, DATALEMBRADO, ASSUNTO, DESCRICAO, USUARIO_ID " +
                                       "FROM LEMBRETES " +
                                       "WHERE LEMBRETEID = @LEMBRETEID " +
                                       "ORDER BY DATACADASTRO, ASSUNTO";

                SqlCommand cmdObterPorId = new SqlCommand(SQLObterPorId, con)
                {
                    CommandType = CommandType.Text
                };

                cmdObterPorId.Parameters.AddWithValue("@LEMBRETEID", id);

                con.Open();

                LembreteViewModel lembrete = new LembreteViewModel();

                try
                {
                    SqlDataReader rd = cmdObterPorId.ExecuteReader();

                    while(rd.Read())
                    {
                        lembrete.DataCadastro = (DateTime)rd["DATACADASTRO"];
                        lembrete.DataLembrete = (DateTime)rd["DATALEMBRETE"];
                        lembrete.Lembrado = Boolean.Parse(rd["LEMBRADO"].ToString());
                        lembrete.DataLembrado = (DateTime)rd["DATALEMBRADO"];
                        lembrete.Assunto = rd["ASSUNTO"].ToString();
                        lembrete.Descricao = rd["DESCRICAO"].ToString();
                        lembrete.Usuario.UsuarioId = (Guid)rd["USUARIO_ID"];
                    }
                }
                finally
                {
                    con.Close();
                }

                return lembrete;
            }
        }
        public IEnumerable<LembreteViewModel> ObterTodos()
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string SQLObterTodos = "SELECT LEMBRETE_ID, DATACADASTRO, DATALEMBRETE, LEMBRADO, DATALEMBRADO, ASSUNTO, DESCRICAO, USUARIO_ID " +
                                       "FROM LEMBRETES " +
                                       "ORDER BY DATACADASTRO, ASSUNTO";

                SqlCommand cmdObterTodos = new SqlCommand(SQLObterTodos, con)
                {
                    CommandType = CommandType.Text
                };

                con.Open();

                List<LembreteViewModel> lembretes = new List<LembreteViewModel>();

                try
                {
                    
                    SqlDataReader rd = cmdObterTodos.ExecuteReader();

                    while (rd.Read())
                    {
                        LembreteViewModel lembrete = new LembreteViewModel
                        {
                            DataCadastro = (DateTime)rd["DATACADASTRO"],
                            DataLembrete = (DateTime)rd["DATALEMBRETE"],
                            Lembrado = Boolean.Parse(rd["LEMBRADO"].ToString()),
                            DataLembrado = (DateTime)rd["DATALEMBRADO"],
                            Assunto = rd["ASSUNTO"].ToString(),
                            Descricao = rd["DESCRICAO"].ToString()
                        };
                        lembrete.Usuario.UsuarioId = (Guid)rd["USUARIO_ID"];
                        lembretes.Add(lembrete);
                    }
                }
                finally
                {
                    con.Close();
                }

                return lembretes;
            }
        }

        public void Remover(Guid id)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string SQLRemover = "DELETE FROM LEMBRETES WHERE LEMBRETEID = @LEMBRETEID";

                SqlCommand cmdRemover = new SqlCommand(SQLRemover, con)
                {
                    CommandType = CommandType.Text
                };

                cmdRemover.Parameters.AddWithValue("@LEMBRETEID", id);

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
        }
    }
}