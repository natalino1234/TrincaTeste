using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using BancoDeDados.Impl;
using System.Configuration;

namespace ChurraScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChurrasController : ControllerBase
    {
        // POST api/Churras/Create
        [HttpPost]
        [Route("Create")]
        public JsonResult CreateChurras(
            string authToken,
            string descricao, string observacoes, string data, 
            string valorParticipante, string bebidaIncluida)
        {

            Usuario usuario = new Usuario("", "", "", authToken);

            Churras churras = new Churras(
                descricao, 
                observacoes, 
                Convert.ToDateTime(data), 
                Convert.ToDouble(valorParticipante), 
                Convert.ToBoolean(bebidaIncluida)
            );

            JsonResult j;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string local = appSettings["DatabasePath"] ?? "Not Found";
                ChurrasDAO dao = new ChurrasDAO(local);

                UsuarioDAO daouser = new UsuarioDAO(local);
                List<dynamic> usuarioSelecionado = daouser.FindAll_Custom("Select * from usuario where authToken = \"" + authToken + "\"");
                if (usuarioSelecionado.Count > 0)
                {
                    usuario = daouser.Find(Convert.ToInt32(usuarioSelecionado[0].id));
                    try
                    {
                        dao.Insert(churras);

                        List<dynamic> churs = dao.FindAll_Custom("" +
                            "Select " +
                            "   * " +
                            "from " +
                            "   churras " +
                            "where " +
                            "   id_usuario = " + usuario.Id + " order by id desc LIMIT 1;");
                        j = new JsonResult(new object[] { true, churs[0] });
                        
                    }
                    finally
                    {
                        dao.Close();
                    }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações.", "Select * from usuario where authtoken = \"" + authToken + "\"" });
                }
            }
            catch (Exception e)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador.", e.Message, e.StackTrace });
            }
            return j;
        }

        // POST api/Churras/Cancel
        [HttpPost]
        [Route("Cancel")]
        public ActionResult<IEnumerable<string>> CancelChurras(string authToken, int id)
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/Churras/List
        [HttpPost]
        [Route("List")]
        public ActionResult<IEnumerable<string>> ListChurras(string authToken)
        {

            var usuario = new Usuario("", "", "", authToken);

            JsonResult j;

            var appSettings = ConfigurationManager.AppSettings;
            string local = appSettings["DatabasePath"] ?? "Not Found";
            try
            {
                UsuarioDAO daouser = new UsuarioDAO(local);
                List<dynamic> usuarioSelecionado = daouser.FindAll_Custom("Select * from usuario where authToken = \"" + usuario.AuthToken + "\"");
                if (usuarioSelecionado.Count > 0) {
                    ChurrasDAO dao = new ChurrasDAO(local);
                    try
                    {
                        List<dynamic> churras = dao.FindAll_Custom("Select c.nome, c.dataChurras, count(cp.id) qtdParticipantes, (count(cp.id) * c.valor_individual) valorTotal from churras c left join ChurrasParticipante cp on (c.id = cp.id_churras) where c.id_usuario = " + usuarioSelecionado[0].id);
                        dao.Close();
                        j = new JsonResult(new object[] { true, churras });
                    }
                    finally { dao.Close(); }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações.", "Select * from usuario where authToken = \"" + usuario.AuthToken + "\"" });
                }
            }
            catch (Exception e)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador.", local, e.Message, e.StackTrace });
            }
            return j;
        }

        // POST api/Churras/Get
        [HttpPost]
        [Route("Get")]
        public ActionResult<IEnumerable<string>> EditChurras(int id_usuario, string authToken, int id)
        {
            Usuario usuario = new Usuario(id_usuario,"","","",authToken);

            JsonResult j;

            var appSettings = ConfigurationManager.AppSettings;
            string local = appSettings["DatabasePath"] ?? "Not Found";
            try
            {
                UsuarioDAO daouser = new UsuarioDAO(local);
                if (daouser.FindAll_Custom("Select * from usuario where authtoken = \"" + usuario.AuthToken + "\" and login = \"" + usuario.Login + "\"").Count > 0)
                {
                    ChurrasDAO dao = new ChurrasDAO(local);
                    try
                    {
                        List<dynamic> churras = dao.FindAll_Custom("Select * from churras where id_usuario = " + usuario.Id+" and id = "+id);
                        dao.Close();
                        j = new JsonResult(new object[] { true, churras });
                    }
                    finally { dao.Close(); }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações." });
                }
            }
            catch (Exception e)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador.", local, e.StackTrace });
            }
            return j;
        }

        // POST api/Churras/AddParticipante
        [HttpPost]
        [Route("AdicionarParticipante")]
        public ActionResult<IEnumerable<string>> AddParticipanteChurras(string authToken, int id_churras, string nome)
        {

            Usuario usuario = new Usuario("", "", "", authToken);
            JsonResult j;

            var appSettings = ConfigurationManager.AppSettings;
            string local = appSettings["DatabasePath"] ?? "Not Found";
            try
            {
                UsuarioDAO daouser = new UsuarioDAO(local);
                if (daouser.FindAll_Custom("Select * from usuario where authtoken = \"" + usuario.AuthToken + "\" and login = \"" + usuario.Login + "\"").Count > 0)
                {
                    ChurrasParticipanteDAO dao = new ChurrasParticipanteDAO(local);
                    try
                    {
                        ChurrasParticipante participante = new ChurrasParticipante(id_churras, nome, false);
                        dao.Insert(participante);

                        j = new JsonResult(new object[] { true,  dao.FindAll_Custom("Select * from churrasparticipante where id_churras = "+id_churras)});

                        dao.Close();
                    }
                    finally { dao.Close(); }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações." });
                }
            }
            catch (Exception e)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador.", local, e.StackTrace });
            }
            return j;
        }

        // POST api/Churras/AddParticipante
        [HttpPost]
        [Route("RemoverParticipante")]
        public ActionResult<IEnumerable<string>> RemParticipanteChurras(string authToken, int id_participante, int id_churras)
        {

            Usuario usuario = new Usuario("", "", "", authToken);
            JsonResult j;

            var appSettings = ConfigurationManager.AppSettings;
            string local = appSettings["DatabasePath"] ?? "Not Found";
            try
            {
                UsuarioDAO daouser = new UsuarioDAO(local);
                if (daouser.FindAll_Custom("Select * from usuario where authtoken = \"" + usuario.AuthToken + "\" and login = \"" + usuario.Login + "\"").Count > 0)
                {
                    ChurrasParticipanteDAO dao = new ChurrasParticipanteDAO(local);
                    try
                    {
                        ChurrasParticipante participante = new ChurrasParticipante(id_participante ,id_churras, "", false);
                        dao.Delete(participante);

                        j = new JsonResult(new object[] { true, dao.FindAll_Custom("Select * from churrasparticipante where id_churras = " + id_churras) });

                        dao.Close();
                    }
                    finally { dao.Close(); }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações." });
                }
            }
            catch (Exception e)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador.", local, e.StackTrace });
            }
            return j;
        }

        // POST api/Churras/AddParticipante
        [HttpPost]
        [Route("ParticipantePagou")]
        public ActionResult<IEnumerable<string>> ParticipantePagouChurras(string authToken, int id_churras, int id_participante)
        {
            Usuario usuario = new Usuario("","","",authToken);

            JsonResult j;

            var appSettings = ConfigurationManager.AppSettings;
            string local = appSettings["DatabasePath"] ?? "Not Found";
            try
            {
                UsuarioDAO daouser = new UsuarioDAO(local);
                if (daouser.FindAll_Custom("Select * from usuario where authtoken = \"" + usuario.AuthToken + "\" and login = \"" + usuario.Login + "\"").Count > 0)
                {
                    ChurrasParticipanteDAO dao = new ChurrasParticipanteDAO(local);
                    try
                    {
                        dao.pagar(id_participante);

                        j = new JsonResult(new object[] { true, dao.FindAll_Custom("Select * from churrasparticipante where id_churras = " + id_churras) });

                        dao.Close();
                    }
                    finally { dao.Close(); }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações." });
                }
            }
            catch (Exception e)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador.", local, e.StackTrace });
            }
            return j;
        }

    }
}
